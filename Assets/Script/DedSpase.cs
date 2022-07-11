using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DedSpase : MonoBehaviour
{

    public bool DontDestroyEnabled = true;
    public AudioClip DedSoundt;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Scene��J�ڂ��Ă��I�u�W�F�N�g�������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {

        if (other.gameObject.tag == "Player")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {

            audioSource.PlayOneShot(DedSoundt);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         



        }
       

        
    }

















}
