using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour {

	private GameObject m_camera;
	private float time = 0f;

	// Use this for initialization
	void Start () {
		m_camera  = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(time < 0)
			m_camera.GetComponent<CameraUpdate> ().UpdateCamera (Random.Range (-18f, 18f), Random.Range (-18f, 18f));

		time -= Time.deltaTime;

	}
}
