using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float vel = 5.7f;
    int coin;
    public bool coleta;
    public int totalMoeda = 0;
    
    public GameObject bombaPrefab;
    public GameObject moedaPrefab;
    public GameObject boostPrefab;
    private SpriteRenderer mySpriteRenderer;

    moveFundo1 back;
    
    public GameObject fundo;

    GameObject moeda;
    GameObject bomba;
    GameObject boost;

    void Start() {
        coleta = false;
        GameObject obj = GameObject.Find("Quad");
        if(obj!=null){
            back = obj.GetComponent<moveFundo1>();
            if(back == null){
                print("Back não encontrado");
            }
        } else {
            print("Quad não encontrado");
        }
        
    }
    
    void Update() {
        transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));
 
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(new Vector3(0, vel * Time.deltaTime, 0));
        
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            transform.Translate(new Vector3(0, -vel * Time.deltaTime, 0));   
             
        }

        if(fundo == null){
            fundo = GameObject.FindGameObjectWithTag("fundo");
        }
        
        if(moeda == null){
            moeda = GameObject.FindGameObjectWithTag("Moeda");
        } 

        if((int)moeda.transform.position.x == (int)fundo.transform.position.x - 20){
            Destroy(moeda);
            criarMoeda();
        }
        if(bomba == null){
            bomba = GameObject.FindGameObjectWithTag("Bomba");
        } 

        if((int)bomba.transform.position.x == (int)fundo.transform.position.x - 20){
            Destroy(bomba);
            criarBomba();
        }

        if(boost == null){
            boost = GameObject.FindGameObjectWithTag("Boost");
        } 

        if((int)boost.transform.position.x == (int)fundo.transform.position.x - 20){
            Destroy(boost);
            criarBoost();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bomba"))
        {
            vel = 3f;
            back.bgSpeed = 0.05f;
            Destroy(collision.gameObject);
            StartCoroutine(debuffer());
            criarBomba();
        }
    }

    void OnTriggerEnter2D (Collider2D outro) 
    {
        coleta = true;
        if (outro.gameObject.CompareTag("Moeda"))
        {

            if (coleta == true)
            {
                totalMoeda++;
                print(totalMoeda);
                Destroy(outro.gameObject);
                criarMoeda();
            }

        }

        if(outro.gameObject.CompareTag("Boost")) {
            vel = 7f;
            Destroy(outro.gameObject);
            back.bgSpeed = 0.2f;
            StartCoroutine(debuffer());
            criarBoost();
        }

    }

    void OnTriggerExit2D (Collider2D outro) 
    {
        coleta = false;
    }

    IEnumerator debuffer(){
        yield return new WaitForSecondsRealtime(2);
        vel = 5.7f;
        back.bgSpeed = 0.1f;
    }

    void criarMoeda(){
        Vector3 novo = new Vector3((int)fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(moedaPrefab, novo, Quaternion.identity);
    }

    void criarBomba(){
        Vector3 novo = new Vector3((int)fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(bombaPrefab, novo, Quaternion.identity);
    }
    void criarBoost(){
        Vector3 novo = new Vector3((int)fundo.transform.position.x+20, Random.Range(-8, 8), 0);
        GameObject.Instantiate(boostPrefab, novo, Quaternion.identity);
    }


}
