using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUttonSound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    public AudioClip MoutPoint;
    public AudioClip PutButtpon;
    public AudioClip Assid;
    AudioSource audioSource;

    public static bool Assidjuje=false;



    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if  (BUttonSound.Assidjuje == true)
        {
            audioSource.PlayOneShot(Assid);
            BUttonSound.Assidjuje = false;
        }




    }
    public void AMousePointSound()
    {
        Debug.Log("MousePointSound");
        audioSource.PlayOneShot(MoutPoint);
    }
    public void APutButtponSound()
    {
        Debug.Log("PutButtponSound");
        audioSource.PlayOneShot(PutButtpon);
    }
}
