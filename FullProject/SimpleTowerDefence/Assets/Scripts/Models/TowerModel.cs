using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerModel : MonoBehaviour
{
    [SerializeField]
    int cost = 25;
    [SerializeField]
    float damage = 5f;
    [SerializeField]
    float reloadTime = 0.25f;

    public int Cost
    {
        get
        {
            return cost;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
    }

    public int SellCost
    {
        get
        {
            return (int)Mathf.Ceil(cost / 2);
        }
    }
}
