using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }


}