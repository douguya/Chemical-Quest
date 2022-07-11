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





    void OnTriggerEnter2D(Collider2D other)//  地面に触れた時の処理
    {

        if (other.gameObject.tag == "Player")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            TPanel.SetActive(true);
        }



    }

    void OnTriggerExit2D(Collider2D other)//  地面に触れた時の処理
    {

        if (other.gameObject.tag == "Player")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            TPanel.SetActive(false);
        }



    }



}
