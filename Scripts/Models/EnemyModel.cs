using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField]
    float health = 20f;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float damage = 5f;
    [SerializeField]
    int minCoins = 10;
    [SerializeField]
    int maxCoins = 15;

    public float Health
    {
        get
        {
            return health;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public int Coins
    {
        get
        {
            return Random.Range(minCoins, maxCoins + 1);
        }
    }
}
