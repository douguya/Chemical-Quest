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
        if (SceneManager.GetActiveScene().name == "StageSelect")//�X�e�[�W�Z���N�g��ʂ��ǂ����𖼑O�{�X�e�[�W���Ŕ���
        {
            if (FastJuje==true) {
                BottonImage = this.gameObject.GetComponent<Image>();
                StageBottunSprite = BottonImage.sprite;
                NotCrearStageBottunSprite= Resources.Load<Sprite>("NotCrearStage") as Sprite; 
                FastJuje = false;
             }
          //  Debug.Log("StageButton");

                if (ScmeManagerScript.CreaStage[StaGeButtonNum - 1] == true)//�Y���X�e�[�W�O�̃X�e�[�W���N���A�ς݂��ǂ�������
                {
                    BottonImage.sprite = StageBottunSprite;//�^�Ȃ琔����\������
                GetComponent<Button>().enabled = true;
                }
                else { BottonImage.sprite = NotCrearStageBottunSprite;
                GetComponent<Button>().enabled = false;
                         }//�U�Ȃ琔��������

            //�����̃e�L�X�g��S���C���X�y�N�^�[�őI�����Ă邩�璼����������

        }





    }

    // Update is called once per frame
    void Update()
    {
        













    }
}
