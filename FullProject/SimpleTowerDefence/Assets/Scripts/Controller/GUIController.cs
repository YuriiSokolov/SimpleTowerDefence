using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    GameController gameController;

    public GameObject gameOverGUIgo;
    public TextMeshProUGUI gameOverText;


    public TextMeshProUGUI healthCountText;

    public TextMeshProUGUI coinsCountText;

    public TextMeshProUGUI totalWaveText;
    public TextMeshProUGUI completeWaveText;

    public GameObject sellBuyButtonsGUIgo;
    public GameObject sellButton;
    public GameObject buyButtons;

    public static bool showSellButton = false;

    public bool ShowSellButton
    {
        set
        {
            showSellButton = value;
        }
    }

    public static bool showBuyButtons = false;

    public bool ShowBuyButtons
    {
        set
        {
            showBuyButtons = value;
        }
    }

    private void Start()
    {
        gameController = gameObject.GetComponent<GameController>();
        totalWaveText.text = gameController.TotalWaves.ToString();
        StartCoroutine(HealthCountTextController());
        StartCoroutine(CoinsCountTextController());
        StartCoroutine(CompleteWaveTextController());
        StartCoroutine(GameOverGUIController());
        StartCoroutine(SellButtonGUIController());
        StartCoroutine(BuyButtonsGUIController());
    }

    private void Update()
    {
        
    }

    IEnumerator HealthCountTextController()
    {
        while (true)
        {
            healthCountText.text = gameController.player.Health.ToString();
            yield return null;
        }
    }

    IEnumerator CoinsCountTextController()
    {
        while (true)
        {
            coinsCountText.text = gameController.player.Coins.ToString();
            yield return null;
        }
    }

    IEnumerator CompleteWaveTextController()
    {
        while (true)
        {
            completeWaveText.text = gameController.WavesCompleteCount.ToString();
            yield return null;
        }
    }

    IEnumerator GameOverGUIController()
    {
        while (true)
        {
            if(gameController.GameOverFlag == true)
            {
                gameOverGUIgo.SetActive(true);
                if(gameController.WinFlag == true)
                {
                    gameOverText.text += "\nYou Win!";
                }
                else
                {
                    gameOverText.text += "\nYou Lose!";
                }
                StopAllCoroutines();
            }
            yield return null;
        }
    }

    IEnumerator SellButtonGUIController()
    {
        while (true)
        {
            sellButton.SetActive(showSellButton);
            if (showSellButton == true)
            {
                sellBuyButtonsGUIgo.transform.position = GameController.selectedTower.transform.position;
            }
            yield return null;
        }
    }

    IEnumerator BuyButtonsGUIController()
    {
        while (true)
        {
            buyButtons.SetActive(showBuyButtons);
            if (showBuyButtons == true)
            {
                sellBuyButtonsGUIgo.transform.position = GameController.selectedCell.position;
            }
            yield return null;
        }
    }
}
