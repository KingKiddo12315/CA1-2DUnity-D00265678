using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    Animator animator;
    int direction = 1;
    float timeInDirection;

    public float distanceTime;
    public float speed;
    public int health;
    bool isDead = false;
    float dieTime = 2;
    bool isIdle = false;
    public float idleTime = 2;

    [SerializeField] float fireTimer = 2f;
    float fireCountdown = 0;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeInDirection = distanceTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (isIdle && idleTime < 0)
            {
                direction = direction * -1;
                timeInDirection = distanceTime;
                isIdle = false;
            }
            else if (!isIdle && timeInDirection <0)
            {
                animator.SetFloat("MoveY", 1);
                idleTime = 2;
                isIdle = true;
            }
            if(!isIdle)
            {

                animator.SetFloat("MoveX", direction);
                animator.SetFloat("MoveY", 0);
                Vector2 pos = transform.position;
                pos.x = pos.x + (speed * Time.deltaTime* direction);
                transform.position = pos;
                timeInDirection -= Time.deltaTime;
            }
            else
            {
                idleTime -= Time.deltaTime;
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                new Vector2(direction, 0), 5f, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                if(hit.collider.GetComponent<Player>() != null)
                {
                    if (fireCountdown < 0)
                    {
                        fire();
                    }
                }
                fireCountdown -= Time.deltaTime;
            }
        }
        else
        {
            dieTime -= Time.deltaTime;
            if (dieTime < 0)
            {
                Destroy(this.gameObject);
                player.AddKill();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "playerprojectile")
        {
            health--;
            if(health <= 0)
            {
                isDead = true;
                animator.SetBool("Dead", true);
            }
        }
    }
    private void fire()
    {
        if (fireCountdown < 0)
        {
            fireCountdown = fireTimer;
            GameObject projectile = Instantiate(projectilePrefab, 
                GetComponent<Rigidbody2D>().position, Quaternion.identity);
            Projectile proj = projectile.GetComponent<Projectile>();
            proj.Launch(new Vector2(direction, 0), 300);
        }
    }
}
