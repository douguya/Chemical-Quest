using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TPanel;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }





    void OnTriggerEnter2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {

        if (other.gameObject.tag == "Player")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            TPanel.SetActive(true);
        }



    }

    void OnTriggerExit2D(Collider2D other)//  �n�ʂɐG�ꂽ���̏���
    {

        if (other.gameObject.tag == "Player")//  ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            TPanel.SetActive(false);
        }



    }



}
