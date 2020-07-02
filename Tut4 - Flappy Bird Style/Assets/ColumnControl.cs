using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(PersistentManager.instance.scrollHorizonatalSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentManager.instance.isGameOver)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bird"))
        {
            Debug.Log("Score");
            PersistentManager.instance.ScoreUpdate();
        }
    }
}
