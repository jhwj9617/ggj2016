using UnityEngine;
using System.Collections;

public class simulation : MonoBehaviour {

    public bool totemsChosen = false;

    public string p1Attack;
    public string p1Defense;

    public string p2Attack;
    public string p2Defense;
    
    public bool player1Attacks;
    public bool player2Attacks;
    public int result;

    public bool win;


    // Use this for initialization
    void Start () {
        Debug.Log ("Simulation started");
    }
    
    // Update is called once per frame
    void Update () {
        if (totemsChosen == true) {
            Debug.Log ("Totems have been chosen");

            player1Attacks = simulateAttack (p1Attack, p2Defense);
            player2Attacks = simulateAttack (p2Attack, p1Defense);
            totemsChosen = false;

            //who wins
            //return integer 0 = tie, 1 = player1 wins , 2 = player2  wins 
            if(player1Attacks == true && player2Attacks == true){
                result = 0;
            } else if(player1Attacks == true && player2Attacks == false){
                result = 1;
            } else if(player1Attacks == false && player2Attacks == true){
                result = 2;
            } else{
                result = 0;
            }
        }
    }
    // 
    bool simulateAttack(string attack, string defense){
        Debug.Log ("Simulating attack: " + attack + " against defense: " + defense);

        // LIMITATION of switch statements - cannot have evaluated statements for cases. 
        // See Const.cs for referenced constants
        switch (attack) {
        case "FIRE":
            win = fireAttack(defense);
            break;
        case "WATER":
            win = waterAttack(defense);
            break;
        case "EARTH":
            win = earthAttack(defense);
            break;
        case "METAL":
            win = metalAttack(defense);
            break;
        case "WOOD":
            win = woodAttack(defense);
            break;
        }
        return win;
    }

    bool fireAttack(string defense){
        if (defense == Const.METAL) {
            return true;
        } else if (defense == Const.WOOD) {
            return true;
        } else if (defense == Const.FIRE) {
            return true;
        } else{
            return false;
        }
    }

    bool waterAttack(string defense){
        if (defense == Const.FIRE) {
            return true;
        } else if (defense == Const.METAL) {
            return true;
        } else if (defense == Const.WATER) {
            return true;
        } else{
            return false;
        }
    }

    bool metalAttack(string defense){
        if (defense == Const.WOOD) {
            return true;
        } else if (defense == Const.EARTH) {
            return true;
        } else if (defense == Const.METAL) {
            return true;
        } else{
            //fire
            return false;
        }
    }

    bool earthAttack(string defense){
        if (defense == Const.WATER) {
            return true;
        } else if (defense == Const.FIRE) {
            return true;
        } else if (defense == Const.EARTH) {
            return true;
        } else{
            //wood
            return false;
        }
    }

    bool woodAttack(string defense){
        if (defense == Const.EARTH) {
            return true;
        } else if (defense == Const.WATER) {
            return true;
        } else if (defense == Const.WOOD) {
            return true;
        } else{
            //metal
            return false;
        }
    }


}
