using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform topSx;
    [SerializeField] Transform topDx;
    [SerializeField] GameObject good;
    [SerializeField] GameObject bad;
    [SerializeField] Transform trPlayer;
    [SerializeField] GameObject player;

    float offset = 50f;
    float wait = 0.7f;
    float spawnY = 10f;
    int randomGoodBad = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PassaggioTempo());
        StartCoroutine(Generazione());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trPlayer.position = player.transform.position; // aggiorno la posizione attuale del giocatore
        //Debug.Log("trplayer aggiornato " + trPlayer.position);
    }

    void SpawnPrefab(int flag)
    {
        // Genera una posizione casuale sull'asse X tra i limiti
        float randomX = UnityEngine.Random.Range(topSx.position.x, topDx.position.x);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        if (flag == 0) //buono
        {
            // Istanzia il prefab nella posizione casuale
            Instantiate(good, spawnPosition, Quaternion.identity);
            //Debug.Log("Oggetto spawnato in posizione: " + spawnPosition);
        }
        else //cattivo
        {
            Instantiate(bad, spawnPosition, Quaternion.identity);
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

    /*IEnumerator PassaggioTempo()
    {
        while (true)
        {
            wait -= 0.05f;

            if (wait <= 0)
            {
                wait = 0.05f;
            }

            yield return new WaitForSeconds(3.5f);
        }
    }*/
}
