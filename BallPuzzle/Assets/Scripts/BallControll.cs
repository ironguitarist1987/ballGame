using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallControll : MonoBehaviour {


	bool isInAir = false;
	float rotationSpeed = 350;
	float jumpHeight = 8;
	float boostSpeed = 10;
	private int boost = 3;
	public Text boostTest;
	public Text timerText;
	private float timer = 10;

	// Use this for initialization
	void Start () {
		boost = 3;
		boostTest.text = "Boost: " + boost.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		timerText.text = "Timer: " + timer.ToString();
		if(boost < 3)
		{
			if (timer <= 0)
			{
				boost++;
				boostTest.text = "Boost: " + boost.ToString();
				timer = 10;
			}
		}
		//**************************** Move horizontally
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		GetComponent<Rigidbody>().AddRelativeTorque (Vector3.back * rotation);

		if(Input.GetKeyDown(KeyCode.Space) && !isInAir){
			Vector3 v = GetComponent<Rigidbody>().velocity;
			v.y = jumpHeight;
			GetComponent<Rigidbody>().velocity = v;
		}

		if((Input.GetKeyDown(KeyCode.W)) && (GetComponent<Rigidbody>().velocity.magnitude < 20) && (boost > 0)){
			boost--;
			boostTest.text = "Boost: " + boost.ToString();
			Vector3 v = GetComponent<Rigidbody>().velocity;
			float m = GetComponent<Rigidbody>().velocity.magnitude;
			v.x = (v.x / m) * (m + boostSpeed);
			v.y = (v.y / m) * (m + boostSpeed);
			v.z = (v.z / m) * (m + boostSpeed);
			GetComponent<Rigidbody>().velocity = v;
		}
	
	}

	void OnCollisionStay()
	{
		isInAir = false;
	}

	void OnCollisionExit()
	{
		isInAir = true;
	}
}
