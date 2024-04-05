using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    public float spee = 2f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * spee;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime * direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="border")
        {
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
