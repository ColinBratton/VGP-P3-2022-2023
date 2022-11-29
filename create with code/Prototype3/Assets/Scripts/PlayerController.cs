using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
   private Rigidbody playerRb;
   public float JumpForce = 10; 
   public float gravityModifier;
   public bool isOnGround = true;
   public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
    {
        playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        isOnGround = false;
    }
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else id(collision.GameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over")
            gameOver = true;
        }
    }
}
