using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour
{
    [SerializeField] AudioSource music;
    private string sceneToDestroyIn = "NewAir";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        music.Play();
    }

    private void Update()
    {
        // Controlla se la scena corrente è quella desiderata
        if (SceneManager.GetActiveScene().name == sceneToDestroyIn)
        {
            // Distruggi questo GameObject
            Destroy(gameObject);
        }
    }
}
