using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireballMove : MonoBehaviour
{
    public float Speed = 1;
    public UnityEvent OnDie;

    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
    }
    public void DestroyObject()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        OnDie.Invoke();
    }
}
