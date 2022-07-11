using UnityEngine;
public class Player : MonoBehaviour
{


    public AudioClip SpaseSound;
    public AudioClip ZunmpSound;
    public AudioClip PanickSound;

    AudioSource audioSource;




    Rigidbody2D rb;
    // public GameObject Coin;�@�@  //�������̃I�u�W�F�N�g
    public GameObject SeneManager;  //�V�[���}�l�[�W�F�[�̃Q�[���I�u�W�F�N�g
    GameObject AScore;              //�X�R�A�̃Q�[���I�u�W�F�N�g
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
    //Score ScoreaA;�@�@�@�@�@�@�@�@//�X�R�A�̃X�N���v�g�p
    ScmeManagerScript ScmeManagerSt;//�V�[���}�l�[�W���[�̃X�N���v�g

    private Animator Playeranime;   //�v���C���[�̃A�j���[�^�[
   

    public float jump;�@�@  �@//�W�����v�̍���
    public int   nowJump = 1; //�W�����v�̃J�E���g
    public float speed;       //�ړ��X�s�[�h
    public int   Cost;        //�\�͔����̃R�X�g

   

    public static bool LorR;//�Eture ��faklse
    public static bool CanWalk;//Can true  Can't false
    public static bool CanSpase;//Can true  Can't false

    public static bool StageCrea;//���݂̃X�e�[�W�̃N���A�̐���


    public static float PlayerX;�@//���݂̂����W
    public static float PlayerY; //���݂̂����W

   // float XX;//�A�j���[�V�����ړ��p��
  //  float YY;//�A�j���[�V�����ړ��py
    public bool inSpase;
   private int Portion;//�O�����P�����F
   public static int WhatPortion;//�O�����P�����F



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //    AScore = GameObject.Find("Score.en");�@�@�@�@ //�X�R�A�̃Q�[���I�u�W�F�N�g�w��
         SeneManager = GameObject.Find("SceneManager");     //�V�[���}�l�[�W���[�̎w��
         ScmeManagerSt= SeneManager.GetComponent<ScmeManagerScript>();//�V�[���}�l�[�W���[�̃X�N���v�g
        //      ScoreaA = AScore.GetComponent<Score>();//�悭�킩���
        StageCrea = false;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�X�e�[�W�N���A��Ԃ̔ے肩
        Playeranime = GetComponent<Animator>();
        LorR = true;                                        //���E�@�@�ŏ��͉E����
        //inSpase = false;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//
        Playeranime.SetBool("Spase", false);                //
        CanWalk = true;
        CanSpase= true;
        Portion=0;//�O�����P�����F
        audioSource = GetComponent<AudioSource>();
    }









    void Update()
    {
        Sidem = SideButtom;
        LorRScale();
        WhatPortion = Portion;


        if (StageCrea == false)           //�X�e�[�W�U�����Ȃ�
        {
            //Debug.Log(Portion);�@�@�@�@�@�@//���̐F������

            PlayerX = this.transform.position.x;//���W�̎擾
            PlayerY = this.transform.position.y;//

            if (Portion == 0)�@�@�@�@�@�@�@//��
            {
                //Debug.Log("��");
                Playeranime.SetInteger("Colour", 0);
            }

            if (Portion == 1)�@�@�@�@�@�@�@//���F
            {
               // Debug.Log("���F");
                Playeranime.SetInteger("Colour", 1);
            }
            if (Portion == 2)�@�@�@�@�@�@�@//���F
            {
                // Debug.Log("�ΐF");
                Playeranime.SetInteger("Colour", 2);
            }



            if (nowJump == 0)             //�W�����v���ĂȂ���
            {
                if (Input.GetKeyDown(KeyCode.Space)&&CanSpase==true) //�\�͔���
                {
                    Playeranime.SetBool("Spase", true);
                  //  Debug.Log("BBBBBBBBBBBBBBBBBBBB");
                    Playeranime.SetBool("walk", false); //�ړ����~�߂�
                    rb.velocity = new Vector2(0, rb.velocity.y);//�ړ����~�߂�
                    //inSpase = true;
                    nowJump++;

                }

            }




            if (Playeranime.GetBool("Spase")==false) {

                if (nowJump <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.W))//�W�����v
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jump);
                        nowJump++;
                        audioSource.PlayOneShot(ZunmpSound);

                    }
                }

                if (Input.GetKey(KeyCode.D) && CanWalk == true)//�E�ɕ���
                {

                    rb.velocity = new Vector2(speed, rb.velocity.y);//���x��^����
                    LorR = true;                                    //�E����
                                     //���E�ύX
                    Playeranime.SetBool("walk", true);        //�����A�j���[�V�����̓z
                }
                else if (Input.GetKey(KeyCode.A) && CanWalk == true)//���ɕ���
                {

                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    LorR = false;
                  
                    Playeranime.SetBool("walk", true);
              
                }
                else
                {
                    Playeranime.SetBool("walk", false); //�����Ȃ����͈ړ����x���E��
       
                    rb.velocity = new Vector2(0, rb.velocity.y);//���E�ړ��𒼂����Ƃ���Ȃ炱�����厖���I�I

                }  //���������ĂȂ��Ƃ��͉��̑��x�O

            }

