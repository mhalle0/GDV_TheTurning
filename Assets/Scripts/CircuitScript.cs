using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircuitScript : MonoBehaviour
{
    private CircuitNode ClickNode1;
    [SerializeField] PuzzleExit ExitBtn;

    [SerializeField] CircuitNode Node1;
    [SerializeField] CircuitNode Node2;
    [SerializeField] CircuitNode Node3;
    [SerializeField] CircuitNode Node4;
    [SerializeField] CircuitNode Node5;
    [SerializeField] CircuitNode Node6;
    [SerializeField] CircuitNode Node7;
    [SerializeField] CircuitNode Node8;
    [SerializeField] CircuitNode Node9;
    [SerializeField] CircuitNode Node10;
    [SerializeField] CircuitNode Node11;
    [SerializeField] CircuitNode Node12;
    [SerializeField] CircuitNode Node13;
    [SerializeField] CircuitNode Node14;
    [SerializeField] CircuitNode Node15;
    [SerializeField] CircuitNode Node16;
    [SerializeField] CircuitNode Node17;
    [SerializeField] CircuitNode Node18;
    [SerializeField] CircuitNode Node19;

    GameObject[] infoMenu;
    public bool infoIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        infoMenu = GameObject.FindGameObjectsWithTag("PuzzleInfo");
        infoIsOpen = true;
        ToggleInfo();
    }
    
    void Awake()
    {
        Node1.PresetLine(Node2);
        Node2.PresetLine(Node3);
        Node6.PresetLine(Node10);
        Node9.PresetLine(Node14);
        Node11.PresetLine(Node12);
        Node13.PresetLine(Node14);
        Node15.PresetLine(Node16);
        Node15.PresetLine(Node19);
    }

    // Update is called once per frame
    void Update()
    {
        if( Node1.Full && Node2.Full && Node3.Full && Node4.Full &&
            Node5.Full && Node6.Full && Node7.Full && Node8.Full &&
            Node9.Full && Node10.Full && Node11.Full && Node12.Full &&
            Node13.Full && Node14.Full && Node15.Full && Node16.Full &&
            Node17.Full && Node18.Full && Node3.Full)
        {
            Debug.Log("congrats u won");
        }
    }

    public void ToggleInfo()
    {
        if(infoIsOpen == true)
        {
            Debug.Log("Puzzle info closed");

            foreach(GameObject g in infoMenu)
            {
                g.SetActive(false);
            }

            infoIsOpen = false;
        } 
        else 
        {
            Debug.Log("Puzzle info opened");

            foreach(GameObject g in infoMenu)
            {
                g.SetActive(true);
            }

            infoIsOpen = true;
        }
    }

    public void ClearBoard()
    {
        GameObject[] wires = GameObject.FindGameObjectsWithTag("Wire");
        foreach (GameObject wire in wires)
        {
            // remove connections & destroy lines
            WireBehavior wb = wire.GetComponent<WireBehavior>();
            wb.wnode1.connection1 = null;
            wb.wnode1.connection2 = null;
            wb.wnode2.connection1 = null;
            wb.wnode2.connection2 = null;

            LineRenderer lr = wire.GetComponent<LineRenderer>();
            Destroy(lr);
            Destroy(wire);
        }
    }

    public void Retry()
    {
        ClearBoard();
        Awake();
    }

    public void Exit()
    {
        ClearBoard();
        ExitBtn.OnMouseDown();
    }

    public void NodeClicked(CircuitNode node)
    {
        if (ClickNode1 == null)
        {
            ClickNode1 = node;
        }
        else
        {
            node.ConnectNodes(ClickNode1);

            // reset node
            ClickNode1 = null;
        }
    }

}
