using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] obstacle = new GameObject[1];
    public int obstacleIndex;
    public float delay;
    public static float timer = 0;
    public Text timeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        delay = Random.Range(2f, 4f);
        obstacleIndex = Random.Range(0, obstacle.Length);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / 2;
        timeDisplay.text = "Time: " + Mathf.Round(timer);

        if (delay <= 0)
        {
            SpawnEnemy();
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(obstacle[obstacleIndex], transform.position, transform.rotation);
        obstacleIndex = Random.Range(0, obstacle.Length);
        if (timer <= 30)
        {
            delay = Random.Range(2, 4);
        }
        else if (timer >= 30 && timer < 60)
        {
            delay = Random.Range(2f, 3.5f);     
        }
        else if (timer >= 60 && timer < 90)
        {
            delay = Random.Range(1.75f, 3f);     
        }
        else if (timer >= 90 && timer < 120)
        {
            delay = Random.Range(1.5f, 2f); 
        }
        else if (timer >= 120)
        {
            delay = Random.Range(1, 1.5f);
        }
    }
}
