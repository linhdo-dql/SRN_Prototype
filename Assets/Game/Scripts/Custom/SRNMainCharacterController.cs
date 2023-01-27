using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRNMainCharacterController : MonoBehaviour
{
    private bool isCompleteAttacked = true;

    private int countTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyWeapon") && isCompleteAttacked) 
        {
            print(other.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isCompleteAttacked = false;
    }

    private void OnTriggerExit(Collider other)
    { 
        countTrigger++;
        if (other.CompareTag("EnemyWeapon"))
        {
           isCompleteAttacked = true;
        }
    }
}
