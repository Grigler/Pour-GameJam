using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	enum e_State
	{
		Pause,
		Play,
		Drink
	}



	private float m_drunkScale;

	public float GoalPercentage;
	private float CurrentPercentage; 

	private const int MAX_DROPLETS_IN_GLASS = 500; //CHANGE THIS VALUE, WORK IT OUT!

	private Spout spout;
	public float spoutPourTime;
	public ArrayList DropletList; //Added to in spout script

	private e_State gameState = e_State.Play;

	// Use this for initialization
	void Start () {
		spout = GameObject.FindGameObjectWithTag ("Spout").GetComponent<Spout>();
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

			if(spoutPourTime <= 0)
			{
				spout.TurnOff ();
				if (HasWon ())
					gameState = e_State.Drink;
				else
					Lose ();
			}
				

			break;
		case e_State.Drink:
			
			//wtf are we doing here?

			break;
			
		}

	}

	float CalculateCurrentPercentageInGlass()
	{
		GameObject glass = GameObject.FindGameObjectWithTag ("Player");
		int numInGlass = 0;

		const float IN_GLASS_DISTANCE = 0.4f;

		foreach (GameObject i in DropletList)
		{
			if (Vector3.Distance (glass.transform.position, i.transform.position) < IN_GLASS_DISTANCE)
				numInGlass++;
		}


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
}
