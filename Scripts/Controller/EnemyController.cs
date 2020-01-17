using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Vector2> path;
    int pathIndex = 0;

    public float speed = 0f;
    public float currentHealth = 0f;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    private void Start()
    {
        speed = gameObject.GetComponent<EnemyModel>().Speed;
        currentHealth = gameObject.GetComponent<EnemyModel>().Health;
        StartCoroutine(HealthCounter());
        path = CreatePath();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (path.Count > 0)
        {
            if (Vector2.Distance((Vector2)transform.position, path[pathIndex]) <= 0)
            {
                if (pathIndex < path.Count - 1)
                {
                    pathIndex++;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerModel>().Health = gameObject.GetComponent<EnemyModel>().Damage;
                    DestroyEnemy();
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, path[pathIndex], speed * Time.deltaTime);
        }
    }

    void DestroyEnemy()
    {
        Debug.Log("Enemy Deleted");
        Destroy(gameObject);
    }

    IEnumerator HealthCounter()
    {
        while (true)
        {
            if (currentHealth <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerModel>().Coins = gameObject.GetComponent<EnemyModel>().Coins;
                DestroyEnemy();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    List<Vector2> CreatePath()
    {
        List<Vector2> path = new List<Vector2>();
        GameObject wayPointsGO = GameObject.FindWithTag("WayPoints");

        for(int i = 0; i < wayPointsGO.transform.childCount; i++)
        {
            path.Add(wayPointsGO.transform.GetChild(i).position);
        }

        return path;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            currentHealth -= collision.gameObject.GetComponent<BulletModel>().damage;
            Debug.Log("Пуля попала");
        }
    }
}
