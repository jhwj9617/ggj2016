using UnityEngine;
using System.Collections;

public class Totem_Script : MonoBehaviour {
	private string attack = null;
	private string defense = null;
	private string support = null;

	public GameObject attackSegment;
	public GameObject defenseSegment;
	public GameObject supportSegment;

	private int damageTaken;

	private const string attackCode = "att";
	private const string defenseCode = "def";
	private const string supportCode = "sup";
	private const string placeholderCode = "pla";

	private int placeholderLevel = 0;

	public AudioSource totemDropAudio;
	public AudioSource stoneAudio;
	public AudioSource animalAudio;


	// Use this for initialization
	void Start () {
	}

	void Update () {
	}

	// -1 is right
	// 1 is left
	public void getHit() {
		StartCoroutine (this.hitAnimation ());
	}

	private IEnumerator hitAnimation() {
		float wait = 0.2f;
		supportSegment.SetActive (false);
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (true);
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (false);
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (true);
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (false);
		yield return new WaitForSeconds(wait);
		supportSegment.SetActive (true);
	}

	public void explodeTotem(int direction) {
		float forceFactor = 7f;
		float force = damageTaken * forceFactor * direction;
		defenseSegment.GetComponent<Rigidbody2D> ().AddForce(new Vector2(force, force));
	}

	public void deleteTotem() {
		attackSegment.SetActive (false);
		defenseSegment.SetActive (false);
		supportSegment.SetActive (false);
	}

	public void addPlaceholder() {
		stoneAudio.Play();
		if (placeholderLevel == 0) {
			attackSegment.SetActive (true);
			addSegment(placeholderCode, attackSegment);
		} else if (placeholderLevel == 1) {
			defenseSegment.SetActive (true);
			addSegment(placeholderCode, defenseSegment);
		} else if (placeholderLevel == 2) {
			supportSegment.SetActive (true);
			addSegment(placeholderCode, supportSegment);
		}
		placeholderLevel += 1;
	}

	public void buildTotem(string attack, string defense, string support, int damageTaken) {
		attackSegment.SetActive (false);
		defenseSegment.SetActive (false);
		supportSegment.SetActive (false);
		placeholderLevel = 0;
		this.attack = attack;
		this.defense = defense;
		this.support = support;
		this.damageTaken = Mathf.Max(damageTaken, 0);
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
		totemDropAudio.Play ();

		animalAudio.clip = Resources.Load("Audio/" + this.support) as AudioClip;
		animalAudio.Play();
	}

	void buildAttack() {
		addSegment(attackCode, attackSegment);
	}

	void buildDefense() {
		addSegment(defenseCode, defenseSegment);
	}

	void buildSupport() {
		addSegment(supportCode, supportSegment);
	}

	private void addSegment(string type, GameObject segment) {
		float finalYPosition = 0f;
		float spriteScale = 1f;
		float boxCollidorSizeX = 0f;
		float boxCollidorSizeY = 0f;
		Vector3 spriteScaleVector;
		string asset = "";
		if (type == supportCode) {
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
		} else if (type == defenseCode) {
			finalYPosition = 1.5f;
			spriteScale = 0.3f;
			asset = type + "_" + defense.ToLower ();
			boxCollidorSizeX = 2.5f;
			boxCollidorSizeY = 3.2f;
		} else if (type == attackCode) {
			finalYPosition = 0.5f;
			spriteScale = 0.3f;
			asset = type + "_" + attack.ToLower ();
			boxCollidorSizeX = 2.5f;
			boxCollidorSizeY = 3.2f;
		} else if (type == placeholderCode) {
			finalYPosition = 0.5f + 1f * placeholderLevel;
			spriteScale = 0.3f;
			asset = "grey_totem";
			boxCollidorSizeX = 2.5f;
			boxCollidorSizeY = 3.2f;
		}
		segment.GetComponent<BoxCollider2D> ().size = new Vector2 (boxCollidorSizeX, boxCollidorSizeY);
		spriteScaleVector = new Vector3 (spriteScale, spriteScale, spriteScale);

		string totemFileLoc = "Sprites/TotemFaces/";
		Sprite sprite = Resources.Load <Sprite> (totemFileLoc + asset);

		print (totemFileLoc + asset);

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

	public GameObject getAttackSegment() {
		return attackSegment;
	}

	public GameObject getDefenseSegment() {
		return defenseSegment;
	}

	public GameObject getSupportSegment() {
		return supportSegment;
	}
}
