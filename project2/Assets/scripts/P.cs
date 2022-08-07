using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P : MonoBehaviour
{
    Rigidbody rb ;
    public AudioSource jumping ;
    public AudioSource coining ;
    public AudioSource dead ;
    private bool isgrounded = true ;
    private int coincounter = 0 ;
    private int score = 0 ;
    public Text cointext ;
    public Text scoretext ;
    public float movementspeed = 5f ;
    public float jumpspeed = 5f ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h =Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");
        rb.velocity = new Vector3( h*movementspeed , rb.velocity.y , v*movementspeed );

        if( Input.GetButtonDown("Jump") && isgrounded )
        {
            isgrounded = false ;
            Jump();
            jumping.Play();
        }
        
        if(transform.position.y < -5)
        {
            Die();
            dead.Play();
        }

        cointext.text = "Coins = " + coincounter ;

        score = score + 1 ;
        scoretext.text = "Score = " + score ;

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x , jumpspeed , rb.velocity.z);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false ;
            GetComponent<Rigidbody>().isKinematic = true ;
            GetComponent<P>().enabled = false ;
            Die();
            dead.Play();
        } 
        else if (other.gameObject.CompareTag("head"))   
        {
            Destroy(other.transform.parent.gameObject);
            Jump();
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isgrounded = true ;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coincounter ++ ;
            coining.Play();
        }
    }

    void Die()
    {
        Invoke(nameof(relife) , 0.1f );
    }

    void relife()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
