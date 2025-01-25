using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Vector3 topSx;
    [SerializeField]
    Vector3 topDx;
    [SerializeField]
    GameObject good;
    [SerializeField]
    GameObject bad;
    
    [SerializeField] Vector3 trPlayer;
    [SerializeField] GameObject player;

    float offset;
    float wait = 0.5f;
    float spawnY = 1f;

    int flagGoodBad = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        trPlayer = player.transform.position; //aggiorno costantemente la posizione attuale del giocatore
    }

    IEnumerator Generazione()
    {
        flagGoodBad = UnityEngine.Random.Range(0,1);
        SpawnPrefab(flagGoodBad);
        yield return new WaitForSeconds(wait);
    }

    void SpawnPrefab(int flag)
    {
        // Genera una posizione casuale sull'asse X tra i limiti
        float randomX = UnityEngine.Random.Range(topSx.x, topDx.x);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Istanzia il prefab nella posizione casuale
        Instantiate(good, spawnPosition, Quaternion.identity);

        // Debug per controllare la posizione
        Debug.Log("Oggetto spawnato in posizione: " + spawnPosition);

        Instantiate(good, spawnPosition, Quaternion.identity);
    }
}
