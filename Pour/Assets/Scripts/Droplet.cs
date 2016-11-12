using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Control> ().DropletList.Add (this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.transform.position.y < -10f) {
			Object.Destroy (gameObject);
		}

	}

	public void Kill()
	{
		Object.Destroy (gameObject);
	}
}
