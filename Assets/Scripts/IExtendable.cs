using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExtendable
{
    //Required Properties
    

    //Required Methods
    void Extend(string clipName);
    void ResetScale(string clipName);
    void MassController();
}
