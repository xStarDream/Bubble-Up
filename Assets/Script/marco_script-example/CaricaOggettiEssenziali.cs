using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaricaOggettiEssenziali : MonoBehaviour
{
    [SerializeField] GameObject oggettiEssenzialiPrefab;

    private void Awake()
    {
        var oggettiEsistenti = FindObjectsOfType<OggettiEssenziali>();
        if (oggettiEsistenti.Length == 0)
        {
            Instantiate(oggettiEssenzialiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
