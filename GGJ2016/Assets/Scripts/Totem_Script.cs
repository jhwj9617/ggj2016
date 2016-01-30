using UnityEngine;
using System.Collections;

public class Totem_Script : MonoBehaviour {
    private string attack = null;
    private string defense = null;
    private string support = null;

    private GameObject attackSegment;
    private GameObject defenseSegment;
    private GameObject supportSegment;

    // Use this for initialization
    void Start () {
    
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.Z)){
            buildAttack();
        }
        if (Input.GetKeyUp(KeyCode.X)){
            buildDefense();
        }
        if (Input.GetKeyUp(KeyCode.C)){
            buildSupport();
        }
    }

    void buildAttack() {
        addSegment("AttackSegment", attackSegment);
    }

    void buildDefense() {
        addSegment("DefenseSegment", defenseSegment);
    }

    void buildSupport() {
        addSegment("SupportSegment", supportSegment);
    }

    private void addSegment(string name, GameObject segment, int level) {
        segment = new GameObject(name);
        SpriteRenderer renderer = segment.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load <Sprite> ("Sprites/Square");
        segment.transform.parent = transform;
        segment.transform.position = new Vector3(transform.position.x, 
            segment.GetComponent<Renderer>().bounds.size.y * level, // set height based on level
            0);
    }

    void setAttack(string attack) {
        this.attack = attack;
    }

    void setDefense(string defense) {
        this.defense = defense;
    }

    void setSupport(string support) {
        this.support = support;
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
