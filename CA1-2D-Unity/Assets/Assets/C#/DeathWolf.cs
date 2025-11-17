using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWolf : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 moveDirection;
    bool wakeUp = false;
    Transform player;
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(wakeUp == true)
        {
            if (player)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                moveDirection = direction;
                if (Mathf.Approximately(moveDirection.x, 1f))
                {
                    animator.SetFloat("MoveX", 1);
                    animator.SetFloat("MoveY", 0);
                }
                else if (Mathf.Approximately(moveDirection.x, -1f))
                {
                    animator.SetFloat("MoveX", -1);
                    animator.SetFloat("MoveY", 0);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if(wakeUp == true)
        {
            if (player)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            }
        }
    }
    public void wakeUpWolf()
        {
        wakeUp = true;
    }
}
