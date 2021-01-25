using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour
{
    public Transform Y;
    public Transform X;
    GameObject fish;
    GameObject shark;

    void Start()
    {

        fish = GameObject.FindWithTag("Fish");
        shark = GameObject.FindWithTag("Shark");
        
    }

    void Update()
    {

        transform.position = new Vector3(X.transform.position.x, Y.position.y, 0) ;

        //print("Tubarão " + positionSharkY + " -- " + "Peixe " + positionFishY);
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(fish);
            
            SceneManager.LoadScene(1);
        
        }

    }
}
