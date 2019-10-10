﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses the animator to extend the player's arms in a way that launches them
/// </summary>
public class ExtendArmsUsingAnimator : Extendable, IExtendable
{
    // Input Variables
    private bool extendObjectInputActive;

    // TODO: Temp Variables
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform shoulderObject;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize(GetComponent<Animator>(), GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        ListenForInput();
        base.MassController();

        Vector3 mousePoisition = Input.mousePosition;
        mousePoisition = Camera.main.ScreenToWorldPoint(mousePoisition);

        Vector2 directionToFace = new Vector2(mousePoisition.x - shoulderObject.transform.position.x, mousePoisition.y - shoulderObject.transform.position.y);

        transform.up = -directionToFace;
    }

    private void ListenForInput()
    {
        //TODO: Change the name Jump to ExtendArms in Unity && Here
        extendObjectInputActive = Input.GetButton("ExtendArms");

        if (extendObjectInputActive)
        {
            base.Extend("Extend");
        }

        if (!extendObjectInputActive)
        {
            base.ResetScale("Extend");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Make the Collider on the arm bouncy right before hitting the ground to add a little extra push
            extendableObjectPhysMat.bounciness = bouncinessOnCollision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Stop arm from being bouncy when it leaves the ground
            extendableObjectPhysMat.bounciness = 0;
        }
    }
}
