using UnityEngine;
using System.Collections;

public class simulation : MonoBehaviour {

	public bool totemsChosen = false;

	public string p1Attack;
	public string p1Defense;

	public string p2Attack;
	public string p2Defense;
	
	public bool player1Attacks;
	public bool player2Attacks;
	public int result;


	// Use this for initialization
	void Start () {
		Debug.Log ("Simulation started");
	}
	
	// Update is called once per frame
	void Update () {
		if (totemsChosen == true) {
			Debug.Log ("Totems have been chosen");

			player1Attacks = simulateAttack (p1Attack, p2Defense);
			player2Attacks = simulateAttack (p2Attack, p1Defense);
			totemsChosen = false;

			//who wins
			//return integer 0 = tie, 1 = player1 wins , 2 = player2  wins 
			if(player1Attacks == true && player2Attacks == true){
				result = 0;
			} else if(player1Attacks == true && player2Attacks == false){
				result = 1;
			} else if(player1Attacks == false && player2Attacks == true){
				result = 2;
			} else{
				result = 0;
			}
		}
	}
	// 
	bool simulateAttack(string attack, string defense){
		Debug.Log ("Simulating attack: " + attack + " against defense: " + defense);
		bool win;

		switch (attack) {
		case "fire":
			win = fireAttack(defense);
			break;
		case "water":
			win = waterAttack(defense);
			break;
		case "earth":
			win = earthAttack(defense);
			break;
		case "metal":
			win = metalAttack(defense);
			break;
		case "wood":
			win = woodAttack(defense);
			break;
		}
		return win;
	}

	bool fireAttack(string defense){
		if (defense == "metal") {
			return true;
		} else if (defense == "wood") {
			return true;
		} else if (defense == "fire") {
			return true;
		} else{
			return false;
		}
	}

	bool waterAttack(string defense){
		if (defense == "fire") {
			return true;
		} else if (defense == "metal") {
			return true;
		} else if (defense == "water") {
			return true;
		} else{
			return false;
		}
	}

	bool metalAttack(string defense){
		if (defense == "wood") {
			return true;
		} else if (defense == "earth") {
			return true;
		} else if (defense == "metal") {
			return true;
		} else{
			//fire
			return false;
		}
	}

	bool earthAttack(string defense){
		if (defense == "water") {
			return true;
		} else if (defense == "fire") {
			return true;
		} else if (defense == "earth") {
			return true;
		} else{
			//wood
			return false;
		}
	}

	bool woodAttack(string defense){
		if (defense == "earth") {
			return true;
		} else if (defense == "water") {
			return true;
		} else if (defense == "wood") {
			return true;
		} else{
			//metal
			return false;
		}
	}


}
