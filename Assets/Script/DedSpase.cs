using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DedSpase : MonoBehaviour
{

    public bool DontDestroyEnabled = true;
    public AudioClip DedSoundt;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)//  地面に触れた時の処理
    {

        if (other.gameObject.tag == "Player")//  もしGroundというタグがついたオブジェクトに触れたら、
        {

            audioSource.PlayOneShot(DedSoundt);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         



        }
       

        
    }

















}
