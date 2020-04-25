using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    public Text waveCountdownText;

    private float countDown = 2f;
    private int waveIndex = 0;

    
    private void Update()
    {
        if (countDown <= 0f )
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveIndex; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);//reloops this function and wait
        }
        waveIndex++;
        
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
