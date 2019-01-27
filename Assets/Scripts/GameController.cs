using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ennemy;
    public int numberOfSpawns = 2;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait = 3;
    public float timerLeft = 30f;
    public TextMeshProUGUI timerText;
    public float BaseEnnemyMove = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        timerLeft -= Time.deltaTime;
        timerText.text = Mathf.Round(timerLeft).ToString();
        if (timerLeft <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                bool isLeft = (Random.value > 0.5f);
                Vector3 spawnPosition = new Vector3((isLeft) ?  -spawnValues.x : spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                ennemy.gameObject.GetComponent<EnnemyMover>().movespeed = BaseEnnemyMove * Time.fixedDeltaTime;
                Instantiate(ennemy, spawnPosition, Quaternion.identity);
                BaseEnnemyMove += 10;
                yield return new WaitForSeconds(spawnWait);

                spawnWait -= 0.01f;

            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
