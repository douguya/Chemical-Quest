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


    public float pointx;//薬液機のマーカー
    public float pointy;
    public bool  RorLMeal;
    public bool  Wakeup;
    public GameObject player;


    public int SpoitCorer;//1=黄色　2=緑 3=青 4=赤
    private Animator SpoitYroww;//薬液機のアニメーター


    public AudioClip QSound;

    AudioSource audioSource;



    void Start()
    {
        SpoitYroww = GetComponent<Animator>();
        SpoitCorerChenge();
        SpoitYroww.SetBool("WakeUp", false);   //薬液機の起動コード

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       


        if (Wakeup == true && Player.WhatPortion ==0)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //能力発動
            {
               // Debug.Log("RRRRR");
                SpoitYroww.SetBool("WakeUp", true);　　 //薬液機の起動コード
                player.transform.position = new Vector2(pointx, pointy);
                Player.LorR = RorLMeal;
                Player.CanWalk = false;
                Player.CanSpase = false;



                Wakeup = false;
            }



        }





    }


    void OnTriggerStay2D(Collider2D other)//  地面に触れた時の処理
    {
       // Debug.Log("CCCCCCCCCCC");
        if (other.gameObject.tag == "SpoitJuje")//  もしPlayerというタグがついたオブジェクトに触れたら、
        {
         //   Debug.Log("DDDDDDDDD");
            Wakeup = true;
        }


    }

    void OnTriggerExit2D(Collider2D other)//  地面に触れた時の処理
    {
       // Debug.Log("CCCCCCCCCCC");
        if (other.gameObject.tag == "SpoitJuje")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
       //     Debug.Log("DDDDDDDDD");
            Wakeup = false;
        }


    }


    private void EndSpaseees()
    {
        SpoitYroww.SetBool("WakeUp", false); //薬液機の停止コード
       // Debug.Log("aaaaaaaaaaaaaaaaaaaaaaa");
    }




    private void SUitPlayer()
    {
        player.transform.position = new Vector3(pointx, pointy, 0); //指定下座標に送る
        Player.CanSpase = true;
    }



    private void GainPlayer()
    {
        player.transform.position = new Vector3(pointx, pointy, -14.57f);//終わった時も送る
    }

    private void COloerYerrow (){

          
        player.GetComponent<Player>().corrowYerrow();　//プレイヤーの色を黄色にする
        Player.CanWalk = true;
       

    }
    private void COloerGreen()
    {

        player.GetComponent<Player>().corrowGreen();　//プレイヤーの色を黄色にする
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
