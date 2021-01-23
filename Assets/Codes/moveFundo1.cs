using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFundo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float bgSpeed = 0.1f;
    public Renderer bgRend;
    public GameObject peixe;

    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(peixe.transform.position.x, 0);

        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
