using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax; 
}

public class PlayerController : MonoBehaviour {
	private Rigidbody rb; 
	private Vector3 direction; 
	public float speed; 
	public Boundary boundary; 
	public float tilt; 
	public GameObject laser; 
	public Transform laserSpawn; 
	public float fireRate; 
	private float nextFire;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		//Mover the Player:	
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		direction = new Vector3 (moveH, 0.0f, moveV);
		rb.velocity = direction * speed; 


		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

//		Get laser firing:
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
		}
	}
}
