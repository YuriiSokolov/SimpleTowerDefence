using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI healthCount;

    private void Start()
    {
        healthCount.text = gameObject.GetComponent<EnemyModel>().Health + " HP";
    }

    void Update()
    {
        healthCount.text = gameObject.GetComponent<EnemyController>().CurrentHealth.ToString() + " HP";
    }
}
