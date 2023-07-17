using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] GameObject[] _rules;
    [SerializeField] string _sceneName;

    private void Update()
    {
        if(_slider.value == 0)
        {
            _rules[0].SetActive(false);
        }
        if(_slider.value > 0)
        {
            _rules[0].SetActive(true);
            _rules[1].SetActive(false);
        }
        if(_slider.value > 0.5f)
        {
            _rules[0].SetActive(false);
            _rules[1].SetActive(true);
        }
        if(_slider.value == 1)
        {
            SceneChangeController.LoadScene(_sceneName);
        }
    }
}
