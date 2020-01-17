using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isBlocking = false;
    public bool isTowerCell = false;
    public Vector2 position;

    private void Start()
    {
        position = gameObject.transform.position;
    }
}
