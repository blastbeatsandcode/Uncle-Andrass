using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    void Awake()
    {

        if (FindObjectsOfType<MusicPlayer>().Length > 1) // If there is already a music player on the screen, destroy the new music player
        {
            Destroy(gameObject);
        }
        else // Otherwise create one
        {
            GameObject.DontDestroyOnLoad(this);
        }
    }


}