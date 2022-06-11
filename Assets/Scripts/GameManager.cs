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
    private int goodPoint = 0;
    private int badPoint = 0;
    private int cantFinishSpawn = 0;

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
        Debug.Log("terminaron de hacer spawn");
    }

    public void AddGoodPoint()
    {
        goodPoint += 1;
        correctPointText.SetText($"Good: {goodPoint.ToString()}");
    }

    public void AddBadPoint()
    {
        badPoint += 1;
        incorrectPointText.SetText( $"Bad: {badPoint.ToString()}");
        if (badPoint > 2)
        {
            GameOver();
        }
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
