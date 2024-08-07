using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceScript : MonoBehaviour
{
    public bool empty;
    public bool occupiedBy0;
    public bool occupiedBy1;
    public GameObject logic;
    public gameLogic logicScript;
    public string value;
    public int[] coords={0,0};
    // Start is called before the first frame update
    void Start()
    {
        logicScript = logic.GetComponent<gameLogic>();
        occupiedBy0=(name=="freespace");
        occupiedBy1=(name=="freespace");
        empty = name!="freespace";

        foreach(char c in name) {
            if(char.IsNumber(c)) value+=c;
            else break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        logicScript.PlaceChip(gameObject);
    }
}
