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
		addSegment("AttackSegment", attackSegment, 0);
	}

	void buildDefense() {
		addSegment("DefenseSegment", defenseSegment, 1);
	}

	void buildSupport() {
		addSegment("SupportSegment", supportSegment, 2);
	}

	private void addSegment(string name, GameObject segment, int level) {
		float finalYPosition = (segment.GetComponent<Renderer>().bounds.size.y / 2) + segment.GetComponent<Renderer>().bounds.size.y * level;
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
