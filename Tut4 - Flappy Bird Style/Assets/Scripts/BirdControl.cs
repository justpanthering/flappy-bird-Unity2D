using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public float jumpForce = 200f;

    private bool isDead;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isDead = false;

        //Initial force on bird
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce));
        animator.SetTrigger("Flap");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));
                animator.SetTrigger("Flap");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        FindObjectOfType<GameManager>().gameOver();
    }
}
