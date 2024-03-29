﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridMover
{

    public bool hasKey = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isPlayerTurn)
            return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");
        
        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
            AttemptMove<Obstacle> (horizontal, vertical);
        
    }

    protected override void AttemptMove <T> (int xDir, int yDir) 
    {
        if (IsMoving())
            return;
        base.AttemptMove <T> (xDir, yDir);
    }



    protected override void OnCantMove<T>(T obstacle) 
    {
        obstacle.OnPlayerInteract(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Exit") {
            GameManager.instance.LoadNextLevel();
        }

        if (other.tag == "Projectile") {
            GameManager.instance.LoseLife();
        }
        if (other.tag == "Spike") {
            GameManager.instance.LoseLife();
        }
        if (other.tag == "Key") {
            if (hasKey == false) {
                other.gameObject.transform.SetParent(this.transform);
                hasKey = true;
                other.enabled = false;
            }
        }
        if (other.tag == "Hole") {
            GameManager.instance.LoseLife();
        }
        if (other.tag == "Kill") {
            GameManager.instance.LoseLife();
        }
    }
}
