﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

	void Start ()
    {
        Invoke("EndGame", 5);
	}
	
	void Update ()
    {
		
	}

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
