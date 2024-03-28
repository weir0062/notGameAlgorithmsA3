using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public int hp = 2;

    public void takehit()
    {
        hp--;
        Debug.Log(hp);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(hp <= 0)
        
        {
            gameObject.SetActive(false);
            Destroy(this);
        }   
    }
}
