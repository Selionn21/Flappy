using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner[] spawners;
    [SerializeField] private float spawnRate;
    [SerializeField] private float gameTime = 0;
    [SerializeField] private float gameDuration;
    [SerializeField] private float genTime;
    [SerializeField] private GameObject namePanel;
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private GameObject victoryText;
    private bool stopGen = false;
    private bool gameFinished = false;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(StartGen());
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > genTime) stopGen = true;
        if(stopGen) StopCoroutine(StartGen());

        if (gameTime > gameDuration && GameData.playerLevel < 3) gameFinished = true;
        if (gameFinished)
        {
            Time.timeScale = 0;
            continuePanel.SetActive(true);
        }


        if (GameData.playerLevel == 3 && gameTime > gameDuration)
        {
            gameTime = 45;
            Time.timeScale = 0;
            namePanel.SetActive(true);
            GameData.playerResult = "win";
            victoryText.SetActive(true);
        }
    }

    IEnumerator StartGen()
    {
        int randomIndex = Random.Range(0, spawners.Length);
        while (true)
        {
            spawners[randomIndex].GenerateObstacles();
            yield return new WaitForSeconds(spawnRate);
            randomIndex = Random.Range(0, spawners.Length);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(GameData.playerLevel + 1);
    }



}
