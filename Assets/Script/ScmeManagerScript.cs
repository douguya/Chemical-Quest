using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScmeManagerScript : MonoBehaviour
{


    const   int TotalStageNum =8;  //総ステージ数の指定
    private int NowStageNum;　　　　//現在のステージ制
    public  int no;            　　　//上の確認用

    public GameObject Pupup;　　　　//常設ポップアップのオブジェクト
    public GameObject CreaPup;　　　//クリア時のポップアップのオブジェクト
    public GameObject nextButton;　 //次のステージ用ボタン　最終ステージで消し飛ばす用
    public static int[] CreaStageSaveTo = new int[TotalStageNum + 1];
    public static bool[] CreaStage = new bool[TotalStageNum+1]//ステージクリアの早見表
                                               { true, false, false, false ,false,false, false, false ,false};







    //0     1      2      3    　
    public GameObject[] Stagebutton;//ステージ選択画面移動用
    public  int[] CreaSaveTo = new int[TotalStageNum + 1];
    public AudioClip Fanfale;


    AudioSource audioSource;
    public int getNowStageNum()　//現在のステージ数の受け渡し用
    {
        return NowStageNum;　　　//現在のステージ数を返す
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        PlayerPrefs.SetInt("Save" +0, 1);
        PlayerPrefs.Save();

        for (int loop = 0; loop <= TotalStageNum; loop++)//現在のステージ数を割り出している
        {　                                              
            if (SceneManager.GetActiveScene().name == "Stage" + loop)//名前＋ステージ数で判別
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
       
        no = NowStageNum; //現在のステージをインスペクターで目視確認する


        CreaSaveTo = CreaStageSaveTo;



        if (SceneManager.GetActiveScene().name == "StageSelect")//ステージセレクト画面かどうかを名前＋ステージ数で判別
        {
            for (int loop = 1; loop < TotalStageNum+1; loop++)
            {
                if (CreaStage[loop - 1] == true)//該当ステージ前のステージがクリア済みかどうか判別
                {
                    
                }
                else { }//偽なら数字を消す

            }　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//数字のテキストを全部インスペクターで選択してるから直したい部分
        
    }


     














    }









    public void TransitionToTitle() 　　　//タイトルに飛ぶ
    {
        SceneManager.LoadScene("Title");
    }

    public void TransitionToMain()　　　　//メインに飛ぶ
    {
        SceneManager.LoadScene("Main");
    }

    public void TransitionToStageSelect()//ステージ選択画面に飛ぶ
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void TransitionToStageNum(int a)//引数に指定した番号のステージへ飛ぶ
    {
        if (CreaStage[a-1] == true) { //チャンとクリアしてるかどうかの判定
         SceneManager.LoadScene("Stage" + a);
          }

    }


    public void TransitionToRestert()//現在のステージでリスタート
    {
        SceneManager.LoadScene("Stage" + NowStageNum);
    }


    public void TransitionToNextStage()//次のステージに飛ぶ
    {
        SceneManager.LoadScene("Stage" + (NowStageNum + 1));
    }

    public void TransitionTobeforeStage()//前のステージに飛ぶ
    {
        SceneManager.LoadScene("Stage" + (NowStageNum - 1));
    }

    public void Exsit()//ゲーム終了
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }



    public void PopuUpApper()//常設ポップアップの出現
    {
        Pupup.SetActive(true);
    }

    public void PopuUpGein()//常設ポップアップの消滅
    {
        Pupup.SetActive(false);
    }


    public void PopuNext()//クリアした時のホップアップ
    {
        CreaPup.SetActive(true);//クリア全体のホップアップ
        Debug.Log("adaw");
        audioSource.PlayOneShot(Fanfale);
        if (NowStageNum == TotalStageNum)//最終ステージの判別
        {
            nextButton.SetActive(false);//ネクストボタンの消去
        }

    }


   






}
