using System.Collections;
using System.Collections.Generic;
using System.Linq; //Used for comparing 2d arrays
using System; //For tubles
using UnityEngine;
using UnityEngine.UI; //Used for button handling
using UnityEngine.SceneManagement;


public class SliderPuzzleController : MonoBehaviour
{

    private float xPos = 0f;
    private float yPos = 0f;
    private float zPos = 0f;

    //The tile sprites
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;

    //The buttons
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button retryButton;

    //The Text
    public GameObject finishText;
    public TMPro.TextMeshProUGUI scoreText;

    //Space in between each tile
    public float tileSpace = 1.7f;

    //Amount of times a button is clicked
    private int moveCount = 0;
    private int attempts = 0;

    //Keep track of whether or not start position has been recorded, used to prevent overwrite on retry
    private bool startLocationAssigned = false;

    //Numberical representation of puzzle array
    private int[,] puzzle = new int[3,3] {
        {4,1,6},
        {7,3,2},
        {0,5,8}
    };

    //The solution puzzle, should never be modified outside of here
    private int[,] solution = new int [3,3] {
        {1,2,3},
        {4,5,6},
        {7,8,0}
    };

    //Gets called when script becomes active
    void OnEnable() {
        //Register Button Events
        upButton.onClick.AddListener(() => upPressed());
        downButton.onClick.AddListener(() => downPressed());
        leftButton.onClick.AddListener(() => leftPressed());
        rightButton.onClick.AddListener(() => rightPressed());
        retryButton.onClick.AddListener(() => restart());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        attempts++;
        float xStart = tile4.transform.position.x;
        float yStart = tile4.transform.position.y;
        float zStart = tile4.transform.position.z;
        xPos = xStart;
        yPos = yStart;
        zPos = zStart;
        //float tileSpace = 1.8f;

        //Build the initial puzzle
        tile1.transform.position = new Vector3(xStart+tileSpace,yStart,zStart);
        tile6.transform.position = new Vector3(xStart+tileSpace*2,yStart,zStart);
        tile7.transform.position = new Vector3(xStart,yStart-tileSpace,zStart);
        tile3.transform.position = new Vector3(xStart+tileSpace,yStart-tileSpace,zStart);
        tile2.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace,zStart);
        tile5.transform.position = new Vector3(xStart+tileSpace,yStart-tileSpace*2,zStart);
        tile8.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace*2,zStart);
        tile9.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace*2,zStart);

        tile9.GetComponent<Renderer>().enabled = false;
        finishText.SetActive(false);
        scoreText.enabled = false;
    }

    void restart() {
        puzzle = new int[3,3] {
            {4,1,6},
            {7,3,2},
            {0,5,8}
        };

        float xStart = xPos;
        float yStart = yPos;
        float zStart = zPos;

        //Build the initial puzzle
        tile4.transform.position = new Vector3(xStart,yStart,zStart);
        tile1.transform.position = new Vector3(xStart+tileSpace,yStart,zStart);
        tile6.transform.position = new Vector3(xStart+tileSpace*2,yStart,zStart);
        tile7.transform.position = new Vector3(xStart,yStart-tileSpace,zStart);
        tile3.transform.position = new Vector3(xStart+tileSpace,yStart-tileSpace,zStart);
        tile2.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace,zStart);
        tile5.transform.position = new Vector3(xStart+tileSpace,yStart-tileSpace*2,zStart);
        tile8.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace*2,zStart);
        tile9.transform.position = new Vector3(xStart+tileSpace*2,yStart-tileSpace*2,zStart);

        tile9.GetComponent<Renderer>().enabled = false;

        //Make sure buttons are active if restart after game complete
        upButton.gameObject.SetActive(true);
        downButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
        finishText.SetActive(false);
        scoreText.enabled = false;

        attempts++;
        //Move counter not reset, using the reset button does not reduce the total number of moves
    }

    //Called at the end of each move
    void checkIfDone() {
        if (checkFinish()) {
            Debug.Log("Puzzle Sloved in " + moveCount + " moves and " + attempts + " attempts!");
            tile9.GetComponent<Renderer>().enabled = true;

            upButton.gameObject.SetActive(false);
            downButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(false);
            finishText.SetActive(true);
            scoreText.enabled = true;
            scoreText.text= ("Moves: " + moveCount + "\nAttempts: " + attempts);
        }
    }

    void upPressed() {
        Tuple<int,int> zero = findZero();
        int row = zero.Item1;
        int targetRow = row+1; //Tile to move
        int column = zero.Item2;

        if(row<2) {
            int tileToMove = puzzle[targetRow,column];
            updateTile(tileToMove,0f,0f-tileSpace);
            puzzle[targetRow,column] = 0;
            puzzle[row,column] = tileToMove;
        }

        moveCount++;
        checkIfDone();
    }

    void downPressed() {
        Tuple<int,int> zero = findZero();
        int row = zero.Item1;
        int targetRow = row-1; //Tile to move
        int column = zero.Item2;

        if(row>0) {
            int tileToMove = puzzle[targetRow,column];
            updateTile(tileToMove,0f,tileSpace);
            puzzle[targetRow,column] = 0;
            puzzle[row,column] = tileToMove;
        }
        moveCount++;
        checkIfDone();
    }

    void leftPressed() {
        Tuple<int,int> zero = findZero();
        int row = zero.Item1;
        int column = zero.Item2;
        int targetColumn = column+1; //Tile to move

        if (column<2) {
            int tileToMove = puzzle[row,targetColumn];
            updateTile(tileToMove,0-tileSpace,0f);
            puzzle[row,targetColumn]=0;
            puzzle[row,column]=tileToMove;
        }
        
        moveCount++;
        checkIfDone();
    }

    void rightPressed() {
        Tuple<int,int> zero = findZero();
        int row = zero.Item1;
        int column = zero.Item2;
        int targetColumn = column-1; //Tile to move

        if (column>0) {
            int tileToMove = puzzle[row,targetColumn];
            updateTile(tileToMove,tileSpace,0f);
            puzzle[row,targetColumn]=0;
            puzzle[row,column]=tileToMove;
        }
        
        moveCount++;
        checkIfDone();
    }

    Tuple<int,int> findZero() {
        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                if (puzzle[r,c]==0) return Tuple.Create(r,c);
            }
        }
        return Tuple.Create(-1,-1);
    }

    void updateTile(int tileNumber, float dx, float dy) {
        switch(tileNumber) {
            case 1:
                tile1.transform.position =  new Vector3(tile1.transform.position.x+dx, tile1.transform.position.y-dy, zPos);
                break;
            case 2:
                tile2.transform.position = new Vector3(tile2.transform.position.x+dx, tile2.transform.position.y-dy, zPos);
                break;
            case 3:
                tile3.transform.position = new Vector3(tile3.transform.position.x+dx, tile3.transform.position.y-dy, zPos);
                break;
            case 4: 
                tile4.transform.position = new Vector3(tile4.transform.position.x+dx, tile4.transform.position.y-dy, zPos);
                break;
            case 5:
                tile5.transform.position = new Vector3(tile5.transform.position.x+dx, tile5.transform.position.y-dy, zPos);
                break;
            case 6:
                tile6.transform.position = new Vector3(tile6.transform.position.x+dx, tile6.transform.position.y-dy, zPos);
                break;
            case 7:
                tile7.transform.position = new Vector3(tile7.transform.position.x+dx, tile7.transform.position.y-dy, zPos);
                break;
            case 8:
                tile8.transform.position = new Vector3(tile8.transform.position.x+dx, tile8.transform.position.y-dy, zPos);
                break;
            default:
                Debug.Log("(SliderPuzzleController/updateTile): Invalid tile number passed: " + tileNumber);
                break;
        }
    }

    bool checkFinish() {
        return
            puzzle.Rank == solution.Rank &&
            Enumerable.Range(0,puzzle.Rank).All(dimension => puzzle.GetLength(dimension) == solution.GetLength(dimension)) &&
            puzzle.Cast<int>().SequenceEqual(solution.Cast<int>());
    }
}
