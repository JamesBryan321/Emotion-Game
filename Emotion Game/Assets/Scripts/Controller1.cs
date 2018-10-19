using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Controller1 : MonoBehaviour {

    public float moveSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public static int Points;
    public Text instructions;
    public Text Move;
    public Text Aim;
    public Text shoot;
    public int maxAmmo = 8;
    public int currentAmmo;
    public float reloadTime = 1f;
    public Text Ammo;

    private bool isReloading = false;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public Rigidbody myRigidBody;

    public Transform shell;
    public Transform shellEjection;

    public GunFlash flash;

    public AudioSource GunShot;
    public AudioSource Reloading;

    public bool useController;

	// Use this for initialization
	void Start () {


        flash = GetComponent<GunFlash>();
        instructions.enabled = false;
        currentAmmo = maxAmmo;
        Move.enabled = false;
        Aim.enabled = false;
        shoot.enabled = false;
		
	}
    void fire () {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Instantiate(shell, shellEjection.position, shellEjection.rotation);
        currentAmmo--;
        GunShot.Play();
     
    }
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ammo.text = "Ammo = " + currentAmmo;



        if (isReloading)
            return;

        if ( currentAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }

        if(useController){
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Rhorizontal") + Vector3.forward * -Input.GetAxisRaw("Rvertical");
            if(playerDirection.sqrMagnitude > 0.0f){
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5)){
            fire();
        }
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bed"){
            Move.enabled = true;
        }
        if (other.tag == "aim")
        {
            Aim.enabled = true;
        }
        if (other.tag == "shoot")
        {
            shoot.enabled = true;
        }
        if (other.tag == "door1")
        {
            instructions.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag =="bed"){
            Move.enabled = false;
        }
        if (other.tag == "aim")
        {
            Aim.enabled = false;
        }
        if (other.tag == "shoot")
        {
            shoot.enabled = false;
        }
        if (other.tag == "door1")
        {
            instructions.enabled = false;
        }
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;   
    }
    IEnumerator Reload(){
        isReloading = true;
        Debug.Log("Reloading");
        Reloading.Play();
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
