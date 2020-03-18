using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProcessorTurrets : MonoBehaviour
{
    MiniGun miniGun;
    public AudioSource shootSound;
    public void Awake()
    {
        miniGun=GetComponent<MiniGun>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
