using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLR : MonoBehaviour
{
	public float rotateSpeed = 5.0F;
	public GameObject GO;
	private Vector3 SpherePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		SpherePosition = GO.GetComponent<Transform>().position;
		transform.position = SpherePosition;
		transform.Rotate(0,0,0,Space.World);
    }
	
	void FixedUpdate()
    {
		SpherePosition = GO.GetComponent<Transform>().position;
		transform.position = SpherePosition;
		transform.Rotate(0,0,0,Space.World);
    }
}
