using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodebreakingScript : MonoBehaviour
{
    
    public Button retryButton;
    //public bool codebreakingHasWon = false;
    //Answer Panel references
    public InputField AP_Y_1;
    public InputField AP_O_1;
    public InputField AP_U;
    public InputField AP_R_1;
    public InputField AP_B;
    public InputField AP_O_2;
    public InputField AP_D;
    public InputField AP_Y_2;
    public InputField AP_K;
    public InputField AP_E_1;
    public InputField AP_E_2;
    public InputField AP_P;
    public InputField AP_S_1;
    public InputField AP_T;
    public InputField AP_H;
    public InputField AP_E_3;
    public InputField AP_S_2;
    public InputField AP_C;
    public InputField AP_O_3;
    public InputField AP_R_2;
    public InputField AP_E_4;
    
    
    //Answer Input references
    public InputField AI_O;
    public InputField AI_R;
    public InputField AI_D;
    public InputField AI_U;
    public InputField AI_B;
    public InputField AI_K;
    public InputField AI_S;
    public InputField AI_C;
    public InputField AI_P;
    public InputField AI_H;
    public InputField AI_Y;
    public InputField AI_T;
    public InputField AI_E;
    

    void Start()
    {
        AP_U.text = "U";
        AI_U.text = "U";

        AP_C.text = "C";
        AI_C.text = "C";

        AP_T.text = "T";
        AI_T.text = "T";
    }

    void OnEnable()
    {
        retryButton.onClick.AddListener(() => codeBreakingRetry());
    }
    void FixedUpdate()
    {
        matchInput();
        checkAnswer();
    }

    public void checkAnswer()
    {
        if((AI_B.text.ToUpper() == "B") &&
           (AI_C.text.ToUpper() == "C") &&
           (AI_D.text.ToUpper() == "D") &&
           (AI_E.text.ToUpper() == "E") &&
           (AI_H.text.ToUpper() == "H") &&
           (AI_K.text.ToUpper() == "K") &&
           (AI_O.text.ToUpper() == "O") &&
           (AI_P.text.ToUpper() == "P") &&
           (AI_R.text.ToUpper() == "R") &&
           (AI_S.text.ToUpper() == "S") &&
           (AI_T.text.ToUpper() == "T") &&
           (AI_U.text.ToUpper() == "U") &&
           (AI_Y.text.ToUpper() == "Y")) winCodebreaking();
    }

    public void winCodebreaking()
    {
        //codebreakingHasWon = true;
        Debug.Log("Codebreaking puzzle completed");
    }

    public void matchInput()
    {
        AP_O_1.text = AI_O.text;
        AP_O_2.text = AI_O.text;
        AP_O_3.text = AI_O.text;

        AP_R_1.text = AI_R.text;
        AP_R_2.text = AI_R.text;

        AP_D.text = AI_D.text;

        AP_U.text = AI_U.text;

        AP_B.text = AI_B.text;

        AP_K.text = AI_K.text;

        AP_S_1.text = AI_S.text;
        AP_S_2.text = AI_S.text;

        AP_C.text = AI_C.text;

        AP_P.text = AI_P.text;

        AP_H.text = AI_H.text;

        AP_Y_1.text = AI_Y.text;
        AP_Y_2.text = AI_Y.text;

        AP_T.text = AI_T.text;

        AP_E_1.text = AI_E.text;
        AP_E_2.text = AI_E.text;
        AP_E_3.text = AI_E.text;
        AP_E_4.text = AI_E.text;
    }

    public void codeBreakingRetry()
    {
        var allInputFields = FindObjectsOfType<InputField>();

        foreach(InputField i in allInputFields)
        {
            i.text = "";
        }
    }

}
