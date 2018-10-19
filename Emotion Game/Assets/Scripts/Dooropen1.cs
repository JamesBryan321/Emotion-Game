using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropen1 : MonoBehaviour {


    public Animator animator;
    public int DoorCost;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {


		
	}
    void buyDoor (){
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            animator.SetBool("door", true);
            ScoreScript.scoreValue -= DoorCost;

        }
    }
    

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "player" && ScoreScript.scoreValue >= DoorCost){

            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                animator.SetBool("door", true);
                ScoreScript.scoreValue = ScoreScript.scoreValue -= (DoorCost);

            }

        }
    }

}
