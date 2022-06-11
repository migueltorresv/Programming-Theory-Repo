using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI correctPointText;
    [SerializeField] private TextMeshProUGUI incorrectPointText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelWellPlader;
    private int goodPoint = 0;
    private int badPoint = 0;
    private int cantFinishSpawn = 0;
    private int cantObjectsSpawned;
    public int GoodPoint
    {
        get { return goodPoint; }
        set
        {
            goodPoint = value;
            correctPointText.SetText($"Good: {goodPoint.ToString()}");
            StartCoroutine(WaitForFinishGame());
        }
    }

    public int BadPoint
    {
        get { return badPoint; }
        set
        {
            badPoint = value;
            incorrectPointText.SetText( $"Bad: {badPoint.ToString()}");
            if (badPoint > 2)
            {
                GameOver();
            }
        }
    }

    public int CantFinishSpawn
    {
        get { return cantFinishSpawn; }
        set
        {
            cantFinishSpawn = value;
            if (cantFinishSpawn >= 3)
            {
                CountObjects();
            }
        }
    }

    private void Start()
    {
        nameText.SetText($"Recycler {MainManager.Instance.namePlayer}");
        panelGameOver.SetActive(false);
        panelWellPlader.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    private void CountObjects()
    {
        StartCoroutine(WaitForCountObjects());
    }

    private IEnumerator WaitForCountObjects()
    {
        yield return new WaitForSeconds(1);
        cantObjectsSpawned = GameObject.FindGameObjectsWithTag("Trash").Length;
        Debug.Log($"{cantObjectsSpawned} instanciados");
    }

    private IEnumerator WaitForFinishGame()
    {
        yield return new WaitForSeconds(4);
        if ((goodPoint + badPoint) == cantObjectsSpawned)
        {
            //verficar despues de un tiempo, para finalizar el juego
            WellPlayed();
        }
    }

    private void WellPlayed()
    {
        panelWellPlader.SetActive(true);
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
