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


    void OnTriggerEnter2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {
       // Debug.Log("goal");
        if (other.gameObject.tag == "Player")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            Goaln.SetBool("Goal", true);

          //�N���A���̃|�b�v�A�b�v�o��
        }

    }






    public void ADore()
    {
        Debug.Log("MousePointSound");
        audioSource.PlayOneShot(DoerSOund);
    }







}
