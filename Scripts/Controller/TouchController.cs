using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    RaycastHit2D[] hit;

    private void Update()
    {
        Touch();
    }

    void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    hit = Physics2D.RaycastAll(touchPos, Vector3.back);

                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.tag == "Tower")
                        {
                            GUIController.showBuyButtons = false;

                            if (GameController.selectedTower == hit[i].collider.transform.parent.gameObject)
                            {
                                GUIController.showSellButton = !GUIController.showSellButton;
                            }
                            else
                            {
                                GameController.selectedTower = hit[i].collider.transform.parent.gameObject;
                                GUIController.showSellButton = true;
                                Debug.Log("Tower selected: " + GameController.selectedTower.name);
                            }
                            break;
                        }
                        else if (hit[i].collider.tag == "TowerCell")
                        {
                            if (hit[i].collider.gameObject.GetComponent<Cell>().isTowerCell == true)
                            {
                                if (hit[i].collider.gameObject.GetComponent<Cell>().isBlocking == false)
                                {
                                    GUIController.showSellButton = false;

                                    if (GameController.selectedCell == hit[i].collider.gameObject.GetComponent<Cell>())
                                    {
                                        GUIController.showBuyButtons = !GUIController.showBuyButtons;
                                    }
                                    else
                                    {
                                        GameController.selectedCell = hit[i].collider.gameObject.GetComponent<Cell>();
                                        GUIController.showBuyButtons = true;
                                        Debug.Log("Cell selected: " + GameController.selectedCell.name);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
