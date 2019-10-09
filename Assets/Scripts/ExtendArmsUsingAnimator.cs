using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses the animator to extend the player's arms in a way that launches them
/// </summary>
public class ExtendArmsUsingAnimator : Extendable, IExtendable
{
    //#region --Serialized Fields--
    //[SerializeField]
    //private float bouncinessOnCollision;

    //[SerializeField]
    //private PhysicsMaterial2D armsPhysMat;

    //[SerializeField, Tooltip("Mass of the arm when it's in its' Idle Animation State")]
    //private float startingMass;

    //[SerializeField, Tooltip("Mass of the arm when it's in its' Arm_KeepExtendedArm Animation State")]
    //private float extensionMass;
    //#endregion

    //#region Non-Serialized Fields
    //// Unity Classes
    //private Animator armAnim;
    //private Rigidbody2D armRigidbody;

    // Input Variables
    private bool extendObjectInputActive;
    //#endregion

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

        //TODO: Change the name Jump to ExtendArms in Unity && Here
        extendObjectInputActive = Input.GetButton("Jump");

        if (extendObjectInputActive)
        {
            base.Extend("Extend");
        }

        if (!extendObjectInputActive)
        {
            base.ResetScale("Extend");
        }
    }

    public virtual void ListenForInput()
    {
        
    }

    /// <summary>
    /// Controls the mass of the Arms to increase or decrease the amount of 
    ///  force applied to the rest of the Player
    /// </summary>
    //public override void MassController()
    //{
    //    // If extending, Then increase mass to increase force applied to the rest of the Player
    //    if (armAnim.GetBool("Extend") == true)
    //    {
    //        armRigidbody.mass = extensionMass;
    //    }
    //    else if (armAnim.GetBool("Extend") == false)
    //    {
    //        armRigidbody.mass = startingMass;
    //    }
    //}

    /// <summary>
    /// Listen for Input from the Player
    /// </summary>
    //public override void ListenForInput()
    //{
    //    //TODO: Change the name Jump to ExtendArms in Unity && Here
    //    extendingArms = Input.GetButtonDown("Jump");

    //    if (extendingArms)
    //    {
    //        Extend();
    //    }

    //    if (!extendingArms)
    //    {
    //        ResetScale();
    //    }
    //}

    //public override void Extend()
    //{
    //    armAnim.SetBool("Extend", true);
    //}

    //public override void ResetScale()
    //{
    //    armAnim.SetBool("Extend", false);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Make the Collider on the arm bouncy right before hitting the ground to add a little extra push
            extendableObjectPhysMat.bounciness = bouncinessOnCollision;
            Debug.Log($"Player's Arm Material Has converted to: {extendableObjectPhysMat.bounciness}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Stop arm from being bouncy when it leaves the ground
            extendableObjectPhysMat.bounciness = 0;
            Debug.Log($"Player's Arm Material Has reverted to: {extendableObjectPhysMat.bounciness}");
        }
    }
}
