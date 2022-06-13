using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floatTest : MonoBehaviour
{
    float a;
    float b;
    // Start is called before the first frame update
    void Start()
    {
        a = 0.1f;
        b = 0.2f;
        //float c = a + b;
        //double d = 1 - 0.7f;

        float xx = 2000 * 0.01f;

        string s1 = String.Format("{0:N30}", (int)(2000*0.01f));
        string s2 = String.Format("{0:N30}", (int)xx);
        Debug.Log("s1 = " + s1);
        Debug.Log("s2 = " + s2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
