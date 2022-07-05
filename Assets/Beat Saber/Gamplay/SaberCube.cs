using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaberCube : MonoBehaviour
{

    public UnityEvent OnDie;

    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        transform.position += Time.deltaTime * transform.forward * Speed;
    }
    public void DestroyCube(){
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        OnDie.Invoke();
    }
}
