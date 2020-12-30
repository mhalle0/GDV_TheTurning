using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject obj = GameObject.Find("Temporary Player");

        //if (objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        ////}

        //DontDestroyOnLoad(this.gameObject);
    }
}
