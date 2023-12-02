using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 )
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<Enemy>().DamageBoost = player.GetComponent<XPScript>().GetDamageBoost();
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    //public void gotHit(Collision2D collision, GameObject enemy)
    //{
    //    //Shotgun egy példa. Ide kell kerülnie minden olyan dolognak, ami megsebezheti a karaktert.
    //    if (enemy.GetComponent<Enemy>().currentHealth > 0)
    //    {
    //        if (collision.gameObject.tag == enemy.GetComponent<Enemy>().Tag)
    //        {
    //            enemy.GetComponent<Enemy>().currentHealth -= 2;
    //            Debug.Log(enemy.GetComponent<Enemy>().Tag + " attacked");
    //        }
    //    }
    //    else Destroy(enemy);
    //}

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value>0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }
}
