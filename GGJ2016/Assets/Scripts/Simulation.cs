using UnityEngine;
using System.Collections;

public class Simulation : MonoBehaviour {

	public bool totemsChosen = false;

	public string p1Attack;
	public string p1Defense;

	public string p2Attack;
	public string p2Defense;

	public bool player1Wins;
	public bool player2Wins;
	public int result;

	public bool win;

	public GameObject player1Totem;
	public GameObject player2Totem;
	public GameObject UiSelectionController;

	private Totem_Script p1TotemScript;
	private Totem_Script p2TotemScript;
	private SelectionScript selectionScript;

	// Use this for initialization
	void Start () {
		Debug.Log ("Simulation started");
		totemsChosen = false;
	/*	p1Attack = Const.FIRE;
		p1Defense = Const.WATER;
		p2Attack = Const.WOOD;
		p2Defense = Const.METAL;*/
		p1TotemScript = player1Totem.GetComponent<Totem_Script>();
		p2TotemScript = player2Totem.GetComponent<Totem_Script>();
		selectionScript = UiSelectionController.GetComponent<SelectionScript>();
	}

	// Update is called once per frame
	void Update () {
		if (totemsChosen == true) {
			Debug.Log ("Totems have been chosen");

			player1Wins = simulateAttack (p1Attack, p2Defense);
			player2Wins = simulateAttack (p2Attack, p1Defense);
			totemsChosen = false;

			//who wins
			//return integer 0 = tie, 1 = player1 wins , 2 = player2  wins 
			if(player1Wins == true && player2Wins == true){
				result = 0;
			} else if(player1Wins == true && player2Wins == false){
				result = 1;
			} else if(player1Wins == false && player2Wins == true){
				result = 2;
			} else{
				result = 0;
			}

			selectionScript.CombatResult = result;
			selectionScript.WhoWon();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			p1TotemScript.buildTotem(p1Attack, p1Defense);
			p2TotemScript.buildTotem(p2Attack, p2Defense);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			p1TotemScript.deleteTotem();
			p2TotemScript.deleteTotem();
		}

	}
	// 
	bool simulateAttack(string attack, string defense){
		Debug.Log ("Simulating attack: " + attack + " against defense: " + defense);

		// LIMITATION of switch statements - cannot have evaluated statements for cases. 
		// See Const.cs for referenced constants
		switch (attack) {
		case "FIRE":
			win = fireAttack(defense);
			break;
		case "WATER":
			win = waterAttack(defense);
			break;
		case "EARTH":
			win = earthAttack(defense);
			break;
		case "METAL":
			win = metalAttack(defense);
			break;
		case "WOOD":
			win = woodAttack(defense);
			break;
		}
		return win;
	}

	bool fireAttack(string defense){
		if (defense == Const.METAL) {
			return true;
		} else if (defense == Const.WOOD) {
			return true;
		} else if (defense == Const.FIRE) {
			return true;
		} else{
			return false;
		}
	}

	bool waterAttack(string defense){
		if (defense == Const.FIRE) {
			return true;
		} else if (defense == Const.METAL) {
			return true;
		} else if (defense == Const.WATER) {
			return true;
		} else{
			return false;
		}
	}

	bool metalAttack(string defense){
		if (defense == Const.WOOD) {
			return true;
		} else if (defense == Const.EARTH) {
			return true;
		} else if (defense == Const.METAL) {
			return true;
		} else{
			//fire
			return false;
		}
	}

	bool earthAttack(string defense){
		if (defense == Const.WATER) {
			return true;
		} else if (defense == Const.FIRE) {
			return true;
		} else if (defense == Const.EARTH) {
			return true;
		} else{
			//wood
			return false;
		}
	}

	bool woodAttack(string defense){
		if (defense == Const.EARTH) {
			return true;
		} else if (defense == Const.WATER) {
			return true;
		} else if (defense == Const.WOOD) {
			return true;
		} else{
			//metal
			return false;
		}
	}
}
