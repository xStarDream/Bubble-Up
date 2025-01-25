using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Scene_Controller
{
    public static void LoadScene(int sceneIndex)
    {
        Debug.Log("Caricamento della scena con indice: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex); // Usa SceneManager per caricare la scena
    }
    public static void RestartGame()
    {
        LoadScene(0);
    }

    public static void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextLevel()
    {
        if(SceneManager.sceneCountInBuildSettings>SceneManager.GetActiveScene().buildIndex+1)
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
