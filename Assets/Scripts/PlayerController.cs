using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float jumpPower = 10.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float jump = Input.GetAxis("Jump") * jumpPower;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        jump *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        transform.Translate(0, jump, 0);
    }
}
