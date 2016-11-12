using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	enum e_State
	{
		Pause,
		Play,
		Drink
	}
		
	public float m_drunkScale;

	public float GoalPercentage;
	private float CurrentPercentage; 

	private const int MAX_DROPLETS_IN_GLASS = 500; //CHANGE THIS VALUE, WORK IT OUT!

	private Spout spout;
	public float spoutPourTime;
	public ArrayList DropletList = new ArrayList (); //Added to in spout script

	private GameObject player;

	private e_State gameState = e_State.Play;

	// Use this for initialization
	void Start () {
		spout = GameObject.FindGameObjectWithTag ("Spout").GetComponent<Spout>();
		player = GameObject.FindGameObjectWithTag ("Player");
		StartGame ();
	}

	// Update is called once per frame
	void Update () {

		switch(gameState)
		{
		case e_State.Pause:

			//Waiting

			break;
		case e_State.Play:

			spoutPourTime -= Time.deltaTime;

			if (spoutPourTime <= 0) {
				Debug.Log ("Off");
				spout.TurnOff ();
				if (HasWon ()) {
					Debug.Log (HasWon ());
					gameState = e_State.Drink;
					break;
				} else
					Lose ();
			}

			//player.GetComponent<CameraUpdate> ().UpdateCamera (GetDrunkForceValue(), Input.acceleration.x);

			break;
		case e_State.Drink:
			
			//Do some shit here Rhys

			break;
			
		}

	}

	void FixedUpdate()
	{
		if (gameState == e_State.Play) {
			player.GetComponent<CameraUpdate> ().UpdateCamera (GetDrunkForceValue (), Input.acceleration.x);
			if(Input.GetKey(KeyCode.LeftArrow))
				player.GetComponent<CameraUpdate> ().UpdateCamera (GetDrunkForceValue (), -1f);
			else if(Input.GetKey(KeyCode.RightArrow))
				player.GetComponent<CameraUpdate> ().UpdateCamera (GetDrunkForceValue (), 1f);
		}
	}


	float CalculateCurrentPercentageInGlass()
	{
		GameObject glass = GameObject.FindGameObjectWithTag ("Player");
		int numInGlass = 0;

		const float IN_GLASS_DISTANCE = 0.4f;

		foreach (GameObject i in DropletList)
		{
			if(i != null)
				if (Vector3.Distance (glass.transform.position, i.transform.position) < IN_GLASS_DISTANCE)
					numInGlass++;
		}

		Debug.Log ((numInGlass / MAX_DROPLETS_IN_GLASS) * 100);
		return (numInGlass / MAX_DROPLETS_IN_GLASS) * 100;
	}

	bool HasWon()
	{
		if (CalculateCurrentPercentageInGlass() >= GoalPercentage)
			return true;
		else
			return false;
	}

	public void StartGame()
	{
		gameState = e_State.Play;
		spout.TurnOn ();
	}
	void Lose()
	{
		//Do some losing stuff
	}
		

	float GetDrunkForceValue()
	{
		return Random.Range (-m_drunkScale, m_drunkScale);
	}
}
