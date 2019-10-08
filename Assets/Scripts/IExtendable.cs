using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExtendable
{
    //Required Properties
    float MaxExtensionLimit { get; set; }

    //Required Methods
    void Extend();
    void ShrinkToOriginalSize();
}
