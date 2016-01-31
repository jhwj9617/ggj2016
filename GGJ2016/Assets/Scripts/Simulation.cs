﻿using UnityEngine;
using System.Collections;

public class Simulation : MonoBehaviour {

	public bool totemsChosen = false;

	public string p1Attack;
	public string p1Defense;

	public string p2Attack;
	public string p2Defense;

	public string p1Animal;
	public string p2Animal;

	public int highDamage = 30;
	public int mediumDamage = 20;
	public int lowDamage = 10;
	public int noDamage = 0;

	public int p1BaseDamageTaken;
	public int p2BaseDamageTaken;
	
	public int p1DamageReflected;
	public int p2DamageReflected;
	
	public int p1DamageTaken;
	public int p2DamageTaken;
	
	public int p1DamageReduced;
	public int p2DamageReduced;
	
	public int p1Heal;
	public int p2Heal;

	//public bool player1Wins;
	//public bool player2Wins;
	//public int result;

	//public bool win;

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
		p1TotemScript = player1Totem.GetComponent<Totem_Script>();
		p2TotemScript = player2Totem.GetComponent<Totem_Script>();
		selectionScript = UiSelectionController.GetComponent<SelectionScript>();
	}

	// Update is called once per frame
	void Update () {
		if (totemsChosen == true) {
			Debug.Log ("Totems have been chosen");

			totemsChosen = false;
			
			//How much each player is being damaged
			p1BaseDamageTaken = onAttack(p2Attack, p1Defense, p2Animal);
			p2BaseDamageTaken = onAttack(p1Attack, p2Defense, p1Animal);
			
			Debug.Log ("Player1 is being damaged initially :"+ p1BaseDamageTaken);
			Debug.Log ("Player2 is being damaged initially :"+ p2BaseDamageTaken);
			
			
			//Apply damage reduction based on player's animal
			
			//dragon
			p1DamageTaken = increaseDamage(p1BaseDamageTaken, p2Animal);
			p2DamageTaken = increaseDamage(p2BaseDamageTaken, p1Animal);
			
			//onni
			p1DamageReflected = reflect(p1BaseDamageTaken, p1Animal);
			p2DamageReflected = reflect(p2BaseDamageTaken, p2Animal);
			
			p1DamageTaken = p1DamageTaken + p2DamageReflected;
			p2DamageTaken = p2DamageTaken + p1DamageReflected;
			//evasion
			//fox
			p1DamageTaken = evasion(p1DamageTaken, p1Animal);
			p2DamageTaken = evasion(p2DamageTaken, p2Animal);
			//reduce damage
			// tanuki
			p1DamageReduced = reduceDamage(p1BaseDamageTaken, p1Animal);
			p2DamageReduced = reduceDamage(p2BaseDamageTaken, p2Animal);
			
			// update Damage
			p1DamageTaken = p1DamageTaken - p1DamageReduced;
			p2DamageTaken = p2DamageTaken - p2DamageReduced;
			
			//heal 
			// moose
			p1Heal = heal(p1Animal);
			p2Heal = heal(p2Animal);
			
			p1DamageTaken = p1DamageTaken - p1Heal;
			p2DamageTaken = p2DamageTaken - p2Heal;
			
			Debug.Log ("Player1 taking:"+p1DamageTaken);
			Debug.Log ("Player2 taking:" +p2DamageTaken);
//			//player1Wins = simulateAttack (p1Attack, p2Defense);
//			//player2Wins = simulateAttack (p2Attack, p1Defense);
//			totemsChosen = false;
//
//			//who wins
//			//return integer 0 = tie, 1 = player1 wins , 2 = player2  wins 
//			if(player1Wins == true && player2Wins == true){
//				result = 0;
//			} else if(player1Wins == true && player2Wins == false){
//				result = 1;
//			} else if(player1Wins == false && player2Wins == true){
//				result = 2;
//			} else{
//				result = 0;
//			}

			selectionScript.P1DmgTaken = p1DamageTaken;
			selectionScript.P2DmgTaken = p2DamageTaken;
			selectionScript.WhoWon();

			// Animation
			p1TotemScript.buildTotem(p1Attack, p1Defense, p1Animal);
			p2TotemScript.buildTotem(p2Attack, p2Defense, p2Animal);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			p1TotemScript.deleteTotem();
			p2TotemScript.deleteTotem();
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			p1TotemScript.explodeTotem(1);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			p2TotemScript.explodeTotem(-1);
		}
	}

	public int heal(string animal){
		int restoreHP = 0;
		if(animal == "MOOSE")
		{
			Debug.Log ("MOOSE = HEALED");
			restoreHP = 10;
		}
		return restoreHP;
	}
	
	public int reduceDamage( int baseDamage, string animal)
	{
		int damageReduction = 0;
		if(animal == "TANUKI")
		{
			if(baseDamage >= 20){
				Debug.Log ("TANUKI = DAMAGE REDUCED");
				damageReduction = 20;
			} else if(baseDamage == 10){
				damageReduction = -20;
			}
		}
		return damageReduction;
	}
	
	public int reflect(int baseDamageTaken, string animal)
	{
		double reflectedDamage = 0;
		//if baseDamage >= 30 it is super effective
		if((animal == "ONI") && (baseDamageTaken >= 30)) {
			Debug.Log ("ONI = reflect damage");
			reflectedDamage = baseDamageTaken * 0.5;
		}
		return (int)System.Math.Ceiling(reflectedDamage);
	}
	
	public int evasion(int damageTaken, string animal)
	{
		if(animal == "FOX"){
			float percentage = Random.Range (0f, 1f);
			if (percentage <= 0.2) {
				Debug.Log ("FOX = EVADE");
				damageTaken = 0;
			}
		}
		return damageTaken;
	}
	
	
	public int increaseDamage(int baseDamage, string animal)
	{
		if(animal == "DRAGON")
		{
			float percentage = Random.Range (0f, 1f);
			if (percentage <= 0.2) {
				Debug.Log ("DRAGON = increase damage");
				baseDamage = (int)(baseDamage * 1.5);
			}
		}
		return baseDamage;
	}

	public int onAttack(string attack,string defence,string animal){
		int damage = 0;
		switch (attack) {
		case "FIRE":
			damage = fireAttack(defence);
			break;
		case "WATER":
			damage = waterAttack(defence);
			break;
		case "EARTH":
			damage = earthAttack(defence);
			break;
		case "METAL":
			damage = metalAttack(defence);
			break;
		case "WOOD":
			damage = woodAttack(defence);
			break;
		}
		return damage;
	}

