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

	// FIRE -> WOOD -> WATER -> EARTH -> METAL

	// Player 1 Selection Keys
	//private bool key1 = Input.GetKey (KeyCode.Alpha1);
	//private bool key2 = Input.GetKey (KeyCode.Alpha2);
	//private bool key3 = Input.GetKey (KeyCode.Alpha3);
	//private bool key4 = Input.GetKey (KeyCode.Alpha4);
	//private bool key5 = Input.GetKey (KeyCode.Alpha5);

	// Player 2 Selection Keys
	//private bool key6 = Input.GetKey (KeyCode.Alpha6);
	//private bool key7 = Input.GetKey (KeyCode.Alpha7);
	//private bool key8 = Input.GetKey (KeyCode.Alpha8);
	//private bool key9 = Input.GetKey (KeyCode.Alpha9);
	//private bool key0 = Input.GetKey (KeyCode.Alpha0);

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
	}


	// Use this for initialization
	void Start () {
		Reinitialization (); 
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!allReady) {
			if (!p1Ready || !p2Ready) {

				// Player 1 Selections
				if (!a1Ready) {
					if (Input.GetKey (KeyCode.Alpha1)) {
						p1a = "FIRE";
						a1Ready = true;
						print("Player1Attack = FIRE");
					}
					else if (Input.GetKey (KeyCode.Alpha2)) {
						p1a = "WOOD";
						a1Ready = true;
						print("Player1Attack = WOOD");
					}
					else if (Input.GetKey (KeyCode.Alpha3)) {
						p1a = "WATER";
						a1Ready = true;
						print("Player1Attack = WATER");
					}
					else if (Input.GetKey (KeyCode.Alpha4)) {
						p1a = "METAL";
						a1Ready = true;
						print("Player1Attack = METAL");
					}
					else if (Input.GetKey (KeyCode.Alpha5)) {
						p1a = "EARTH";
						a1Ready = true;
						print("Player1Attack = EARTH");
					}

				}
				else if(!d1Ready) {
					if (Input.GetKey (KeyCode.Alpha1)) {
						p1d = "FIRE";
						d1Ready = true;
						p1Ready = true;
						print("Player1Defense = FIRE, Player 1 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha2)) {
						p1d = "WOOD";
						d1Ready = true;
						p1Ready = true;
						print("Player1Defense = WOOD, Player 1 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha3)) {
						p1d = "WATER";
						d1Ready = true;
						p1Ready = true;
						print("Player1Defense = WATER, Player 1 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha4)) {
						p1d = "METAL";
						d1Ready = true;
						p1Ready = true;
						print("Player1Defense = METAL, Player 1 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha5)) {
						p1d = "EARTH";
						d1Ready = true;
						p1Ready = true;
						print("Player1Defense = EARTH, Player 1 Ready");
					}

				}


				// Player 2 Selections
				if (!a2Ready) {
					if (Input.GetKey (KeyCode.Alpha6)) {
						p2a = "FIRE";
						a2Ready = true;
						print("Player2Attack = FIRE");
					}
					else if (Input.GetKey (KeyCode.Alpha7)) {
						p2a = "WOOD";
						a2Ready = true;
						print("Player2Attack = WOOD");
					}
					else if (Input.GetKey (KeyCode.Alpha8)) {
						p2a = "WATER";
						a2Ready = true;
						print("Player2Attack = WATER");
					}
					else if (Input.GetKey (KeyCode.Alpha9)) {
						p2a = "METAL";
						a2Ready = true;
						print("Player2Attack = METAL");
					}
					else if (Input.GetKey (KeyCode.Alpha0)) {
						p2a = "EARTH";
						a2Ready = true;
						print("Player2Attack = EARTH");
					}

				}
				else if (!d2Ready) {
					if (Input.GetKey (KeyCode.Alpha6)) {
						p2d = "FIRE";
						d2Ready = true;
						p2Ready = true;
						print("Player2Defense = FIRE, Player 2 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha7)) {
						p2d = "WOOD";
						d2Ready = true;
						p2Ready = true;
						print("Player2Defense = WOOD, Player 2 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha8)) {
						p2d = "WATER";
						d2Ready = true;
						p2Ready = true;
						print("Player2Defense = WATER, Player 2 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha9)) {
						p2d = "METAL";
						d2Ready = true;
						p2Ready = true;
						print("Player2Defense = METAL, Player 2 Ready");
					}
					else if (Input.GetKey (KeyCode.Alpha0)) {
						p2d = "EARTH";
						d2Ready = true;
						p2Ready = true;
						print("Player2Defense = EARTH, Player 2 Ready");
					}

				}
			} 
			else if (p1Ready && p2Ready) {
				allReady = true;
				print("Both players ready");
			}
		}
	}
}
