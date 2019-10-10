using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This Parent class should be used by the parts of the character that the
/// player will be able to control
/// </summary>
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
public class Extendable : MonoBehaviour
{
    #region --Serialized Fields--
    [SerializeField]
    protected float bouncinessOnCollision;

    [SerializeField]
    protected PhysicsMaterial2D extendableObjectPhysMat;

    [SerializeField, Tooltip("Mass of the arm when it's in its' Idle Animation State")]
    protected float startingMass;

    [SerializeField, Tooltip("Mass of the arm when it's in its' Arm_KeepExtendedArm Animation State")]
    protected float extensionMass;
    #endregion

    #region Non-Serialized Fields
    //Unity Classes
    protected Animator extendableObectAnim;
    protected Rigidbody2D extendableObjectRigidbody;
    //protected bool extendObjectInputActive;
    #endregion

    public virtual void Initialize(Animator extendableAnimator, Rigidbody2D rigidbody2D)
    {
        // Unity Classes
        extendableObectAnim = extendableAnimator;
        extendableObjectRigidbody = rigidbody2D;
    }

    

    public virtual void Extend(string clipName)
    {
        extendableObectAnim.SetBool(clipName, true);
    }

    public virtual void ResetScale(string clipName)
    {
        extendableObectAnim.SetBool(clipName, false);
    }

    public virtual void MassController()
    {
        // If extending, Then increase mass to increase force applied to the rest of the Player
        if (extendableObectAnim.GetBool("Extend") == true)
        {
            extendableObjectRigidbody.mass = extensionMass;
        }
        else if (extendableObectAnim.GetBool("Extend") == false)
        {
            extendableObjectRigidbody.mass = startingMass;
        }
    }
}
