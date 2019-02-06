using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float radius = 5f;
    public float baseEnnemyMove = 1f;
    public GameObject ennemy;
    public TextMeshProUGUI scoreText;
    public float ennemyMoveAcceleration = 0.1f;
    private float score = 0;
    private double nextSpawnTime = 0;

    private void Update()
    {
        score += Time.deltaTime;
        scoreText.text = Mathf.Round(score).ToString();

        if (nextSpawnTime <= 0)
        {
            Vector3 spawnPosition = GenerateRandomPosition();
            ennemy.GetComponent<EnnemyMover>().movespeed = baseEnnemyMove;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, spawnPosition) * Quaternion.Euler(0, 0, spawnPosition.x < 0 ? -90 : -90); ;
            Instantiate(ennemy, spawnPosition, rotation);
            nextSpawnTime = Random.value * 2 + 1;
        }

        baseEnnemyMove += Time.deltaTime * ennemyMoveAcceleration;
        nextSpawnTime -= Time.deltaTime;
    }

    private Vector3 GenerateRandomPosition()
    {
        float angle = Random.value * Mathf.PI * 2;
        return new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
    }
}
