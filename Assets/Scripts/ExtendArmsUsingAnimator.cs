using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendArmsUsingAnimator : Extendable, IExtendable
{
    private float maxExtensionLimit;

    [SerializeField]
    private float bouncinessOnCollision;

    [SerializeField]
    private PhysicsMaterial2D armsPhysMat;

    [SerializeField, Tooltip("Mass of the arm when it's in its' Idle Animation State")]
    private float startingMass;

    [SerializeField, Tooltip("Mass of the arm when it's in its' Arm_KeepExtendedArm Animation State")]
    private float extensionMass;

    public float MaxExtensionLimit
    {
        get => maxExtensionLimit;
        set => maxExtensionLimit = value;
    }

    // Design Attempt specific variables
    private Animator armAnim;
    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        armAnim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Extend();
        }

        if (Input.GetButtonUp("Jump"))
        {
            ShrinkToOriginalSize();
        }

        if (armAnim.GetBool("Extend") == true)
        {
            playerRigidbody.mass = extensionMass;
        }
        else if (armAnim.GetBool("Extend") == false)
        {
            playerRigidbody.mass = startingMass;
        }
    }

    public void Extend()
    {
        armAnim.SetBool("Extend", true);
    }

    public void ShrinkToOriginalSize()
    {
        armAnim.SetBool("Extend", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Make the Collider on the arm bouncy right before hitting the ground to add a little extra push
            armsPhysMat.bounciness = bouncinessOnCollision;
            Debug.Log($"Player's Arm Material Has converted to: {armsPhysMat.bounciness}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Stop arm from being bouncy when it leaves the ground
            armsPhysMat.bounciness = 0;
            Debug.Log($"Player's Arm Material Has reverted to: {armsPhysMat.bounciness}");
        }
    }
}
