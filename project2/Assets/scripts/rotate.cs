using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    
    public float rotspeed = 0.5f ;
    void Update()
    {
        transform.Rotate(0 , 180  * Time.deltaTime ,0 );
    }
    
}
