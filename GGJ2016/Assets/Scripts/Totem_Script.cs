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

	// -1 is right
	// 1 is left
	public void explodeTotem(int direction) {
		attackSegment.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(200f * direction, 400f * direction), Random.Range(200f, 400f)));
	}

	public void deleteTotem() {
		attackSegment.SetActive (false);
		defenseSegment.SetActive (false);
		supportSegment.SetActive (false);
	}

	public void buildTotem(string attack, string defense, string support) {
		this.attack = attack;
		this.defense = defense;
		this.support = support;
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
		float boxCollidorSizeX = 0f;
		float boxCollidorSizeY = 0f;
		Vector3 spriteScaleVector;
		string asset = "";
		if (type == "sup") {
			finalYPosition = 2.5f;
			spriteScale = 0.7f;
			boxCollidorSizeX = 1.5f;
			boxCollidorSizeY = 1.5f;

			asset = support.ToLower ();
			if (support == "fox") {
				spriteScale = 0.6f;
			} else if (support == "moose") {
				boxCollidorSizeX = 2f;
				boxCollidorSizeY = 2f;
			}
		} else if (type == "def") {
			finalYPosition = 1.5f;
			spriteScale = 0.3f;
			asset = type + "_" + defense.ToLower ();
			boxCollidorSizeX = 2.5f;
			boxCollidorSizeY = 3.2f;
		} else if (type == "att") {
			finalYPosition = 0.5f;
			spriteScale = 0.3f;
			asset = type + "_" + attack.ToLower ();
			boxCollidorSizeX = 2.5f;
			boxCollidorSizeY = 3.2f;
		}
		segment.GetComponent<BoxCollider2D> ().size = new Vector2 (boxCollidorSizeX, boxCollidorSizeY);
		spriteScaleVector = new Vector3 (spriteScale, spriteScale, spriteScale);

		string totemFileLoc = "Sprites/TotemFaces/";
		Sprite sprite = Resources.Load <Sprite> (totemFileLoc + asset);

		segment.GetComponent<SpriteRenderer>().sprite = sprite;

		segment.transform.localScale = spriteScaleVector;

		float startingYPosition = finalYPosition + 0.25f;

		segment.transform.localPosition = new Vector3(0, 
			startingYPosition, // set height based on level
			0);
		segment.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
