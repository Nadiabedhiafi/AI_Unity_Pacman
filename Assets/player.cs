using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;
    public Text scoreText; 
    private int score = 0; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText();
    }

    private void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("gome"))
            {
                
                Destroy(hit.collider.gameObject);
                Debug.Log("Mangé!");
                score++;
                Debug.Log(score);
                UpdateScoreText();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
         if (collision.collider.CompareTag("gome"))
        {
            
            Destroy(collision.gameObject);
            Debug.Log("Mangé!");
             score++;
            Debug.Log(score);
            UpdateScoreText();

        }
     
        else if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("collider");
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            
            
        }
    }
     private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}