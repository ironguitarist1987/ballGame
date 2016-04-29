using UnityEngine;
using System.Collections;

public class cubePickup : MonoBehaviour {

	private float rotation = 0.25f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 v= new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.RotateAround(transform.position, v, rotation);
		//rotation += 0.1f;


	}

	void OnTriggerEnter(Collider info)
	{
		if (info.tag == "Sphere") {
			Debug.Log ("Test");

			Destroy (gameObject);
		}
	}
}
