﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey) {
            SceneManager.LoadScene("Level1");
        }
    }
}
