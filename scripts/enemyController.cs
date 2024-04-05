using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 1f;
    public float direction;
    public float rows;
    public float columns;
    public float gap;
    public GameObject enemyPrefab;
    public Transform initialPos;

    public List<GameObject> frontEnemies = new List<GameObject>();
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        generateEnemy();
        StartCoroutine(shootPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime*direction;


    }


    IEnumerator shootPlayer()
    {
        while (true)
        {
            frontEnemies.Clear();
            yield return new WaitForSeconds(1f);


            foreach (Transform enemy in transform)
            {
                if (enemy.GetComponent<enemy>().isFront)
                {
                    frontEnemies.Add(enemy.gameObject);
                }
            }
            int randomEnemy = Random.Range(0, frontEnemies.Count);
            //shootPoint = transform.GetChild(randomEnemy).transform.GetChild(0).transform.GetChild(0);
            Transform shootPoint = frontEnemies[randomEnemy].transform.GetChild(0);
            Instantiate(enemyBullet, shootPoint.position, enemyBullet.transform.rotation);

        }
    }
    void generateEnemy()
    {
        for (int row = 0; row < rows; row++)
        {
          
            for (int col = 0; col < columns; col++)
            {
                Vector3 spawnPosition = new Vector3(col * gap, row * gap, 0f);
                spawnPosition += initialPos.position;
                GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 180)), transform);
                spawnedEnemy.name = "R" + row + "C" + col;
                

            }
        }

    }
}
