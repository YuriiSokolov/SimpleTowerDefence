using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    float bulletTTL = 3f;

    void Update()
    {
        if (target != null)
        {
            LookAt();
            MoveBullet();
        }
        bulletTTL -= Time.deltaTime;

        if (bulletTTL <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target")
        {
            Destroy(gameObject);
        }
    }

    void MoveBullet()
    {
        if (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        }
    }

    void LookAt()
    {
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
