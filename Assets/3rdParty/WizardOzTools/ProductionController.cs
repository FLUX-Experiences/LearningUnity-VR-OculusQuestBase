using UnityEngine;
using UnityEngine.Events;

public class ProductionController : MonoBehaviour
{
public UnityEvent OnDebugBuild;

    void Start()
    {
        #if UNITY_EDITOR
        OnDebugBuild.Invoke();
        #endif
    }
}