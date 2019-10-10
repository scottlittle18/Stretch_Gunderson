using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LegController : Extendable, IExtendable
{
    // Input Variables
    private bool extendObjectInputActive;

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
    }

    private void ListenForInput()
    {
        //TODO: Change the name Jump to ExtendArms in Unity && Here
        extendObjectInputActive = Input.GetButton("ExtendLegs");

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
