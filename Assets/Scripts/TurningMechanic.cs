using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurningMechanic : MonoBehaviour
{
    private Transform bar;

    private void Awake()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        if (sizeNormalized < 0)
        {
            sizeNormalized = 0;
        }
        bar.localScale = new Vector3(4 * sizeNormalized, 1f);
    }
}
