using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform ObjASeguir;
    
    public void Start()
    {
    
    }

    public void Update()
    {
        
        transform.position = new Vector3(ObjASeguir.position.x, ObjASeguir.position.y, -40);

    }

    
}
