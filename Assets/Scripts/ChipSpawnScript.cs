using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawnScript : MonoBehaviour
{
    public GameObject playerChip0;
    public GameObject playerChip1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceChip(GameObject boardSpace, int player) {
        if(player==0) {
            Instantiate(playerChip0, new Vector3(boardSpace.transform.position.x, boardSpace.transform.position.y, -5), boardSpace.transform.rotation);
            boardSpace.GetComponent<spaceScript>().occupiedBy0=true;
        } else if (player==1) {
            Instantiate(playerChip1, new Vector3(boardSpace.transform.position.x, boardSpace.transform.position.y, -5), boardSpace.transform.rotation);
            boardSpace.GetComponent<spaceScript>().occupiedBy1=true;
        }
    }
}
