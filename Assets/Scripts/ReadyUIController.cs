using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUIController : MonoBehaviour
{
    [SerializeField] Text _currentPlayerText;
    int count = 0;
    [SerializeField] GameObject _go;
    void OnEnable()
    {
        if(count == 1)
        {
            _go.SetActive(true);
            Destroy(this);
        }
        count++;
    }
}
