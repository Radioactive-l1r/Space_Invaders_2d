using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 2f;
    public GameObject playerBulletPrefab;

    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float movement = Horizontal * speed * Time.deltaTime;

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + new Vector3(movement, 0f, 0f);
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBulletPrefab, shootPoint.position, shootPoint.rotation);
        }

    }
}
