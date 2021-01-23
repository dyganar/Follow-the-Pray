using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;

    GameObject peixe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        peixe = GameObject.FindWithTag("peixe");
        if(!peixe){

        } else {
            bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
        }
    }
}
