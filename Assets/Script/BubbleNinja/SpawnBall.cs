using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform topSx;
    [SerializeField] Transform topDx;
    [SerializeField] Transform bottomSx;
    [SerializeField] Transform bottomDx;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject bubble;

    int randomGoodBad = 0;
    float secretScore = 0f;
    float wait = 0.3f;

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
        float randomY = UnityEngine.Random.Range(topDx.position.y, topSx.position.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        if (flag == 0) // Buono
        {
            Instantiate(bubble, spawnPosition, Quaternion.identity);
        }
        else // Cattivo
        {
            Instantiate(bubble, spawnPosition, Quaternion.identity);
        }
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
