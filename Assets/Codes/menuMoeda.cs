﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class menuMoeda : MonoBehaviour
{

    public Text ponto;
    coletaMoeda peixe;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Peixe");
        peixe =  obj.GetComponent<coletaMoeda>();   
    }

    // Update is called once per frame
    void Update()
    {
        var valor = peixe.totalMoeda;
        ponto.text = valor.ToString();
        print(ponto.text);
    }
}
