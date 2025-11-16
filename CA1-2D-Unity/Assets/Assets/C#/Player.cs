using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public int state = 0;
    public float JumpHeight;
    private bool jumping = false;
    private int jumpcount = 0;
    private bool firing = false;

    private Rigidbody2D rb;
    Animator animator;

    public GameObject projectilePrefab;

    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;

        if (position.y < -10.5)
        {
            position = startPosition;
        }
        else
        {
            position.x = position.x + (speed * Time.deltaTime * move);
            if (move != 0)
            {
                state = move < 0 ? 1 : -1;
                animator.SetFloat("MoveX", state);
                animator.SetFloat("MoveY", 0);
            }
            else
            {
                animator.SetFloat("MoveY", 1);
            }
            transform.position = position;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            rb.AddForce(new Vector2(0, Mathf.Sqrt(-2 * Physics2D.gravity.y * JumpHeight)),
                ForceMode2D.Impulse);
            jumpcount++;
            if (jumpcount == 2)
            {
                jumping = true;
            }
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!firing) { 
                StartCoroutine(BowAttack());
            }
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    animator.SetBool("Bow", true);
        //    GameObject projectile = Instantiate(projectilePrefab,
        //        rb.position, Quaternion.identity);
        //    Projectile pr = projectile.GetComponent<Projectile>();
        //    pr.Launch(new Vector2(-state, 0), 300);
        //}
        //else
        //{
        //    animator.SetBool("Bow", false);
        //}
    }
    private IEnumerator BowAttack()
    {
        speed = 0;
        firing = true;
        animator.SetBool("Bow", true);
        yield return new WaitForSeconds(0.4f);
        GameObject projectile = Instantiate(projectilePrefab,
            rb.position, Quaternion.identity);
        Projectile pr = projectile.GetComponent<Projectile>();
        pr.Launch(new Vector2(-state, 0), 300);
        animator.SetBool("Bow", false);
        firing = false;
        speed = 3;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
        jumpcount = 0;
        animator.SetBool("Jump", false);
    }

}