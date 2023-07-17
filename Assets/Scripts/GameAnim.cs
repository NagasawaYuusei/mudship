using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnim : MonoBehaviour
{
    public static GameAnim Instance;
    Animator anim;

    void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }
    public void PlayAnim(string name)
    {
        Debug.Log("Play");
        anim.Play(name);
    }

    public void ChangeFeverState(bool trigger)
    {
        anim.SetBool("Fever", trigger);
    }
}
