using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This Parent class should be used by the parts of the character that the
/// player will be able to control
/// </summary>
public class Extendable : MonoBehaviour
{
    protected class DefaultScaleSettings
    {
        // Default Scale Settings
        public float yScale;

        /// <summary>
        ///  Simple Constructor for YAxis ONLY
        /// </summary>
        /// <param name="yAxis"> This should be the transform.localScale.y of the child object</param>
        public DefaultScaleSettings(float yAxis)
        {
            yScale = yAxis;
        }
    }
}
