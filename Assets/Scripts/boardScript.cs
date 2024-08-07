using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boardScript : MonoBehaviour
{
    public GameObject[,] boardStorage = new GameObject[9,9];  // array of all space objects
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        int ii=0;
        foreach (Transform child in transform)
        {
            boardStorage[ii/9,ii%9]=child.gameObject;
            
            child.gameObject.GetComponent<spaceScript>().coords[0]=ii/9;
            child.gameObject.GetComponent<spaceScript>().coords[1]=ii%9;
            ii++;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckForWinner(GameObject lastPlaced, int placedPlayer) {
        int x = lastPlaced.GetComponent<spaceScript>().coords[0];
        int y = lastPlaced.GetComponent<spaceScript>().coords[1];
        
        int total=1;
        total += GetRowLength(x,y,-1,-1,placedPlayer);
        total += GetRowLength(x,y,1,1,placedPlayer);
        if (total>=5) {
            return true;
        }

        total=1;
        total += GetRowLength(x,y,-1,1,placedPlayer);
        total += GetRowLength(x,y,1,-1,placedPlayer);
        if (total>=5) {
            return true;
        }

        total=1;
        total += GetRowLength(x,y,1,0,placedPlayer);
        total += GetRowLength(x,y,-1,0,placedPlayer);
        if (total>=5) {
            return true;
        }

        total=1;
        total += GetRowLength(x,y,0,1,placedPlayer);
        total += GetRowLength(x,y,0,-1,placedPlayer);
        if (total>=5) {
            return true;
        }

        return false;
    }

    // use this to move in a direction and get how many chips are in a row
    public int GetRowLength(int x0, int y0, int dirx, int diry, int placedPlayer) {
        int x=x0+dirx;
        int y=y0+diry;
        int total=0;
        while (x>0 && x<boardStorage.GetLength(1) && y>0 && y<boardStorage.GetLength(0) && !boardStorage[x,y].GetComponent<spaceScript>().empty) {
            if (placedPlayer==0 && boardStorage[x,y].GetComponent<spaceScript>().occupiedBy0 || placedPlayer==1 && boardStorage[x,y].GetComponent<spaceScript>().occupiedBy1) {
                total++;
                x+=dirx;
                y+=diry;
            } else {  // blocked
                x=-1;
            }
        }

        return total;
    }
}
