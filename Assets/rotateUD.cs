using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateUD : MonoBehaviour
{
	public Rigidbody RB;
	public float rotateSpeedUD = 5.0F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float curSpeedRH = rotateSpeedUD * Input.GetAxis("RotateVertical");
		transform.Rotate((float)-0.05 * curSpeedRH,0,0);
    }
}
