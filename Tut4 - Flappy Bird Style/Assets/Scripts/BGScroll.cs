using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    //private float scrollHorizonatalSpeed = -3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(PersistentManager.instance.scrollHorizonatalSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PersistentManager.instance.isGameOver)
            rb.velocity = Vector2.zero;
        else if(gameObject.transform.position.x < -gameObject.GetComponent<BoxCollider2D>().size.x)
        {
            reposition();
        }
    }

    private void reposition()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 2 * gameObject.GetComponent<BoxCollider2D>().size.x, gameObject.transform.position.y);
    }
}
