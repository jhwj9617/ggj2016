using UnityEngine;
using System.Collections;

public class Totem_Script : MonoBehaviour {
	private string attack = null;
	private string defense = null;
	private string support = null;

	public GameObject attackSegment;
	public GameObject defenseSegment;
	public GameObject supportSegment;

	// Use this for initialization
	void Start () {
	}

	void Update () {
	}

	public void deleteTotem() {
		attackSegment.SetActive (false);
		defenseSegment.SetActive (false);
		supportSegment.SetActive (false);
	}

	public void buildTotem(string attack, string defense) {
		this.attack = attack;
		this.defense = defense;
		StartCoroutine(this.buildTotemSequence());
	}

	private IEnumerator buildTotemSequence() {
		float wait = 0.1f;
		attackSegment.SetActive (true);
		buildAttack();
		yield return new WaitForSeconds(wait);
		defenseSegment.SetActive (true);
		buildDefense();
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (true);
		buildSupport();
	}

	void buildAttack() {
		addSegment("att", attackSegment);
	}

	void buildDefense() {
		addSegment("def", defenseSegment);
	}

	void buildSupport() {
		addSegment("sup", supportSegment);
	}

	private void addSegment(string type, GameObject segment) {
		float finalYPosition = 0f;
		float spriteScale = 1f;
		Vector3 spriteScaleVector;
		string asset = "";
		if (type == "sup") {
			finalYPosition = 2.5f;
			spriteScale = 0.7f;

			// RANDOMIZING SUPPORT. TODO, set asset = support.ToLower()
			int rand = Random.Range (0, 4);
			if (rand == 0) {
				asset = "dragon";
			} else if (rand == 1) {
				asset = "fox";
			} else if (rand == 2) {
				asset = "moose";
				finalYPosition += 0.2f; // += 0.2f for moose
			} else if (rand == 3) {
				asset = "oni";
			} else if (rand == 4) {
				asset = "tanuki";
			}
		} else if (type == "def") {
			finalYPosition = 1.5f;
			spriteScale = 0.3f;
			asset = type + "_" + defense.ToLower ();
		} else if (type == "att") {
			finalYPosition = 0.5f;
			spriteScale = 0.3f;
			asset = type + "_" + attack.ToLower ();
		}
		spriteScaleVector = new Vector3 (spriteScale, spriteScale, spriteScale);

		string totemFileLoc = "Sprites/TotemFaces/";
		Sprite sprite = Resources.Load <Sprite> (totemFileLoc + asset);

		segment.GetComponent<SpriteRenderer>().sprite = sprite;

		segment.transform.localScale = spriteScaleVector;

		float startingYPosition = finalYPosition + 0.25f;

		segment.transform.localPosition = new Vector3(0, 
			startingYPosition, // set height based on level
			0);
		StartCoroutine(this.moveToPosition(segment.transform, new Vector3 (0, finalYPosition, 0), 0.15f));
	}

	private IEnumerator moveToPosition(Transform transform, Vector3 position, float timeToMove) {
		var currentPos = transform.localPosition;
		var t = 0f;
		while(t < 1) {
			t += Time.deltaTime / timeToMove;
			transform.localPosition = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}

	public string getAttack() {
		return attack;
	}

	public string getDefense() {
		return defense;
	}

	public string getSupport() {
		return support;
	}
}
