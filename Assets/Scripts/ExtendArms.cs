using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendArms : Extendable, IExtendable
{
    private Transform yAxisLocalScale;

    /// <summary>
    /// Used to reset the scale of the specified object
    /// </summary>
    private DefaultScaleSettings defaultScaleSettings;

    [SerializeField, Tooltip("The max distance that this object will scale out to")]
    private float maxExtensionLimit;

    [SerializeField, Tooltip("The speed at which the object will scale")]
    private float extensionSpeed;

    /// <summary>
    /// Implementation Required By IExtendable interface
    /// </summary>
    public float MaxExtensionLimit
    {
        get {return maxExtensionLimit; }

        set { maxExtensionLimit = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Stopped here to try and make the arms scale straight forward without scaling back too
        yAxisLocalScale = transform;

        defaultScaleSettings = new DefaultScaleSettings(yAxisLocalScale.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Extend();
        }
    }

    public void Extend()
    {
        Debug.Log("extend entered");
        yAxisLocalScale.localScale = Hozukimaru(extensionSpeed);
        Debug.Log("extend exit");
    }

    public void ShrinkToOriginalSize()
    {
        //TODO: Add Code Here...
    }

    private Vector3 Hozukimaru(float scaleSpeed)
    {
        Vector3 scaleToApply = new Vector3(transform.localScale.x, transform.localScale.y * scaleSpeed, transform.localScale.z);

        return scaleToApply;
    }
}
