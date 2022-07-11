using UnityEngine;
public class Player : MonoBehaviour
{


    public AudioClip SpaseSound;
    public AudioClip ZunmpSound;
    public AudioClip PanickSound;

    AudioSource audioSource;




    Rigidbody2D rb;
    // public GameObject Coin;　　  //生成物のオブジェクト
    public GameObject SeneManager;  //シーンマネージェーのゲームオブジェクト
    GameObject AScore;              //スコアのゲームオブジェクト
    public GameObject AssidSide;
    public GameObject AssidButtum;
    public GameObject GreenBlock;
    public GameObject GreenJuje;
    public GameObject GreenPoint;



    public static bool SideButtom;//Side true   Buttom false
    public bool  Sidem;
    public static bool GreenORnot=false;
    public static float GreenX;
    public static float GreenY;
    //Score ScoreaA;　　　　　　　　//スコアのスクリプト用
    ScmeManagerScript ScmeManagerSt;//シーンマネージャーのスクリプト

    private Animator Playeranime;   //プレイヤーのアニメーター
   

    public float jump;　　  　//ジャンプの高さ
    public int   nowJump = 1; //ジャンプのカウント
    public float speed;       //移動スピード
    public int   Cost;        //能力発動のコスト

   

    public static bool LorR;//右ture 左faklse
    public static bool CanWalk;//Can true  Can't false
    public static bool CanSpase;//Can true  Can't false

    public static bool StageCrea;//現在のステージのクリアの成否


    public static float PlayerX;　//現在のｘ座標
    public static float PlayerY; //現在のｙ座標

