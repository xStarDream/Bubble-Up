using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform topSx;
    [SerializeField] Transform topDx;
    [SerializeField] Transform bottomSx;
    [SerializeField] Transform bottomDx;
    TextMeshPro txtGood;
    TextMeshPro txtBad;
    [SerializeField] GameObject[] bubbleGoods;
    [SerializeField] GameObject[] bubbleBads; // Array con diversi prefab Bad

    int randomGoodBad = 0;
    float secretScore = 0f;
    float wait = 2.5f;

    [SerializeField] string[] poolGood;
    [SerializeField] string[] poolBad;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PassaggioTempo());
        StartCoroutine(Generazione());
    }

    void SpawnPrefab(int flag)
    {
        // Genera una posizione casuale sull'asse X tra i limiti (topSx.x e topDx.x)
        float randomX = UnityEngine.Random.Range(topSx.position.x, topDx.position.x);

        // Genera una posizione casuale sull'asse Y tra i limiti (topDx.y e topSx.y)
        // topDx.y è il limite inferiore e topSx.y è il limite superiore
        float randomY = UnityEngine.Random.Range(topDx.position.y, bottomSx.position.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        if (flag == 0) // Buono
        {
            //GameObject spawnedGood = Instantiate(bubbleGood, spawnPosition, Quaternion.identity);
            // Cerca il componente TextMeshPro all'interno del prefab istanziato
            int randomIndex = UnityEngine.Random.Range(0, bubbleGoods.Length);
            GameObject randomBubbleGood = bubbleGoods[randomIndex];

            GameObject spawnedBad = Instantiate(randomBubbleGood, spawnPosition, Quaternion.identity);

        }
        else // Cattivo
        {
            // Istanzia il prefab Bad
            //GameObject spawnedBad = Instantiate(bubbleBad, spawnPosition, Quaternion.identity);
            // Scegli casualmente un prefab da bubbleBadOptions
            int randomIndex = UnityEngine.Random.Range(0, bubbleBads.Length);
            GameObject randomBubbleBad = bubbleBads[randomIndex];

            GameObject spawnedBad = Instantiate(randomBubbleBad, spawnPosition, Quaternion.identity);


        }
    }


    // Metodo per ottenere una stringa casuale dal poolBad
    private string GetRandomStringBad()
    {
        if (poolBad != null && poolBad.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, poolBad.Length); // Ottieni un indice casuale
            return poolBad[randomIndex];
        }

        Debug.LogWarning("poolBad è vuoto o non assegnato!");
        return string.Empty; // Ritorna una stringa vuota se l'array è vuoto
    }

    // Metodo per ottenere una stringa casuale dal poolBad
    private string GetRandomStringGood()
    {
        if (poolGood != null && poolGood.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, poolGood.Length); // Ottieni un indice casuale
            return poolGood[randomIndex];
        }

        Debug.LogWarning("poolGood è vuoto o non assegnato!");
        return string.Empty; // Ritorna una stringa vuota se l'array è vuoto
    }

    IEnumerator Generazione()
    {
        while (true)
        {
            randomGoodBad = UnityEngine.Random.Range(0, 2); // Restituisce 0 o 1
            SpawnPrefab(randomGoodBad);
            yield return new WaitForSeconds(wait);
        }
    }
}
