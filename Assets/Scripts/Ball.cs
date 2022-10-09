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
        if(!hasStarted  && Input.GetMouseButtonUp(0))
        {
            StartBounce();
            hasStarted = true; 
        }
    }

    void StartBounce() {
        float x = Random.Range(-1f, 1f);
        Vector2 randomDirection = new Vector2(x, 1f);
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
            int bounceAngle = FindAngle();
            Vector2 hitDirection = new Vector2(Mathf.Cos((Mathf.PI / 180) * bounceAngle), 1).normalized;
            rb.velocity = hitDirection * bounceForce;
            
        }

    }

    private int FindAngle() {
        float BallPos = transform.position.x;
        float PaddlePos = GameObject.FindGameObjectWithTag("Paddle").transform.position.x;
        float meetPoint = PaddlePos - BallPos;
        float paddleLength = GameObject.FindGameObjectWithTag("Paddle").transform.localScale.x;

        float quad = 0;
        // var quadrant = paddleLength/8;
        if(meetPoint < 0) {
            meetPoint = -meetPoint;
            quad = 90 - (meetPoint / (paddleLength / 2) * 70);
        }
        else {
            quad = 90 + (meetPoint / (paddleLength / 2) * 70);
        }
        Debug.Log("Bounce Angle: " + quad.ToString());
        Debug.Log("Meet Point: " + meetPoint.ToString());
                
        return (int) quad;
    }
}
