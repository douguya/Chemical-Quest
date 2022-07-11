using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Animator Goaln;
    public AudioClip DoerSOund;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Goaln = GetComponent<Animator>();

        Goaln.SetBool("Goal",false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)//  地面に触れた時の処理
    {
       // Debug.Log("goal");
        if (other.gameObject.tag == "Player")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Goaln.SetBool("Goal", true);

          //クリア時のポップアップ出現
        }

    }






    public void ADore()
    {
        Debug.Log("MousePointSound");
        audioSource.PlayOneShot(DoerSOund);
    }







}
