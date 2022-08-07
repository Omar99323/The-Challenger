using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {  
       if(other.gameObject.CompareTag("Player"))
       {
           SceneManager.LoadScene("Complete");
       } 
    }
}
