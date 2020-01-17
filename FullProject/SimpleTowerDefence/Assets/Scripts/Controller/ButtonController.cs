using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonSellTower()
    {
        GameController.sellTowerFlag = true;
    }

    public void BuyTower0Button()
    {
        GameController.buyTowerFlag = true;
        GameController.towerType = 0;
    }

    public void BuyTower1Button()
    {
        GameController.buyTowerFlag = true;
        GameController.towerType = 1;
    }
}
