using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour {
	
	private string p1a;
	private string p1d;
	private string p2a;
	private string p2d;
	private bool a1Ready;
	private bool a2Ready;
	private bool d1Ready;
	private bool d2Ready;
	public bool p1Ready;
	public bool p2Ready;
	public bool allReady;
	public bool CombatEnded = true;

	private float countDown;
	private string[] randomTotem = new string[5] {Const.FIRE, Const.WATER, Const.EARTH, Const.METAL, Const.WOOD};

	public GameObject TimerLabel;
	private UILabel _TimerLabel;

	public GameObject Simulation;


	// FIRE -> WOOD -> WATER -> EARTH -> METAL

	// Reset all state to false
	public void Reinitialization() {
		p1a = null;
		p1d = null;
		p2a = null;
		p2d = null;

		a1Ready = false;
		a2Ready = false;
		d1Ready = false;
		d2Ready = false;
		p1Ready = false;
		p2Ready = false;
		allReady = false;

		TimerLabel.SetActive (true);
		countDown = 20;
	}


	string chooseRandomTotem () {
		int n = randomTotem.Length;
		return randomTotem[Random.Range (0, n)] ;  

	}


	// Use this for initialization
	void Start () {
		Reinitialization (); 

		_TimerLabel = TimerLabel.GetComponent<UILabel>();

	}
		


	// Update is called once per frame
	void Update () {

		if (CombatEnded == true) {

			_TimerLabel.text = "" + (Mathf.Round(countDown));
		
			if (!allReady) {

				if (countDown <= 0) {

					TimerLabel.SetActive (false);

					// randomize totem blocks
					if (p1a == null){
						p1a = chooseRandomTotem (); 
					}
					if (p1d == null) {
						p1d = chooseRandomTotem ();
					}
					if (p2a == null) {
						p2a = chooseRandomTotem (); 
					}
					if (p2d == null) {
						p2d = chooseRandomTotem (); 
						
					}

					Debug.Log("P1a: " + p1a + " P2a: " + p2a);
					Debug.Log("P1d: " + p1d + " P2d: " + p2d);

					p1Ready = true;
					p2Ready = true;
				}

				if (countDown > 0) {

					countDown -= Time.deltaTime;

				}

				if (!p1Ready || !p2Ready) {


					// Player 1 Selections
					if (!a1Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
							p1a = Const.FIRE;
							a1Ready = true;
							print("Player1Attack = FIRE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha2)) {
							p1a = Const.WOOD;
							a1Ready = true;
							print("Player1Attack = WOOD");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha3)) {
							p1a = Const.WATER;
							a1Ready = true;
							print("Player1Attack = WATER");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha4)) {
							p1a = Const.METAL;
							a1Ready = true;
							print("Player1Attack = METAL");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha5)) {
							p1a = Const.EARTH;
							a1Ready = true;
							print("Player1Attack = EARTH");
						}

					}
					else if(!d1Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
							p1d = Const.FIRE;
							d1Ready = true;
							p1Ready = true;
							print("Player1Defense = FIRE, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha2)) {
							p1d = Const.WOOD;
							d1Ready = true;
							p1Ready = true;
							print("Player1Defense = WOOD, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha3)) {
							p1d = Const.WATER;
							d1Ready = true;
							p1Ready = true;
							print("Player1Defense = WATER, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha4)) {
							p1d = Const.METAL;
							d1Ready = true;
							p1Ready = true;
							print("Player1Defense = METAL, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha5)) {
							p1d = Const.EARTH;
							d1Ready = true;
							p1Ready = true;
							print("Player1Defense = EARTH, Player 1 Ready");
						}

					}


					// Player 2 Selections
					if (!a2Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha6)) {
							p2a = Const.FIRE;
							a2Ready = true;
							print("Player2Attack = FIRE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha7)) {
							p2a = Const.WOOD;
							a2Ready = true;
							print("Player2Attack = WOOD");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha8)) {
							p2a = Const.WATER;
							a2Ready = true;
							print("Player2Attack = WATER");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha9)) {
							p2a = Const.METAL;
							a2Ready = true;
							print("Player2Attack = METAL");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha0)) {
							p2a = Const.EARTH;
							a2Ready = true;
							print("Player2Attack = EARTH");
						}

					}
					else if (!d2Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha6)) {
							p2d = Const.FIRE;
							d2Ready = true;
							p2Ready = true;
							print("Player2Defense = FIRE, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha7)) {
							p2d = Const.WOOD;
							d2Ready = true;
							p2Ready = true;
							print("Player2Defense = WOOD, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha8)) {
							p2d = Const.WATER;
							d2Ready = true;
							p2Ready = true;
							print("Player2Defense = WATER, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha9)) {
							p2d = Const.METAL;
							d2Ready = true;
							p2Ready = true;
							print("Player2Defense = METAL, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha0)) {
							p2d = Const.EARTH;
							d2Ready = true;
							p2Ready = true;
							print("Player2Defense = EARTH, Player 2 Ready");
						}

					}
				} 
				else if (p1Ready && p2Ready) {
					allReady = true;
					TimerLabel.SetActive (false);
					print("Both players ready");
				}
			}
			else {
				// send attack and defense to simulation
			}
		}
	}
	
}
