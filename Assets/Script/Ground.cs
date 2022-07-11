using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    

    private bool Green=false;
    private bool Move=false;
    private bool SideORButtom = false;
    private bool RorL=false;
    private float Mobespead;
    private Vector3 pos;
    private float X;
    private float Y;

    public AudioClip GroundSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (this.gameObject.tag=="GreenGround")
        {
            audioSource.PlayOneShot(GroundSound);
            //Debug.Log("midori");
            Green = true;
            Move = true;
            X = Player.GreenX;
            Y = Player.GreenY;
            pos = this.transform.position;
            pos.x -= 0.01f;
            pos.y -= 0.01f;
            this.transform.position = pos;
            pos.x += 0.01f;
            pos.y += 0.01f;
            this.transform.position = pos;
           // Debug.Log("数値："+(Player.PlayerY- this.transform.position.y) );
            if ( Player.PlayerY- this.transform.position.y <= 0.6)
            {

                SideORButtom = true;
            }
            else {
                SideORButtom = false;
            }

            RorL = Player.LorR;
            

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
       
       
        if (Green==true)
        {
            if (Move==true)
            {
               
                if (SideORButtom == true)
                {

                    if (RorL == true)
                    {
                        //Debug.Log("side");
                        pos.x -= 0.01f;
                     
                        this.transform.position=pos;
                        if (pos.x <= Player.GreenX - 1.109)
                        {
                            Move = false;
                           // audioSource.Stop();
                        }
                    }
                    if (RorL == false)
                    {
                     //   Debug.Log("side");
                        pos.x += 0.01f;
                     //   audioSource.PlayOneShot(GroundSound);
                        this.transform.position = pos;
                        if (pos.x >= Player.GreenX+ 1.109)
                        {
                            Move = false;
                           // audioSource.Stop();
                        }
                    }
                }
                if (SideORButtom==false)
                {
                    //Debug.Log("buttom");
                    pos.y += 0.01f;
                  //  audioSource.PlayOneShot(GroundSound);
                    this.transform.position = pos;
                    if (pos.y >= Player.GreenY + 1.109)
                    {
                       
                        Move = false;
                      //  audioSource.Stop();
                    }


                }

            }

        }










    }


   void Assid()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "AssidSide")//  もしAssidというタグがついたオブジェクトに触れたら、
        {
           // Debug.Log("side");
            Player.SideButtom = true;
            BUttonSound.Assidjuje = true;
            this.gameObject.SetActive(false); //地面が消え去る
           
        }
        if (other.gameObject.tag == "AssidBotoom")//  もしAssidというタグがついたオブジェクトに触れたら、
        {
            // Debug.Log("Butttom");
            BUttonSound.Assidjuje = true;
            this.gameObject.SetActive(false); //地面が消え去る
         
        }
        if (other.gameObject.tag == "GreenJuje")//  もしAssidというタグがついたオブジェクトに触れたら、
        {
          //  Debug.Log("GreenJuje");
            Player.GreenORnot = true;
            Player.SideButtom = true;
            Player.GreenX = this.gameObject.transform.position.x;
            Player.GreenY = this.gameObject.transform.position.y;
            SideORButtom = true;
            RorL = Player.LorR;
           
        }
        
        if (other.gameObject.tag == "GreenPoint")//  もしAssidというタグがついたオブジェクトに触れたら、
        {
         //   Debug.Log("GreenPoint");
            Player.GreenORnot =true;


            if (Player.SideButtom ==false) {
                Player.GreenX = this.gameObject.transform.position.x;
                Player.GreenY = this.gameObject.transform.position.y;
                SideORButtom = false;
                RorL = Player.LorR;
               
            }
        }






    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (this.gameObject.tag == "GreenGround"&&Move==false&& other.gameObject.tag == "GreenStandJuje")//  もしAssidというタグがついたオブジェクトに触れたら、
            {
          //  Debug.Log("Dreet");
            Invoke("deleet",0.3f);
            }

        
    


    }

    void deleet()
    {
        
        this.gameObject.SetActive(false); //地面が消え去る
    }







}
