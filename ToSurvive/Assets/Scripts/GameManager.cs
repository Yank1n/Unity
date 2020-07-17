using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnTopX = 5.5f;
    private float spawnBottomX = -5.2f;
    private float spawnTopZ = 5f;
    private float spawnBottomZ = -47f;
    private int enemiesToSpawn = 4;
    private int enemyCount;
    private int countOfWaves;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winnigText;
    public Button restartButton;
    private bool gameOver;
    private int playerHP;
    static public bool win;
    
    void Start()
    {
        SpawnEnemyWave(enemiesToSpawn);
        countOfWaves = 1;
        win = false;
    }
    void Update()
    {
        playerHP = EnemyScript.playerHP;
        gameOver = EnemyScript.gameOver;
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        enemiesText.text = "Enemies: " + enemyCount;
        waveText.text = "Wave: " + countOfWaves;
        hpText.text = (playerHP > 0) ? "Health points: " + playerHP : "Health points: 0";
        if (gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            enemiesText.gameObject.SetActive(false);
            waveText.gameObject.SetActive(false);
        }
        if (countOfWaves == 3 && enemyCount == 0)
        {
            win = true;
            winnigText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            enemiesText.gameObject.SetActive(false);
            waveText.gameObject.SetActive(false);
        }
        if (enemyCount == 0 && countOfWaves != 3)
        {
            countOfWaves++;
            enemiesToSpawn += 2;
            SpawnEnemyWave(enemiesToSpawn);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnBottomX, spawnTopX);
        float spawnPosZ = Random.Range(spawnBottomZ, spawnTopZ);

        return new Vector3(spawnPosX, -5.588f, spawnPosZ);
    }
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
