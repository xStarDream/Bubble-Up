using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicGame2 : MonoBehaviour
{
    [SerializeField] AudioSource music;
 
    private void Start()
    {
        music.Play();
    }
}
