using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScmeManagerScript : MonoBehaviour
{


    const   int TotalStageNum =8;  //���X�e�[�W���̎w��
    private int NowStageNum;�@�@�@�@//���݂̃X�e�[�W��
    public  int no;            �@�@�@//��̊m�F�p

    public GameObject Pupup;�@�@�@�@//��݃|�b�v�A�b�v�̃I�u�W�F�N�g
    public GameObject CreaPup;�@�@�@//�N���A���̃|�b�v�A�b�v�̃I�u�W�F�N�g
    public GameObject nextButton;�@ //���̃X�e�[�W�p�{�^���@�ŏI�X�e�[�W�ŏ�����΂��p
    public static int[] CreaStageSaveTo = new int[TotalStageNum + 1];
    public static bool[] CreaStage = new bool[TotalStageNum+1]//�X�e�[�W�N���A�̑����\
                                               { true, false, false, false ,false,false, false, false ,false};







    //0     1      2      3    �@
    public GameObject[] Stagebutton;//�X�e�[�W�I����ʈړ��p
    public  int[] CreaSaveTo = new int[TotalStageNum + 1];
    public AudioClip Fanfale;


    AudioSource audioSource;
    public int getNowStageNum()�@//���݂̃X�e�[�W���̎󂯓n���p
    {
        return NowStageNum;�@�@�@//���݂̃X�e�[�W����Ԃ�
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        PlayerPrefs.SetInt("Save" +0, 1);
        PlayerPrefs.Save();

        for (int loop = 0; loop <= TotalStageNum; loop++)//���݂̃X�e�[�W��������o���Ă���
        {�@                                              
            if (SceneManager.GetActiveScene().name == "Stage" + loop)//���O�{�X�e�[�W���Ŕ���
            {
                NowStageNum = loop;

               

            }
            Debug.Log(PlayerPrefs.GetInt("Save" + loop, 0)+"Save"+loop);
            CreaStageSaveTo[loop] = PlayerPrefs.GetInt("Save" + loop, 0);
            if (CreaStageSaveTo[loop] == 1)
            {
                CreaStage[loop] = true;

            }
            else
            {
                CreaStage[loop] = false;
            }
        }






    }

    void Update()
    {
       
        no = NowStageNum; //���݂̃X�e�[�W���C���X�y�N�^�[�Ŗڎ��m�F����


        CreaSaveTo = CreaStageSaveTo;



        if (SceneManager.GetActiveScene().name == "StageSelect")//�X�e�[�W�Z���N�g��ʂ��ǂ����𖼑O�{�X�e�[�W���Ŕ���
        {
            for (int loop = 1; loop < TotalStageNum+1; loop++)
            {
                if (CreaStage[loop - 1] == true)//�Y���X�e�[�W�O�̃X�e�[�W���N���A�ς݂��ǂ�������
                {
                    
                }
                else { }//�U�Ȃ琔��������

            }�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�����̃e�L�X�g��S���C���X�y�N�^�[�őI�����Ă邩�璼����������
        
    }


     














    }









    public void TransitionToTitle() �@�@�@//�^�C�g���ɔ��
    {
        SceneManager.LoadScene("Title");
    }

    public void TransitionToMain()�@�@�@�@//���C���ɔ��
    {
        SceneManager.LoadScene("Main");
    }

    public void TransitionToStageSelect()//�X�e�[�W�I����ʂɔ��
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void TransitionToStageNum(int a)//�����Ɏw�肵���ԍ��̃X�e�[�W�֔��
    {
        if (CreaStage[a-1] == true) { //�`�����ƃN���A���Ă邩�ǂ����̔���
         SceneManager.LoadScene("Stage" + a);
          }

    }


    public void TransitionToRestert()//���݂̃X�e�[�W�Ń��X�^�[�g
    {
        SceneManager.LoadScene("Stage" + NowStageNum);
    }


    public void TransitionToNextStage()//���̃X�e�[�W�ɔ��
    {
        SceneManager.LoadScene("Stage" + (NowStageNum + 1));
    }

    public void TransitionTobeforeStage()//�O�̃X�e�[�W�ɔ��
    {
        SceneManager.LoadScene("Stage" + (NowStageNum - 1));
    }

    public void Exsit()//�Q�[���I��
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }



    public void PopuUpApper()//��݃|�b�v�A�b�v�̏o��
    {
        Pupup.SetActive(true);
    }

    public void PopuUpGein()//��݃|�b�v�A�b�v�̏���
    {
        Pupup.SetActive(false);
    }


    public void PopuNext()//�N���A�������̃z�b�v�A�b�v
    {
        CreaPup.SetActive(true);//�N���A�S�̂̃z�b�v�A�b�v
        Debug.Log("adaw");
        audioSource.PlayOneShot(Fanfale);
        if (NowStageNum == TotalStageNum)//�ŏI�X�e�[�W�̔���
        {
            nextButton.SetActive(false);//�l�N�X�g�{�^���̏���
        }

    }


   






}
