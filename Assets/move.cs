using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    float vel = 5.7f;
    public bool coleta;
    public bool deuRuim;

    public int totalMoeda = 0;

    public GameObject moedasRandomicasPrefab;
    public GameObject algasRandomicasPrefab;
    
    GameObject moeda;
    GameObject alga;
    void Start()
    {
        coleta = false;
        deuRuim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector2(0, vel * Time.deltaTime));
        } else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            transform.Translate(new Vector2(0, -vel * Time.deltaTime));
        }
        if(moeda == null){
            moeda = GameObject.FindGameObjectWithTag("Moeda");
        }
        
        if((int)moeda.transform.position.x == -10){
            Destroy(moeda);
            criarMoeda();
        }
        if(alga == null){
            alga = GameObject.FindGameObjectWithTag("algas");
        }
        
        if((int)alga.transform.position.x == -10){
            Destroy(alga);
            criarAlga();
        }

    }

    void OnTriggerEnter2D(Collider2D outro) {
        coleta = true;
        deuRuim = true;
        if(outro.gameObject.CompareTag("Moeda")){
            if(coleta){
                totalMoeda++;
                Destroy(outro.gameObject);
                criarMoeda();
            }
        }
        if(outro.gameObject.CompareTag("algas")){
            if(deuRuim){
                atrasarPeixe();
                Destroy(outro.gameObject);
                criarAlga();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D outro) {
        if(outro.gameObject.CompareTag("tubarao")){
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerExit2D(Collider2D outro) {
        coleta=false;
        deuRuim=false;
    }
    void criarMoeda(){
        Vector3 novo = new Vector3(10,Random.Range(-5f, 5f),0);
        GameObject.Instantiate(moedasRandomicasPrefab, novo, Quaternion.identity);
    }

    void atrasarPeixe(){
        this.transform.Translate(new Vector2((this.transform.position.x - 0.25f), 0));
    }

    void criarAlga(){
        Vector3 novo = new Vector3(10,Random.Range(-5f, 5f),0);
        GameObject.Instantiate(algasRandomicasPrefab, novo, Quaternion.identity);
    }

}
