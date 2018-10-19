using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorshot_open : MonoBehaviour {

    public Animator animator1;

    public GameObject door;

    // Use this for initialization
    void Start () {
        animator1 = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "player")
        {
            animator1.SetBool("door", true);
        }
    }

}

