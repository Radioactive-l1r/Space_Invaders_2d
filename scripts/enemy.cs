using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public enemyController EnemyController;
    public bool isFront=false;

    public Transform shootPoint;
    private void Start()
    {
        EnemyController = GameObject.Find("allEnemies").GetComponent<enemyController>();
        shootPoint = transform.GetChild(0);
    }
    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, -Vector2.up,100f);
        Debug.DrawRay(shootPoint.position, -Vector2.up*100f);

        if (hit.collider.tag=="enemy")
        {
            isFront = false;
            Debug.Log("hitting enemy");
        }
        else
        {
            isFront = true;
            Debug.Log("not hitting enemy");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision test : " + collision.gameObject.name);
        if(collision.gameObject.tag=="leftBorder")
        {
            EnemyController.direction = 1;
        }
        else if (collision.gameObject.tag == "rightBorder")
        {
            EnemyController.direction = -1;
        }


    }
   
}
