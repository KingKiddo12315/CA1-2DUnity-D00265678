using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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
        }
        transform.position = position;

    }
}
