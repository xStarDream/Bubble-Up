using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettiEssenziali : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}


