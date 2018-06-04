using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    void Awake()
    {

        if (FindObjectsOfType<MusicPlayer>().Length > 0) // If there is already a music player on the screen, destroy the new music player
        {
            Destroy(this);
        }
        else // Otherwise create one
        {
            GameObject.DontDestroyOnLoad(this);
        }
    }


}