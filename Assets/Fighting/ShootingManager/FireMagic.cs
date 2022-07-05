using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// only fires if AllowFire set to true
/// </summary>
public class FireMagic : MonoBehaviour
{
    public List<OculusEvent> Events;

    
    private bool _isFireAllowed = false;
    public bool AllowFire
    {
        set
        {
            _isFireAllowed = value;
        }

        get
        {
            return _isFireAllowed;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //do not allow fire under certain external conditions
        if (_isFireAllowed == false) return;


        foreach (OculusEvent _event in Events)
        {
            if (OVRInput.GetDown(_event.button, _event.controller))
            {
                _event.OnButtonPressed.Invoke(_event.startingPoint);
            }
        }
    }
}

[System.Serializable]
public class OculusEvent
{
    public string description;
    public OVRInput.Controller controller;
    public OVRInput.Button button;
    public Transform startingPoint;
    public UnityEventTransform OnButtonPressed;
}


[System.Serializable]
public class UnityEventTransform : UnityEngine.Events.UnityEvent<Transform> { };