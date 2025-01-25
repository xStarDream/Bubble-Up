using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canva;

    public void RestartLevelGameManager()
    {
        Scene_Controller.RestartLevel();
        canva.SetActive(true);

    }
}
