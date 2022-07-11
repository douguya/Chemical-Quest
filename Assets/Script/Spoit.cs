using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spoit : MonoBehaviour
{
    // Start is
    //
    //
    //
    // called before the first frame update


    public float pointx;//��t�@�̃}�[�J�[
    public float pointy;
    public bool  RorLMeal;
    public bool  Wakeup;
    public GameObject player;


    public int SpoitCorer;//1=���F�@2=�� 3=�� 4=��
    private Animator SpoitYroww;//��t�@�̃A�j���[�^�[


    public AudioClip QSound;

    AudioSource audioSource;



    void Start()
    {
        SpoitYroww = GetComponent<Animator>();
        SpoitCorerChenge();
        SpoitYroww.SetBool("WakeUp", false);   //��t�@�̋N���R�[�h

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       


        if (Wakeup == true && Player.WhatPortion ==0)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //�\�͔���
            {
               // Debug.Log("RRRRR");
                SpoitYroww.SetBool("WakeUp", true);�@�@ //��t�@�̋N���R�[�h
                player.transform.position = new Vector2(pointx, pointy);
                Player.LorR = RorLMeal;
                Player.CanWalk = false;
                Player.CanSpase = false;



                Wakeup = false;
            }



        }





    }


    void OnTriggerStay2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {
       // Debug.Log("CCCCCCCCCCC");
        if (other.gameObject.tag == "SpoitJuje")//  ����Player�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
         //   Debug.Log("DDDDDDDDD");
            Wakeup = true;
        }


    }

    void OnTriggerExit2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {
       // Debug.Log("CCCCCCCCCCC");
        if (other.gameObject.tag == "SpoitJuje")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
       //     Debug.Log("DDDDDDDDD");
            Wakeup = false;
        }


    }


    private void EndSpaseees()
    {
        SpoitYroww.SetBool("WakeUp", false); //��t�@�̒�~�R�[�h
       // Debug.Log("aaaaaaaaaaaaaaaaaaaaaaa");
    }




    private void SUitPlayer()
    {
        player.transform.position = new Vector3(pointx, pointy, 0); //�w�艺���W�ɑ���
        Player.CanSpase = true;
    }



    private void GainPlayer()
    {
        player.transform.position = new Vector3(pointx, pointy, -14.57f);//�I�������������
    }

    private void COloerYerrow (){

          
        player.GetComponent<Player>().corrowYerrow();�@//�v���C���[�̐F�����F�ɂ���
        Player.CanWalk = true;
       

    }
    private void COloerGreen()
    {

        player.GetComponent<Player>().corrowGreen();�@//�v���C���[�̐F�����F�ɂ���
        Player.CanWalk = true;
       
    }


    void SpoitCorerChenge()
    {

        SpoitYroww.SetInteger("SpoitCorer", SpoitCorer);




    }
    public void AQSound()
    {

        audioSource.PlayOneShot(QSound);
    }
    
         public void ANotQSound()
    {

        audioSource.Stop();
    }

}
