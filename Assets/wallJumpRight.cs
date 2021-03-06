using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumpRight : MonoBehaviour
{
	public float jumpSpeed = 7.5F;
	public bool Colliding = false;
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
		Vector3 right = transform.TransformDirection(Vector3.right);
		if (Input.GetKeyDown(KeyCode.Space)&& Colliding == true){
			GO.GetComponent<Rigidbody>().AddForce(5 * right * jumpSpeed, ForceMode.Force);
		}
    }
	void OnCollisionStay(Collision other){
		Colliding = true;
	}

	void OnCollisionEnter(Collision other){
		Colliding = true;
	}
	
	void OnCollisionExit(Collision other){
		Colliding = false;
	}
}
