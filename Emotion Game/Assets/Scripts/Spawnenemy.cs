using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{
    public float Timer = 2;


    public GameObject enemy;
    public Transform spawn;
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Instantiate(enemy, spawn);
            Timer = 4f;
        }



    }
}
