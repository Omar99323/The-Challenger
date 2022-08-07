using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public GameObject[] range ;
    public float speed = 1f ;
    int pointindex = 0 ;
    void Update()
    {
        if(Vector3.Distance(transform.position , range[pointindex].transform.position) < 0.1f )
        {
            pointindex++ ;
            if(pointindex >= range.Length)
            {
                pointindex = 0 ;
            }
        }
        
        transform.position = Vector3.MoveTowards( transform.position , range[pointindex].transform.position , speed*Time.deltaTime );

    }
}
