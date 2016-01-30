using UnityEngine;
using System.Collections;

public class OnAttack : MonoBehaviour {
	
	//if currentPlayer = player1, attack = player2 , defense = player 1
	//gets value to subtract off current player's health
	
	public bool totemsChosen = false;
	
	public string player1Attack;
	public string player2Attack;
	public string player1Defence;
	public string player2Defence;
	public string player1Animal;
	public string player2Animal;
	
	public int highDamage = 30;
	public int mediumDamage = 20;
	public int lowDamage = 10;
	public int noDamage = 0;
	
	
	public int player1Damaged;
	public int player2Damaged;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Simulation started");
	}
	
	// Update is called once per frame
	void Update () {
		if (totemsChosen == true) {
			Debug.Log ("Totems have been chosen");
			
			int baseDamage = 0;
			baseDamage = simulateAttack (enemyAttack, playerDefense);
			enhancedDamage = applyEnemyAnimal (baseDamage, enemyAnimal);
			totemsChosen = false;
			
			//How much each player is being damaged
			player1Damaged = onAttack(player2Attack, player1Defence, player2Animal);
			player2Damaged = onAttack(player1Attack, player2Defence, player1Animal);
			
			//Apply damage reduction based on player's animal
			if(player1Animal == "TANUKI") {
				player1Damaged = onDefence(player1Animal, player1Damaged);
			}
			
		}
	}
	
	
	int onAttack(string attack,string defence,string animal){
		int damage = 0;
		switch (attack) {
		case "fire":
			damage = fireAttack(defense);
			break;
		case "water":
			damage = waterAttack(defense);
			break;
		case "earth":
			damage = earthAttack(defense);
			break;
		case "metal":
			damage = metalAttack(defense);
			break;
		case "wood":
			damage = woodAttack(defense);
			break;
		}
		if(animal == "DRAGON"){
			damage = applyAttackingAnimal(animal, damage);
		}
		
		return damage;
		
	}
	
	int applyAttackingAnimal(string animal, int damage){
		if(animal == "DRAGON"){
			float percentage = Random.Range(0,1);
			if(percentage <= 0.2){
				damage = damage * 2;
			}
		}
		
		return damage;
	}
	
	int applyDefenceAnimal(string animal, int damage){
		//reduce damage by 10 only if damage is at least 10 or greater
		if(animal == "HUMAN"){
			if(damage >= 10)){
				damage -= 10;
			}
		}
	}
	
	
	
	
	int applyEnemyAnimal (int baseDamage, string animal){
		//if dragon.. rand (0-1) if < 0.3 then x2 dmg'
		Random rnd = new Random();
		if (animal == "DRAGON") {
			float percentage = Random.Range (0, 1);
			if (percentage <= 0.2) {
				baseDamage = baseDamage * 1.5;
			}
		}
		//if oni.. 
		//else nothing...
		
	}
	int simulateAttack(string attack, string defense){
		Debug.Log ("Simulating attack: " + attack + " against defense: " + defense);
		int damage = 0;
		
		switch (attack) {
		case "FIRE":
			damage = fireAttack(defense);
			break;
		case "WATER":
			damage = waterAttack(defense);
			break;
		case "EARTH":
			damage = earthAttack(defense);
			break;
		case "METAL":
			damage = metalAttack(defense);
			break;
		case "WOOD":
			damage = woodAttack(defense);
			break;
		}
		return damage;
	}
	
	int fireAttack(string defense){
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
	
	int waterAttack(string defense){
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
	
	int metalAttack(string defense){
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
	
	int earthAttack(string defense){
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
	
	int woodAttack(string defense){
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