//	bool simulateAttack(string attack, string defense){
//		Debug.Log ("Simulating attack: " + attack + " against defense: " + defense);
//
//		// LIMITATION of switch statements - cannot have evaluated statements for cases. 
//		// See Const.cs for referenced constants
//		switch (attack) {
//		case "FIRE":
//			win = fireAttack(defense);
//			break;
//		case "WATER":
//			win = waterAttack(defense);
//			break;
//		case "EARTH":
//			win = earthAttack(defense);
//			break;
//		case "METAL":
//			win = metalAttack(defense);
//			break;
//		case "WOOD":
//			win = woodAttack(defense);
//			break;
//		}
//		return win;
//	}

//	bool fireAttack(string defense){
//		if (defense == Const.METAL) {
//			return true;
//		} else if (defense == Const.WOOD) {
//			return true;
//		} else if (defense == Const.FIRE) {
//			return true;
//		} else{
//			return false;
//		}
//	}
//
//	bool waterAttack(string defense){
//		if (defense == Const.FIRE) {
//			return true;
//		} else if (defense == Const.METAL) {
//			return true;
//		} else if (defense == Const.WATER) {
//			return true;
//		} else{
//			return false;
//		}
//	}
//
//	bool metalAttack(string defense){
//		if (defense == Const.WOOD) {
//			return true;
//		} else if (defense == Const.EARTH) {
//			return true;
//		} else if (defense == Const.METAL) {
//			return true;
//		} else{
//			//fire
//			return false;
//		}
//	}
//
//	bool earthAttack(string defense){
//		if (defense == Const.WATER) {
//			return true;
//		} else if (defense == Const.FIRE) {
//			return true;
//		} else if (defense == Const.EARTH) {
//			return true;
//		} else{
//			//wood
//			return false;
//		}
//	}
//
//	bool woodAttack(string defense){
//		if (defense == Const.EARTH) {
//			return true;
//		} else if (defense == Const.WATER) {
//			return true;
//		} else if (defense == Const.WOOD) {
//			return true;
//		} else{
//			//metal
//			return false;
//		}
//	}

	public int fireAttack(string defense){
		if (defense == Const.METAL) {
			return highDamage;
		} else if (defense == Const.WOOD) {
			return mediumDamage;
		} else if (defense == Const.FIRE) {
			return lowDamage;
		} else{
			return noDamage;
		}
	}
	
	public int waterAttack(string defense){
		if (defense == Const.FIRE) {
			return highDamage;
		} else if (defense == Const.METAL) {
			return mediumDamage;
		} else if (defense == Const.WATER) {
			return lowDamage;
		} else{
			return noDamage;
		}
	}
	
	public int metalAttack(string defense){
		if (defense == Const.WOOD) {
			return highDamage;
		} else if (defense == Const.EARTH) {
			return mediumDamage;
		} else if (defense == Const.METAL) {
			return lowDamage;
		} else{
			return noDamage;
		}
	}
	
	public int earthAttack(string defense){
		if (defense == Const.WATER) {
			return highDamage;
		} else if (defense == Const.FIRE) {
			return mediumDamage;
		} else if (defense == Const.EARTH) {
			return lowDamage;
		} else{
			return noDamage;
		}
	}
	
	public int woodAttack(string defense){
		if (defense == Const.EARTH) {
			return highDamage;
		} else if (defense == Const.WATER) {
			return mediumDamage;
		} else if (defense == Const.WOOD) {
			return lowDamage;
		} else{
			return noDamage;
		}
	}
}
