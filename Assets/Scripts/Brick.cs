using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class Brick : MonoBehaviour
{
    private Explodable _explodable;
    // Start is called before the first frame update;
    void Start()
    {
        GameManager.instance.brickCount++;
        _explodable = GetComponent<Explodable>();
    }

    void OnDestroy()
    {
        GameManager.instance.brickCount--;
        // Debug.Log("On destroyed: "+ GameManager.instance.brickCount.ToString());

    }

    void onMouseDown()
    {
        _explodable.explode();
        ExplossionForce ef = GameObject.FindOBjectOfType<ExplossionForce>();
        ef.Explode(transform.position);
        // Destroy(gameObject);
        
    }
}
