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

    public void buildTotem(string attack, string defense) {
		this.attack = attack;
		this.defense = defense;
        StartCoroutine(this.buildTotemSequence());
    }

    private IEnumerator buildTotemSequence() {
        float wait = 0.1f;
        buildAttack();
        yield return new WaitForSeconds(wait);
        buildDefense();
        yield return new WaitForSeconds(wait);
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
        segment = new GameObject(name);
        SpriteRenderer renderer = segment.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load <Sprite> ("Sprites/Square");

        if (level == 0) {
            renderer.color = new Color(1, 0, 0, 1); // red
        } else if (level == 1) {
            renderer.color = new Color(1, 1, 0, 1); // yellow
        } else if (level == 2) {
            renderer.color = new Color(1, 1, 1, 1); // white
        }

        segment.transform.parent = transform;

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
