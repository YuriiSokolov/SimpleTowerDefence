using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField]
    float health = 50f;
    [SerializeField]
    int coins = 100;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health -= value;
        }
    }

    public int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins += value;
        }
    }
}
