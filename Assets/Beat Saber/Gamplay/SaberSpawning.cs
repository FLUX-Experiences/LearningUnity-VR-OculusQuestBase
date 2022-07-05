using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
for the song data:
1. download a song
2. find the BeatPerMinute here https://songbpm.com/
*/

public class SaberSpawning : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public SongScriptable SongData;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > SongData.beat){
            GameObject cube = Instantiate(cubes[Random.Range(0,cubes.Length)], points[Random.Range(0,points.Length)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0,4)); //rotate between 0 , 90, 180, 360

            timer -= SongData.beat;
        }   
        timer += Time.deltaTime; 
    }
}