using UnityEngine;
using System.Collections;

public class CameraUpdate : MonoBehaviour {

	private float m_rotation = 0.0f;
	private float m_alpha = 0.5f;

	public Vector3 InitialPosition;

	// Use this for initialization
	void Start () {
		InitialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void UpdateCamera(float _inputDrunk, float _inputPlayer)
	{
		m_rotation = Mathf.Lerp (_inputDrunk, _inputPlayer, m_alpha);

		//Scale m_rotation to an angle in the segment?

		//this.transform.RotateAround (m_rotationAnchor.position, new Vector3(0f, 0f, 1f), m_rotation);  <--- For translation

		m_rotation *= 200f;

		this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (m_rotation, 0));
	}
}
