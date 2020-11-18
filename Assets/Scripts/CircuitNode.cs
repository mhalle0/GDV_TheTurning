using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitNode : MonoBehaviour
{
    public CircuitNode connection1;
    public CircuitNode connection2;

    [SerializeField] int row;
    [SerializeField] int column;

    // for pre-set lines:
    public bool CanChangeConnect1 = true;
    public bool CanChangeConnect2 = true;

    public bool Full;

    // NOTE ON DELETING LINES:
    //  make sure that if one of the connections is a connection1,
    //  set connection2 to fill connection1 & set connection2 to null

    [SerializeField] CircuitScript Circuit;

    public void OnMouseDown()
    {
        Circuit.NodeClicked(this);
    }

    public void ConnectNodes(CircuitNode otherNode)
    {
        if( IsValidConnection( otherNode ) )
        {
            // draw line  --> gonna just be pink for rn
            Debug.Log("Shit's valid");

            DrawLine(otherNode);
        }
    }

    //public bool Full()
    //{
    //    return connection1 != null && connection2 != null;
    //}

    public void DrawLine(CircuitNode otherNode)
    {
        GameObject wire = new GameObject();
        wire.transform.position = this.transform.position;
        wire.AddComponent<LineRenderer>();
        LineRenderer lr = wire.GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, otherNode.transform.position);
        wire.tag = "Wire";
    }

    public void PresetLine(CircuitNode otherNode)
    {
        ConnectNodes(otherNode);
        if(connection1 != null)
        {
            CanChangeConnect1 = false;
        }
        if(connection2 != null)
        {
            CanChangeConnect2 = false;
        }
        if (otherNode.connection1 != null)
        {
            otherNode.CanChangeConnect1 = false;
        }
        if (otherNode.connection2 != null)
        {
            otherNode.CanChangeConnect2 = false;
        }
    }

    public bool IsValidConnection(CircuitNode otherNode)
    {
        bool ret = false;

        // same row -> abs(col - col) must equal 2
        if (row == otherNode.row && Mathf.Abs(column - otherNode.column) == 2)
        {
            ret = true;
        } 
        else if (Mathf.Abs(row - otherNode.row) == 1)
        {
            if (Mathf.Abs(column - otherNode.column) == 1)
            {
                ret = true;
            }
        }
        if( !ret)
        {
            Debug.Log("Invalid by row, column");
        }


        // check row column validity
        if (ret)
        {
            // check connection 1 & 2 capacities, set them if valid
            if ((connection1 != null && connection2 != null) ||
                (otherNode.connection1 != null && otherNode.connection2 != null))
            {
                ret = false;
            }
            else if (connection1 == null)
            {
                if (otherNode.connection1 == null)
                {
                    connection1 = otherNode;
                    otherNode.connection1 = this;
                    Debug.Log("1, 1");
                }
                else if (otherNode.connection2 == null && otherNode.connection2 != this)
                {
                    connection1 = otherNode;
                    otherNode.connection2 = this;
                    otherNode.Full = true;
                    Debug.Log("1, 2");
                }
                else
                {
                    ret = false;
                    Debug.Log("can't connect more than 2 wires to 1 node");
                }
            }
            else if (connection2 == null && connection1 != otherNode)
            {
                if (otherNode.connection1 == null)
                {
                    connection2 = otherNode;
                    otherNode.connection1 = this;
                    Full = true;
                    Debug.Log("2, 1");

                }
                else if (otherNode.connection2 == null)
                {
                    connection2 = otherNode;
                    otherNode.connection2 = this;
                    Full = true;
                    otherNode.Full = true;
                    Debug.Log("2, 2");
                }
                else
                {
                    ret = false;
                    Debug.Log("can't connect more than 2 wires to 1 node");
                }
            }
        }

        return ret;
    }
}
