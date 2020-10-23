using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct AudioList
{
    public string name;
    public AudioClip audioClip;
    public GameObject gui;
    
}
public class AudioAssets : MonoBehaviour
{
    public List<AudioList> _audioPlayerList = new List<AudioList>();
    public static List<AudioList> audioPlayerList = new List<AudioList>();
    public static AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioPlayerList = _audioPlayerList;

    }
}
