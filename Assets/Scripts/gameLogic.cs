using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour
{
    public int currPlayer=0;
    public int turns=0;
    public GameObject diceHand;
    public GameObject[] players;
    public GameObject chipSpawner;
    public ChipSpawnScript spawnScript;
    public GameObject board;
    public boardScript boardScript;

    public int winner=-1;

    public Text playerText;
    public Text turnText;

    public GameObject gameOverScreen;
    public GameObject gameControls;
    public Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = chipSpawner.GetComponent<ChipSpawnScript>();
        boardScript = board.GetComponent<boardScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeTurn() {
        if(turns<3) {
            diceHand.GetComponent<diceHandScript>().rollSelected();
        turns++;
        turnText.text = turns.ToString();
        }
        
    }

    public void PlaceChip(GameObject targetSpace) {
        // after dice has been rolled, can try to place chips
        if(turns>0 && turns<=3 && targetSpace.GetComponent<spaceScript>().empty) {
            // check if actually allowed to place chip in desired spot
            string[] possibilities = diceHand.GetComponent<diceHandScript>().currPositions;
            if (possibilities.Contains(targetSpace.name) || possibilities.Contains("yahtzee")) {
                spawnScript.PlaceChip(targetSpace, currPlayer);

                targetSpace.GetComponent<spaceScript>().empty=false;

                if(boardScript.CheckForWinner(targetSpace, currPlayer)){
                    winner=currPlayer;
                    GameOver();
                }
                ChangePlayer();
            }
            
        }
        
        
    }
    public void ChangePlayer() {
        if(currPlayer==0) {
            currPlayer=1;
            playerText.text="Blue";
        } else if (currPlayer==1) {
            currPlayer=0;
            playerText.text="Green";
        }
        
        diceHand.GetComponent<diceHandScript>().Reset();
        turns=0;
        turnText.text=turns.ToString();
    }

    public void GameOver(){
        gameControls.SetActive(false);
        gameOverScreen.SetActive(true);
        winnerText.text = playerText.text+" player has won!!";
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
