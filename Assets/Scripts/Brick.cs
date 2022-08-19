using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.brickCount++;
    }

    void OnDestroy()
    {
        GameManager.instance.brickCount--;
        // Debug.Log("On destroyed: "+ GameManager.instance.brickCount.ToString());

    }
}
