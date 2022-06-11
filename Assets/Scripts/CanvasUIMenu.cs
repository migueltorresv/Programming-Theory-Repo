using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CanvasUIMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNamePlayer;

    public void StartGame()
    {
        if (string.IsNullOrEmpty(inputNamePlayer.text))
        {
            inputNamePlayer.placeholder.GetComponent<TextMeshProUGUI>().text = "Please enter your name...";
        }
        else
        {
            MainManager.Instance.namePlayer = inputNamePlayer.text;
            SceneManager.LoadScene("Main");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }

}
