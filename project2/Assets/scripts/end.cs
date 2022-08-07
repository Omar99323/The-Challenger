using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {  
       if(other.gameObject.CompareTag("Player"))
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
       } 
    }
}
