using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpFront : MonoBehaviour
{
	public float jumpSpeed = 7.5F;
	private bool Colliding = false;
	public Rigidbody RB;
	public GameObject GO;
	private bool canJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		jumpSpeed = GO.GetComponent<movementScript>().JumpSpeed;
		canJump = GO.GetComponent<movementScript>().canJump;
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		if (Input.GetKeyDown(KeyCode.Space) && canJump == false && Colliding == true){
			GO.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
			GO.GetComponent<Rigidbody>().AddForce(5 * forward * jumpSpeed, ForceMode.Force);
		}
    }
	void OnCollisionStay(Collision other){
		Colliding = true;
	}
	
	void OnCollisionExit(Collision other){
		Colliding = false;
	}
}
