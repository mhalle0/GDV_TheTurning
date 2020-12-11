using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    public Queue<KeyValuePair<int, string>> dq = new Queue<KeyValuePair<int, string>>();
    public bool hasLearnedPills;
    public bool hasNotEnteredLab;

}