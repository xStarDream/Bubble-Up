using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour
{
    [SerializeField] AudioSource music;
    private string sceneToDestroyIn = "NewAir";
    private string sceneToDestroyInRestart = "MainMenu";
    // Variabile statica per tenere traccia dell'unica istanza
    public static StartMusic instance;

    private void Awake()
    {
        // Se esiste già un'istanza della musica, distruggi questa
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Distruggi l'istanza duplicata
        }
        else
        {
            instance = this;  // Imposta questa come l'unica istanza
            DontDestroyOnLoad(gameObject); // Non distruggere questo GameObject tra le scene
        }
    }
    private void Start()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
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
