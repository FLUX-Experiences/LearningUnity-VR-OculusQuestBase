using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaberSword : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPosition;

    public UnityEvent OnCubeDestroyed;

    public bool IsLeftController;

    // Start is called before the first frame update
    void Start()
    {


    }

    /// 1 = max distance between sword and cube 
    /// 130 angle between sword and cube 
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer)) {
            HitCube(hit.transform);
        }

        previousPosition = transform.position;
    }

    private void HitCube(Transform hitTransform) {
        if (Vector3.Angle(transform.position - previousPosition, hitTransform.up) > 130) {
            hitTransform.gameObject.GetComponent<SaberCube>().DestroyCube();
            OnCubeDestroyed.Invoke();

            Vibrate((IsLeftController ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch), 0.5f);
        } else {
            Debug.Log("hit cube from wrong angle");
        }
    }
    private void Vibrate(OVRInput.Controller controller, float power=1) {
        // starts vibration on the right Touch controller
        OVRInput.SetControllerVibration(power, power, controller);
    }

    /// <summary>
    /// see https://www.youtube.com/watch?v=9KJqZBoc8m4&ab_channel=Valem
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="sound"></param>
    private void Vibrate(OVRInput.Controller controller, AudioClip sound) {
        OVRHapticsClip clip = new OVRHapticsClip(sound);

        if (controller == OVRInput.Controller.RTouch) {
            OVRHaptics.LeftChannel.Preempt(clip);
        } else if (controller == OVRInput.Controller.RTouch) {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}