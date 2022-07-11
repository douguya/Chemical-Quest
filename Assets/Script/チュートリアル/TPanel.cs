using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public int panelN;
    private Animator Panel;
    void Start()
    {
        Panel = GetComponent<Animator>();
        Panel.SetInteger("PanelAnimethion", panelN);
    }

    // Update is called once per frame
    void Update()
    {

        Panel = GetComponent<Animator>();
        Panel.SetInteger("PanelAnimethion", panelN);











    }
}
