using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;
    private bool hasStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!hasStarted  && Input.anyKeyDown)
        {
            StartBounce();
            hasStarted = true; 
        }
    }

    void StartBounce() {
        float x = Random.Range(-1f, 1f);
        float y = 1f;
        Debug.Log(x + " " + y);
        Vector2 randomDirection = new Vector2(x, y);
        rb.AddForce(randomDirection.normalized * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.restart();
        }
        else if(collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            // Debug.Log("Brick Destroyed: "+ GameManager.instance.brickCount.ToString());
            if(GameManager.instance.brickCount == 1)
            {
                GameManager.instance.next();
            }
            // GameManager.instance.score++;
        }

        else  if(collision.gameObject.tag == "Paddle")
        {
            float hitPosY = transform.position.y - collision.transform.position.y;

            // Vector2 newPos = new Vector2(rb.velocity.x, rb.velocity.y + hitPosY);
            rb.velocity = Quaternion.AngleAxis(0, Vector2.up);
        }

    }
}
