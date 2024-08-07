using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class diceScript : MonoBehaviour
{
    public int value;
    public bool selected; // true when want to roll, false when not wanting to roll
    public Sprite[] unselectedSides;
    public Sprite[] selectedSides;
    public SpriteRenderer rend;
    public GameObject logic;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        value=1;
        selected=true;
    }

    public void OnMouseDown() {
        if (logic.GetComponent<gameLogic>().turns==1 || logic.GetComponent<gameLogic>().turns==2) {
            if (selected) {
                selected = false;
                rend.sprite=unselectedSides[value-1];
            } else {
                selected=true;
                rend.sprite=selectedSides[value-1];
            }
        }
    }

    public void roll() {
        if (selected) {
            value=UnityEngine.Random.Range(1,7);
            rend.sprite=selectedSides[value-1];
        }
        
    }

    public void Reset() {
        selected=true;
        rend.sprite=selectedSides[value-1];
    }

}
