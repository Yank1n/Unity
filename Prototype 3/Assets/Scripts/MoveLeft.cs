﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float lowerBound = -25f;
    private PlayerController playerControllerSc;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerSc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerSc.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
       

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}
