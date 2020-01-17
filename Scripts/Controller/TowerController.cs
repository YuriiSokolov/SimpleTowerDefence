using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    float damage = 0f;
    float reloadTime = 0f;
    float currentReloadTime = 0f;

    [SerializeField]
    Transform target;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform bulletSpawnPoint;

    private void Start()
    {
        damage = gameObject.GetComponent<TowerModel>().Damage;
        reloadTime = gameObject.GetComponent<TowerModel>().ReloadTime;
    }

    private void Update()
    {
        currentReloadTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(target == null)
        {
            if(collision.tag == "Target")
            {
                target = collision.gameObject.transform;
            }
        }
        else
        {
            if (currentReloadTime <= 0)
            {
                Shooting();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null)
        {
            if (collision.tag == "Target")
            {
                target = collision.gameObject.transform;
            }
        }
        else
        {
            if (currentReloadTime <= 0)
            {
                Shooting();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform == target.transform)
        {
            target = null;
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(bulletSpawnPoint.position.x, bulletSpawnPoint.position.y);
        bullet.GetComponent<BulletModel>().damage = damage;
        bullet.GetComponent<BulletController>().target = target;
        currentReloadTime = reloadTime;
    }
}
