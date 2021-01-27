using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criarObj : MonoBehaviour
{

    Move fundo1 = new Move();
    
    
    GameObject moeda;
    GameObject bomba;
    GameObject boost;
    GameObject lula;
    GameObject mancha;

    public GameObject cameraPosition;

    public GameObject bombaPrefab;
    public GameObject moedaPrefab;
    public GameObject boostPrefab;
    public GameObject lulaPrefab;
    public GameObject manchaPrefab;

    void Start()
    {

        GameObject obj = GameObject.Find("Peixe");

        fundo1 = obj.GetComponent<Move>();

        if(fundo1 == null){
        
            print("Fundo1 não encontrado");

        }

        
    }

    void Update()
    {

        if(moeda == null){

            moeda = GameObject.FindGameObjectWithTag("Moeda");

        } 

        if((int)moeda.transform.position.x == (int)fundo1.fundo.transform.position.x - 20){
            
            Destroy(moeda);
            criarMoeda();

        }

        if(bomba == null){

            bomba = GameObject.FindGameObjectWithTag("Bomba");

        } 

        if((int)bomba.transform.position.x == (int)fundo1.fundo.transform.position.x - 20){
           
            Destroy(bomba);
            criarBomba();

        }

        if(boost == null){

            boost = GameObject.FindGameObjectWithTag("Boost");

        } 

        if((int)boost.transform.position.x == (int)fundo1.fundo.transform.position.x - 20){
            
            Destroy(boost);
            criarBoost();

        }

        if(lula == null){

            lula = GameObject.FindGameObjectWithTag("Lula");

        } 

        if((int)lula.transform.position.x == (int)fundo1.fundo.transform.position.x - 20){
            
            Destroy(lula);
            criarLula();

        }

        if(mancha == null){

            mancha = GameObject.FindGameObjectWithTag("Mancha");

        } 

        mancha.transform.position = new Vector3(cameraPosition.transform.position.x, cameraPosition.transform.position.y);

    }

    void OnTriggerEnter2D (Collider2D outro) 
    {
        
        if(outro.gameObject.CompareTag("Boost")) {

            criarBoost();
        
        }

        if (outro.gameObject.CompareTag("Moeda"))
        {

            criarMoeda();
        
        }

        if(outro.gameObject.CompareTag("Bomba"))
        {

            criarBomba();

        }

        if(outro.gameObject.CompareTag("Lula"))
        {

            criarLula();
            criarMancha();
            StartCoroutine(manchaTempo());

        }

    }

    void criarMoeda(){

        Vector3 novo = new Vector3((int)fundo1.fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(moedaPrefab, novo, Quaternion.identity);
    
    }

    void criarBomba(){

        Vector3 novo = new Vector3((int)fundo1.fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(bombaPrefab, novo, Quaternion.identity);
    
    }
    
    void criarBoost(){

        Vector3 novo = new Vector3((int)fundo1.fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(boostPrefab, novo, Quaternion.identity);
    
    }

    void criarLula(){

        Vector3 novo = new Vector3((int)fundo1.fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(lulaPrefab, novo, Quaternion.identity);
    
    }

    void criarMancha(){
 
        Vector3 novo = new Vector3(cameraPosition.transform.position.x, cameraPosition.transform.position.y);
        GameObject.Instantiate(manchaPrefab, novo, Quaternion.identity);
               
    }

    IEnumerator manchaTempo(){

        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(mancha);
        
    }

}
