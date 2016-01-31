using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {

	public GameObject P1Gamble;
	public GameObject P1Heal;
	public GameObject P1Dodge;
	public GameObject P1Critical;
	public GameObject P1Reflect;

	public GameObject P2Gamble;
	public GameObject P2Heal;
	public GameObject P2Dodge;
	public GameObject P2Critical;
	public GameObject P2Reflect;

	private TweenPosition _P1HealTween;
	private TweenPosition _P2HealTween;
	private TweenPosition _P1GambleTween;
	private TweenPosition _P2GambleTween;
	private TweenPosition _P1DodgeTween;
	private TweenPosition _P2DodgeTween;
	private TweenPosition _P1CriticalTween;
	private TweenPosition _P2CriticalTween;
	private TweenPosition _P1ReflectTween;
	private TweenPosition _P2ReflectTween;

	private Vector3 p1pos = new Vector3 (-500,-62,0);
	private Vector3 p2pos = new Vector3 (500,62,0);

	// Use this for initialization
	void Start () {
	
		_P1HealTween = P1Heal.GetComponent<TweenPosition>();
		_P2HealTween = P2Heal.GetComponent<TweenPosition>();
		_P1GambleTween = P1Gamble.GetComponent<TweenPosition>();
		_P2GambleTween = P2Gamble.GetComponent<TweenPosition>();
		_P1DodgeTween = P1Dodge.GetComponent<TweenPosition>();
		_P2DodgeTween = P2Dodge.GetComponent<TweenPosition>();
		_P1CriticalTween = P1Critical.GetComponent<TweenPosition>();
		_P2CriticalTween = P2Critical.GetComponent<TweenPosition>();
		_P1ReflectTween = P1Reflect.GetComponent<TweenPosition>();
		_P2ReflectTween = P2Reflect.GetComponent<TweenPosition>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaceFloatingText ( string WhatEffect, int WhatPlayer){

		if (WhatEffect == "Gamble") {
			if (WhatPlayer == 1) {
				ShowMessage(P1Gamble);
				_P1GambleTween.Toggle();
			} else if (WhatPlayer == 2) {
				ShowMessage(P2Gamble);
				_P2GambleTween.Toggle();
			}
		} else if (WhatEffect == "Heal") {
			if (WhatPlayer == 1) {
				ShowMessage(P1Heal);
				_P1HealTween.Toggle();
			} else if (WhatPlayer == 2) {
				ShowMessage(P2Heal);
				_P2HealTween.Toggle();
			}
		} else if (WhatEffect == "Dodge") {
			if (WhatPlayer == 1) {
				ShowMessage(P1Dodge);
				_P1DodgeTween.Toggle();
			} else if (WhatPlayer == 2) {
				ShowMessage(P2Dodge);
				_P2DodgeTween.Toggle();
			}
		} else if (WhatEffect == "Critical") {
			if (WhatPlayer == 1) {
				ShowMessage(P2Critical);
				_P2CriticalTween.Toggle();
			} else if (WhatPlayer == 2) {
				ShowMessage(P1Critical);
				_P1CriticalTween.Toggle();
			}
		} else if (WhatEffect == "Reflect") {
			if (WhatPlayer == 1) {
				ShowMessage(P1Reflect);
				_P1ReflectTween.Toggle();
			} else if (WhatPlayer == 2) {
				ShowMessage(P2Reflect);
				_P2ReflectTween.Toggle();
			}
		}

	}

	void ShowMessage (GameObject Effect) {

		Effect.SetActive(true);


	}

	public void DeActivateMessage (GameObject Effect) {

		Effect.SetActive(false);

	}
}
