using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float vel = 5.7f;
    int coin;
    public bool coleta;
    public int totalMoeda = 0;
    public GameObject bomba;
    public GameObject boost;
    private SpriteRenderer mySpriteRenderer;

    public moveFundo1 back;
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
    
    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bomba"))
        {
            vel = 3f;
            Destroy(bomba);
            StartCoroutine(debuffer());
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
            }

        }

        if(outro.gameObject.CompareTag("Boost")) {
            vel = 7f;
            Destroy(boost);
            back.bgSpeed = 0.2f;
            StartCoroutine(debuffer());
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

    


}
