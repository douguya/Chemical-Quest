using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCleaSound : MonoBehaviour
{
    public AudioClip Fanfale;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Fanfale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
