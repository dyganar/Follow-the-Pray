using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubarao : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fish;
    GameObject shark;

    int direcao = 1;
    void Start()
    {
        shark = GameObject.FindWithTag("tubarao");
        fish = GameObject.FindWithTag("peixe");
    }
    // Update is called once per frame
    void Update()
    {
        int positionFish =  (int)fish.transform.position.y;
        int positionShark = (int)shark.transform.position.y;

        if (positionFish - positionShark > 0.5)
        {
            direcao = 1;
            transform.Translate(new Vector2(0, direcao));
          
        } else if (positionFish - positionShark == 0.5 || positionFish - positionShark == -0.5)
        {
            transform.Translate(new Vector2(0, 0));
        } else if (positionFish - positionShark < -0.5)
        {
            direcao = -1;
            transform.Translate(new Vector2(0, direcao));
        }
    }
}
