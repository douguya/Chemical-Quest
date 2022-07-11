using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageButton : MonoBehaviour
{
    // Start is called before the first frame update



    


    Image BottonImage;
    Sprite  StageBottunSprite;
    Sprite NotCrearStageBottunSprite;
    public int StaGeButtonNum;
    bool FastJuje=true;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StageSelect")//ステージセレクト画面かどうかを名前＋ステージ数で判別
        {
            if (FastJuje==true) {
                BottonImage = this.gameObject.GetComponent<Image>();
                StageBottunSprite = BottonImage.sprite;
                NotCrearStageBottunSprite= Resources.Load<Sprite>("NotCrearStage") as Sprite; 
                FastJuje = false;
             }
          //  Debug.Log("StageButton");

                if (ScmeManagerScript.CreaStage[StaGeButtonNum - 1] == true)//該当ステージ前のステージがクリア済みかどうか判別
                {
                    BottonImage.sprite = StageBottunSprite;//真なら数字を表示する
                GetComponent<Button>().enabled = true;
                }
                else { BottonImage.sprite = NotCrearStageBottunSprite;
                GetComponent<Button>().enabled = false;
                         }//偽なら数字を消す

            //数字のテキストを全部インスペクターで選択してるから直したい部分

        }





    }

    // Update is called once per frame
    void Update()
    {
        













    }
}
