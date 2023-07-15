using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public static test Instance;
    Text log;

    void Awake()
    {
        Instance = this;
        log = GetComponent<Text>();
    }

    public void LogChange(string str)
    {
        log.text = str;
    }
}