   // float XX;//アニメーション移動用ｘ
  //  float YY;//アニメーション移動用y
    public bool inSpase;
   private int Portion;//０＝白１＝黄色
   public static int WhatPortion;//０＝白１＝黄色



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //    AScore = GameObject.Find("Score.en");　　　　 //スコアのゲームオブジェクト指定
         SeneManager = GameObject.Find("SceneManager");     //シーンマネージャーの指定
         ScmeManagerSt= SeneManager.GetComponent<ScmeManagerScript>();//シーンマネージャーのスクリプト
        //      ScoreaA = AScore.GetComponent<Score>();//よくわからん
        StageCrea = false;　　　　　　　　　　　　　　　　　//ステージクリア状態の否定か
        Playeranime = GetComponent<Animator>();
        LorR = true;                                        //左右　　最初は右向き
        //inSpase = false;　　　　　　　　　　　　　　　　　　//
        Playeranime.SetBool("Spase", false);                //
        CanWalk = true;
        CanSpase= true;
        Portion=0;//０＝白１＝黄色
        audioSource = GetComponent<AudioSource>();
    }









    void Update()
    {
        Sidem = SideButtom;
        LorRScale();
        WhatPortion = Portion;


        if (StageCrea == false)           //ステージ攻略中なら
        {
            //Debug.Log(Portion);　　　　　　//今の色教えて

            PlayerX = this.transform.position.x;//座標の取得
            PlayerY = this.transform.position.y;//

            if (Portion == 0)　　　　　　　//白
            {
                //Debug.Log("白");
                Playeranime.SetInteger("Colour", 0);
            }

            if (Portion == 1)　　　　　　　//黄色
            {
               // Debug.Log("黄色");
                Playeranime.SetInteger("Colour", 1);
            }
            if (Portion == 2)　　　　　　　//黄色
            {
                // Debug.Log("緑色");
                Playeranime.SetInteger("Colour", 2);
            }



            if (nowJump == 0)             //ジャンプしてない時
            {
                if (Input.GetKeyDown(KeyCode.Space)&&CanSpase==true) //能力発動
                {
                    Playeranime.SetBool("Spase", true);
                  //  Debug.Log("BBBBBBBBBBBBBBBBBBBB");
                    Playeranime.SetBool("walk", false); //移動を止める
                    rb.velocity = new Vector2(0, rb.velocity.y);//移動を止める
                    //inSpase = true;
                    nowJump++;

                }

            }




            if (Playeranime.GetBool("Spase")==false) {

                if (nowJump <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.W))//ジャンプ
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jump);
                        nowJump++;
                        audioSource.PlayOneShot(ZunmpSound);

                    }
                }

                if (Input.GetKey(KeyCode.D) && CanWalk == true)//右に歩く
                {

                    rb.velocity = new Vector2(speed, rb.velocity.y);//速度を与える
                    LorR = true;                                    //右向き
                                     //左右変更
                    Playeranime.SetBool("walk", true);        //歩くアニメーションの奴
                }
                else if (Input.GetKey(KeyCode.A) && CanWalk == true)//左に歩く
                {

                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    LorR = false;
                  
                    Playeranime.SetBool("walk", true);
              
                }
                else
                {
                    Playeranime.SetBool("walk", false); //何もない時は移動速度を殺す
       
                    rb.velocity = new Vector2(0, rb.velocity.y);//左右移動を直そうとするならここが大事だ！！

                }  //何も押してないときは横の速度０

            }

　        }

  　  }

    void OnCollisionEnter2D(Collision2D other)//  地面に触れた時の処理
    {
       /// Debug.Log("aaa");
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            nowJump = 0;//  ジャンプ回復
        }





    }
    void OnTriggerEnter2D(Collider2D other)//  地面に触れた時の処理
    {
      
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            nowJump = 0;// ジャンプ回復
        }
        if (other.gameObject.tag == "Goal")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
           // Goal.SetBool("Goal", true);

           // StageCrea = true;        //ステージのクリア
                                     // ScmeManagerSt.PopuNext();　　　　//クリア時のポップアップ出現
          // this.gameObject. SetActive(false);
        }
        if (other.gameObject.tag == "Stqgeend")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            // Goal.SetBool("Goal", true);
          //  Debug.Log("Stqgeend");
          
            StageCrea = true;        //ステージのクリア
            ScmeManagerScript.CreaStage[ScmeManagerSt.getNowStageNum()] = true;
     
            PlayerPrefs.SetInt("Save" + ScmeManagerSt.getNowStageNum(), 1);
            PlayerPrefs.Save();
            ScmeManagerSt.PopuNext();                       // ScmeManagerSt.PopuNext();　　　　//クリア時のポップアップ出現
                                                            // this.gameObject. SetActive(false);


        }
    }



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            nowJump = 0;//  ジャンプ回復
        }
    }






    private void PutCoin() {


        // Instantiate(Coin, new Vector2(x, y - 0.5f), Quaternion.identity);//出現

    }



    private void LorRScale()
    {

        if (LorR == true) {
            this.transform.localScale = new Vector3(0.30f, 0.30f, 1);　　//右向かせる
            //transform.position = new Vector2(x +1.302f, y);
        }
        else
        {
            this.transform.localScale = new Vector3(-0.30f, 0.30f, 1);//左向かせる
            // transform.position = new Vector2(x - 1.302f, y);
        }

    }


    private void EndSpase()
    {
        Playeranime.SetBool("Spase", false);//薬品流し終わり

     //   Debug.Log("EndSpase");
    }

    // Update is called once per frame
    void FixedUpdate()
    {







    }


    public void corrowYerrow()
    {
       // Debug.Log("いろ");//色が黄色い時
        Portion = 1;
    }
    public void corrowGreen()
    {
        // Debug.Log("いろ");//色が黄色い時
        Portion = 2;
    }


    public void corrownossingw()
    {
      //  Debug.Log("いろ");//色が白い時
        Portion = 0;
    }


    public void PUPAssid()
    {

        
        if (Portion == 1) {　　//酸まき散らす
            SideButtom = false;
            AssidSide.SetActive(true);
        }
    }
    public void PUPAssidButtom()
    {
        
        if (Portion == 1 && SideButtom == false)
        {  //酸まき散らす
            AssidButtum.SetActive(true);
        }
    }

    public void PUPgein()
    {
        AssidSide.SetActive(false);//まき散らし終わり
        AssidButtum.SetActive(false);//まき散らし終わり

    }


    public void PUPgreenJuje()
    {


        if (Portion == 2)
        {  //酸まき散らす
            GreenORnot = false;
            SideButtom = false;
            GreenJuje.SetActive(true);
        }
    }
    public void PUPGreenpoint()
    {

        if (Portion == 2 && SideButtom == false)
        {  //酸まき散らす
            GreenPoint.SetActive(true);
        }
    }

    public void GreenGein()
    {
        GreenJuje.SetActive(false);//まき散らし終わり
        GreenPoint.SetActive(false);//まき散らし終わり

    }


  
         public void GreenBlockPop()
    {
        if (GreenORnot==true) {
            Instantiate(GreenBlock, new Vector2(GreenX, GreenY), Quaternion.identity);
        }
    }

    public void APanickSound()
    {
        
        audioSource.PlayOneShot(PanickSound);
    }
    public void ASpaseSound()
    {
       
        audioSource.PlayOneShot(SpaseSound);
    }

}
