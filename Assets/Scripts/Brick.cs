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

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        GameManager.instance.brickCount--;
        if(GameManager.instance.brickCount == 0)
        {
            GameManager.instance.restart();
        }
    }
}
