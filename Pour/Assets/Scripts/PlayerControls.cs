using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	private Rigidbody rb; 


	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	//used to start the pour on the level
	public void StartPour()
	{
		Touch myTouch = Input.GetTouch (0);

		if (Input.touchCount > 0) 
		{
			/*if (pour hasnt started)
			{
				Start pour
			}
			else
			{
				break; 
			}*/
		}
	}

	public void PhoneTilt ()
	{
		Input.acceleration.x;
	}
}