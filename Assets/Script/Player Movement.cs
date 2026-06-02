using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    public Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void PlayerWalk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f)); 
        ScaleFlip(horizontalInput); 

        if (horizontalInput == 0)
           {
            ani.SetBool("isRun", false); // Idle
           }
        else   
           {
            ani.SetBool("isRun", true); // Run
           }
    }
   
   private void PlayerJump()
   {
       if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
   }

    private void ScaleFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            Debug.Log("flip!");
        }  
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            Debug.Log("noFlip");
        }
    }
    void Update()
    {
        PlayerWalk();
        PlayerJump();
    }
}