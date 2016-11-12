using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.transform.position.y < -5f) {
			Object.Destroy (gameObject);
		}

	}
}
