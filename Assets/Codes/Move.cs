using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float vel = 5.7f;

    moveFundo1 back;
    public GameObject fundo;
    public GameObject manchaPrefab;
    public GameObject lula;

    void Start() {
        
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
        
    } 
    

    void OnTriggerEnter2D (Collider2D outro) 
    {
        
        if(outro.gameObject.CompareTag("Boost")) {

            vel = 7f;
            Destroy(outro.gameObject);
            back.bgSpeed = 0.2f;
            StartCoroutine(debuffer());

        }

        if(outro.gameObject.CompareTag("Bomba"))
        {

            vel = 3f;
            back.bgSpeed = 0.03f;
            Destroy(outro.gameObject);
            StartCoroutine(debuffer());

        }

        if(outro.gameObject.CompareTag("Lula")) {

            vel = 5;
            back.bgSpeed = 0.06f;
            Destroy(outro.gameObject);
            StartCoroutine(tempolula());

        }

    }

    IEnumerator debuffer(){

        yield return new WaitForSecondsRealtime(2);
        vel = 5.7f;
        back.bgSpeed = 0.1f;

    }

    IEnumerator tempolula(){

        yield return new WaitForSecondsRealtime(2.5f);
        vel = 5.7f;
        back.bgSpeed = 0.1f;
        
    }

}
