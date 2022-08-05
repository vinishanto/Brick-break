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
    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
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
            // GameManager.instance.score++;
        }

    }
}
