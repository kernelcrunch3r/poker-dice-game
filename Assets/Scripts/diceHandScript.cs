using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class diceHandScript : MonoBehaviour
{
    public GameObject[] dice;
    public GameObject logic;
    public string[] currPositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset() {
        foreach(GameObject d in dice) {
            d.GetComponent<diceScript>().Reset();
        }
    }

    public void rollSelected(){
        foreach(GameObject d in dice) {
            d.GetComponent<diceScript>().roll();
        }
        currPositions = rollResults();
    }

    public string[] rollResults() {
        string[] results = {"","","","","","",""};
        int[] totalValues = {0,0,0,0,0,0};
        // keep track of how often each number appears in the "hand"
        foreach(GameObject d in dice) {
            totalValues[d.GetComponent<diceScript>().value-1]++;
        }
        int p=0; // used for placing string results

        int addedUp=0;
        bool twoPair=false;
        for(int i=0; i<6; i++) {
            addedUp+=totalValues[i]*(i+1);
            if(totalValues[i]==5) {
                results[p]=("yahtzee");  // 5 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 4 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 3 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() );  // 2 of a kind
                p++;
            } else if(totalValues[i]==4) {
                results[p]=((i+1).ToString() + (i+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 4 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 3 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() );  // 2 of a kind
                p++;
            } else if(totalValues[i]==3) {
                results[p]=((i+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 3 of a kind
                p++;
                results[p]=((i+1).ToString() + (i+1).ToString() );  // 2 of a kind
                p++;
            
                // full house and two pairs
                for(int j=0; j<6; j++) {
                    if(totalValues[j]==2) {
                        results[p]=("fullHouse");
                        p++;
                        results[p]=((i+1).ToString() + (i+1).ToString() + (j+1).ToString() + (j+1).ToString());  // 2 pair
                        p++;
                        results[p]=((j+1).ToString() + (j+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 2 pair
                        p++;
                    }
                }
            } else if(totalValues[i]==2) {
                results[p]=((i+1).ToString() + (i+1).ToString() );  // 2 of a kind
                p++;
                if(!twoPair) {
                    for(int j=0; j<6; j++) {
                        if(i!=j && totalValues[j]==2) {
                            results[p]=((i+1).ToString() + (i+1).ToString() + (j+1).ToString() + (j+1).ToString());  // 2 pair
                            p++;
                            results[p]=((j+1).ToString() + (j+1).ToString() + (i+1).ToString() + (i+1).ToString());  // 2 pair
                            p++;
                            twoPair=true;
                        }
                }
                }
                
            } 
            
        }
        if(addedUp==7) {
            results[p]=("lucky7");
            p++;
        } else if(addedUp==11) {
            results[p]=("lucky11");
            p++;
        }
        
        if(totalValues[1]==1 && totalValues[2]==1 && totalValues[3]==1 && totalValues[4]==1) {
                results[p]=("straight");
                p++;
            }

        return results;
    }
    
}
