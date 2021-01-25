using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMoveShark : MonoBehaviour
{
    float vel = 5.7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            vel = 0f;
        }
    }
}
