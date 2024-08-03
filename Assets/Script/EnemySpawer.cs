using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawer : MonoBehaviour
{
    [Header("Delay")]
    public float minDelaySpawn;
    public float maxDelaySpawn;

    [Header("Position Player Two")]
    public float minPosXForPlayerTwo;
    public float maxPosXForPlayerTwo;
    public Transform playerTwoTransform;


    [Header("Position Player One")]
    public float minPosXForPlayerOne;
    public float maxPosXForPlayerOne;
    public Transform playerOneTransform;

    public float proximityThreshold = 1.0f; 
    public float posY;

    public GameObject[] enemyPrefabs;



    void Start()
    {
        StartCoroutine(SpawnEnemyForPlayerOne());
        StartCoroutine(SpawnEnemyForPlayerTwo());
    }

    IEnumerator SpawnEnemyForPlayerOne()
    {
        while (true)
        {
            float delay = Random.Range(minDelaySpawn, maxDelaySpawn);
            yield return new WaitForSeconds(delay);
            float posX = Random.Range(minPosXForPlayerTwo, maxPosXForPlayerTwo);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], new Vector3(posX, posY, 0), Quaternion.identity);
            Debug.Log("enemy spawn chez jouer 1");
            Transform child = enemy.transform.GetChild(0);
            EnemieFlip enemieFlip = child.GetComponent<EnemieFlip>();
            enemieFlip.playerToAttack = "Player1";
            // Vérifiez la proximité avec le joueur 1
            if (Mathf.Abs(enemy.transform.position.x - playerOneTransform.position.x) < proximityThreshold)
            {
                Debug.Log("enemy detruit");
                Destroy(enemy);
            }
        }
    }

    IEnumerator SpawnEnemyForPlayerTwo()
    {
        while (true)
        {
            float delay = Random.Range(minDelaySpawn, maxDelaySpawn);
            yield return new WaitForSeconds(delay);
            float posX = Random.Range(minPosXForPlayerOne, maxPosXForPlayerOne);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], new Vector3(posX, posY, 0), Quaternion.identity);
            Transform child = enemy.transform.GetChild(0);
            EnemieFlip enemieFlip = child.GetComponent<EnemieFlip>();
            enemieFlip.playerToAttack = "Player2";

            // Vérifiez la proximité avec le joueur 2
            if (Mathf.Abs(enemy.transform.position.x - playerTwoTransform.position.x) < proximityThreshold)
            {
                Debug.Log("enemy detruit");
                Destroy(enemy);
            }

            Destroy(enemy, 15);

        }
    }
  
}
