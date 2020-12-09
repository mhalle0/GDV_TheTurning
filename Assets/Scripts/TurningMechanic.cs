using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurningMechanic : MonoBehaviour
{
    private Transform bar;
    private Transform top;

    private void Awake()
    {
        bar = transform.Find("Bar");

        top = transform.Find("Top");
    }

    public void SetSize(float sizeNormalized)
    {
        // zombie scale 0 to 1

        if (sizeNormalized < 0)
        {
            sizeNormalized = 0;
        }

        if (bar != null)
        {
            // bar scale 0 to 4
            bar.localScale = new Vector3( (4-(4 * sizeNormalized)), 1f);
        }

        if (top != null)
        {
            // scale 650 to 0
            top.localPosition = new Vector3(1f, 560 * sizeNormalized);
        }
    }
}
