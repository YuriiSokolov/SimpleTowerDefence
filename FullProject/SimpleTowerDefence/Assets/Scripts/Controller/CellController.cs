using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D[] hit;

        hit = Physics2D.RaycastAll(transform.position, -Vector3.back);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.tag == "Tower")
            {
                gameObject.GetComponent<Cell>().isBlocking = true;
                break;
            }
            gameObject.GetComponent<Cell>().isBlocking = false;
        }
    }
}
