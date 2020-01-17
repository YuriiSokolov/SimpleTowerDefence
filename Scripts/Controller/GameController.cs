using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float waitingBetweenWavesTime = 5f;
    [SerializeField]
    List<GameObject> enemyesPrefabs;
    [SerializeField]
    Transform spawnPoint;
    public PlayerModel player;
    [SerializeField]
    WaveModel[] waves;
    [SerializeField]
    GameObject enemyes;
    [SerializeField]
    GameObject[] towerPrefabs;

    public static bool sellTowerFlag = false;
    public static bool buyTowerFlag = false;
    public static int towerType = 0;

    bool enemySpawnComplete = false;
    bool waveCompleteFlag = false;
    bool gameOverFlag = false;
    bool winFlag = false;

    public static GameObject selectedTower;
    public static Cell selectedCell;

    public bool WinFlag
    {
        get
        {
            return winFlag;
        }
    }

    public bool GameOverFlag
    {
        get
        {
            return gameOverFlag;
        }
    }

    int totalWaves = 0;
    int wavesCompleteCount = 0;

    public int WavesCompleteCount
    {
        get
        {
            return wavesCompleteCount;
        }
    }

    public int TotalWaves
    {
        get
        {
            return totalWaves;
        }
    }

    float currentWaitingBetweenWavesTime = 0f;

    private void Awake()
    {
        totalWaves = waves.Length;
    }

    void Start()
    {
        currentWaitingBetweenWavesTime = waitingBetweenWavesTime;
        StartCoroutine(SpawnEnemys());
        StartCoroutine(GameOver());
    }

    private void Update()
    {
        if (gameOverFlag == false)
        {
            if (enemyes.transform.childCount == 0)
            {
                waveCompleteFlag = true;
                currentWaitingBetweenWavesTime -= Time.deltaTime;

                if (currentWaitingBetweenWavesTime <= 0f)
                {
                    waveCompleteFlag = false;
                    currentWaitingBetweenWavesTime = waitingBetweenWavesTime;
                    enemySpawnComplete = false;
                }

                if (enemySpawnComplete == false)
                {
                    StartCoroutine(SpawnEnemys());
                }
            }

            if(sellTowerFlag == true)
            {
                sellTowerFlag = false;
                SellTower();
            }

            if(buyTowerFlag == true)
            {
                buyTowerFlag = false;
                BuyTower();
            }
        }
    }

    IEnumerator GameOver()
    {
        while (true)
        {
            if (player.Health <= 0)
            {
                gameOverFlag = true;
                Debug.Log("Game over, you lose!");
                yield break;
            }
            else if (wavesCompleteCount == totalWaves && player.Health > 0 && waveCompleteFlag == true)
            {
                gameOverFlag = true;
                winFlag = true;
                Debug.Log("Game over, you win!");
                yield break;
            }
            yield return null;
        }
    }

    IEnumerable GUIController()
    {
        yield return null;
    }

    IEnumerator SpawnEnemys()
    {
        if (wavesCompleteCount < waves.Length)
        {
            string sequenceOfEnemies = waves[wavesCompleteCount].SequenceOfEnemies;
            for (int j = 0; j < sequenceOfEnemies.Length; j++)
            {
                GameObject enemy = Instantiate(enemyesPrefabs[int.Parse(sequenceOfEnemies[j].ToString())], enemyes.transform);
                enemy.transform.position = spawnPoint.position;

                if (j == sequenceOfEnemies.Length - 1)
                {
                    enemySpawnComplete = true;
                    wavesCompleteCount++;
                }

                yield return new WaitForSeconds(1);
            }
        }
    }

    void BuyTower()
    {
        if (towerPrefabs[towerType].GetComponent<TowerModel>().Cost <= player.Coins)
        {
            player.Coins = -towerPrefabs[towerType].GetComponent<TowerModel>().Cost;
            GameObject tower = Instantiate(towerPrefabs[towerType]);
            tower.transform.position = selectedCell.position;
            gameObject.GetComponent<GUIController>().ShowBuyButtons = false;
        }
    }

    void SellTower()
    {
        player.Coins = selectedTower.GetComponent<TowerModel>().SellCost;
        Destroy(selectedTower);
        gameObject.GetComponent<GUIController>().ShowSellButton = false;
    }
}