�@        }

  �@  }

    void OnCollisionEnter2D(Collision2D other)//  �n�ʂɐG�ꂽ���̏���
    {
       /// Debug.Log("aaa");
        if (other.gameObject.tag == "Ground")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            nowJump = 0;//  �W�����v��
        }





    }
    void OnTriggerEnter2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {
      
        if (other.gameObject.tag == "Ground")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            nowJump = 0;// �W�����v��
        }
        if (other.gameObject.tag == "Goal")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
           // Goal.SetBool("Goal", true);

           // StageCrea = true;        //�X�e�[�W�̃N���A
                                     // ScmeManagerSt.PopuNext();�@�@�@�@//�N���A���̃|�b�v�A�b�v�o��
          // this.gameObject. SetActive(false);
        }
        if (other.gameObject.tag == "Stqgeend")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            // Goal.SetBool("Goal", true);
          //  Debug.Log("Stqgeend");
          
            StageCrea = true;        //�X�e�[�W�̃N���A
            ScmeManagerScript.CreaStage[ScmeManagerSt.getNowStageNum()] = true;
     
            PlayerPrefs.SetInt("Save" + ScmeManagerSt.getNowStageNum(), 1);
            PlayerPrefs.Save();
            ScmeManagerSt.PopuNext();                       // ScmeManagerSt.PopuNext();�@�@�@�@//�N���A���̃|�b�v�A�b�v�o��
                                                            // this.gameObject. SetActive(false);


        }
    }



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            nowJump = 0;//  �W�����v��
        }
    }






    private void PutCoin() {


        // Instantiate(Coin, new Vector2(x, y - 0.5f), Quaternion.identity);//�o��

    }



    private void LorRScale()
    {

        if (LorR == true) {
            this.transform.localScale = new Vector3(0.30f, 0.30f, 1);�@�@//�E��������
            //transform.position = new Vector2(x +1.302f, y);
        }
        else
        {
            this.transform.localScale = new Vector3(-0.30f, 0.30f, 1);//����������
            // transform.position = new Vector2(x - 1.302f, y);
        }

    }


    private void EndSpase()
    {
        Playeranime.SetBool("Spase", false);//��i�����I���

     //   Debug.Log("EndSpase");
    }

    // Update is called once per frame
    void FixedUpdate()
    {







    }


    public void corrowYerrow()
    {
       // Debug.Log("����");//�F�����F����
        Portion = 1;
    }
    public void corrowGreen()
    {
        // Debug.Log("����");//�F�����F����
        Portion = 2;
    }


    public void corrownossingw()
    {
      //  Debug.Log("����");//�F��������
        Portion = 0;
    }


    public void PUPAssid()
    {

        
        if (Portion == 1) {�@�@//�_�܂��U�炷
            SideButtom = false;
            AssidSide.SetActive(true);
        }
    }
    public void PUPAssidButtom()
    {
        
        if (Portion == 1 && SideButtom == false)
        {  //�_�܂��U�炷
            AssidButtum.SetActive(true);
        }
    }

    public void PUPgein()
    {
        AssidSide.SetActive(false);//�܂��U�炵�I���
        AssidButtum.SetActive(false);//�܂��U�炵�I���

    }


    public void PUPgreenJuje()
    {


        if (Portion == 2)
        {  //�_�܂��U�炷
            GreenORnot = false;
            SideButtom = false;
            GreenJuje.SetActive(true);
        }
    }
    public void PUPGreenpoint()
    {

        if (Portion == 2 && SideButtom == false)
        {  //�_�܂��U�炷
            GreenPoint.SetActive(true);
        }
    }

    public void GreenGein()
    {
        GreenJuje.SetActive(false);//�܂��U�炵�I���
        GreenPoint.SetActive(false);//�܂��U�炵�I���

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
