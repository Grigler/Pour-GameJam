using UnityEngine;
using System.Collections;

public class Spout : MonoBehaviour {
	
	public GameObject DropPrefab;
	public ArrayList DropletList;

	bool isPouring;

	private const float DROPLET_FREQUENCY = 0.05f;

	private float dropletTimer = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		dropletTimer -= Time.deltaTime;

		if (dropletTimer <= 0 && isPouring) 
		{
			CreateDroplet ();
			dropletTimer = DROPLET_FREQUENCY;
		}

	}
		
	void CreateDroplet()
	{
		GameObject tempDrop;

		Vector3 dropTrans;

		dropTrans = this.transform.position - (new Vector3 (Random.Range (-0.125f, 0.125f), 0f, -3f));

		tempDrop = Instantiate(DropPrefab, dropTrans, new Quaternion()) as GameObject;

		//GameObject.FindGameObjectWithTag("GameController").GetComponent<Control>().DropletList.Add (tempDrop);
	}

	public void TurnOn()
	{
		isPouring = true;
	}

	public void TurnOff()
	{
		isPouring = false;
	}
}
