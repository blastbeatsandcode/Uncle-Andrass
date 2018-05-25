using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", 12f);
	}
	
	void LoadFirstScene ()
    {
        SceneManager.LoadScene(1);
    }
}
