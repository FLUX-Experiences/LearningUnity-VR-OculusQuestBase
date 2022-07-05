using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song", menuName = "Songs/SongScriptable", order = 1)]
public class SongScriptable : ScriptableObject
{
   public AudioClip song;
   public float beat;
}
