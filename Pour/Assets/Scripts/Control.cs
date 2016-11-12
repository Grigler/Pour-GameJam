using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	enum e_State
	{
		Pause,
		Play,
		Drink
	}
		
	public bool isEndless;
	public int endlessLevelCount = 1;

	public const float DRUNK_SCALE_INCREMENT = 0.5f;
	public float m_drunkScale;

	public float GoalPercentage;
	private float CurrentPercentage; 

	private const float MAX_DROPLETS_IN_GLASS = 119; //THIS WILL HAVE TO BE CHANGED WITH ADAMS NEW DROPLETS

	private Spout spout;
	public float spoutPourTime;
	public List<GameObject> DropletList = new List<GameObject> (); //Added to in spout script

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
				
				spout.TurnOff ();
				if (HasWon()) {

					if (isEndless) 
					{
						EndlessRunIncrement ();
						break;
					}

					gameState = e_State.Drink;
					break;
				}
				else
				{
					if (isEndless)
						LoseEndless ();
					else
						LoseNormal ();
				}
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
		if (gameState == e_State.Play)
		{
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
		float numInGlass = 0;

		const float IN_GLASS_DISTANCE = 1f;

		foreach (var i in DropletList)
		{
			if (i != null) 
			{
				if (Vector2.Distance (glass.transform.position, i.transform.position) <= IN_GLASS_DISTANCE) {
					numInGlass++;
				}
			}
		}

		Debug.Log ((((numInGlass / MAX_DROPLETS_IN_GLASS) * 100f)) + "%");
		//Debug.Log(numInGlass);
		return (numInGlass / MAX_DROPLETS_IN_GLASS) * 100f;
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
	void LoseNormal()
	{
		//Do some losing stuff
	}

	void LoseEndless()
	{
		//Do some other losing stuff
	}


	void EndlessRunIncrement()
	{
		//reset glass and droplets

		//Switch glass or pour type?
		//Increse DrunkenNess

		foreach (GameObject i in DropletList)
		{
			if(i != null)
				i.GetComponent<Droplet> ().Kill ();
		}

		DropletList.Clear ();

		//player.transform.position = player.GetComponent<CameraUpdate> ().InitialPosition;  <-- Breaks shit

		//Visually Indicate new round

		m_drunkScale += DRUNK_SCALE_INCREMENT;

		spoutPourTime = 20f;

		endlessLevelCount++;

		spout.TurnOn ();
	}

	float GetDrunkForceValue()
	{
		return Random.Range (-m_drunkScale, m_drunkScale);
	}
}
