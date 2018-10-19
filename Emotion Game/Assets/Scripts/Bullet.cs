using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Animator animator1;
    public float Speed;


    public Transform deathLocation;
    public GameObject coin;
    public GameObject whatToSpawn;

    // Use this for initialization
    void Start()
    {
        animator1 = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * Speed * Time.deltaTime);

        Object.Destroy(gameObject, 2.0f);
    }
    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "door")
        {


            animator1.SetBool("open_door", true);
          


        }


        ScoreScript.scoreValue += 100;

        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
       
    


     
    }

}
