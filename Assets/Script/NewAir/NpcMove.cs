using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    [SerializeField] GameObject npc;
    [SerializeField] float fallSpeed = 2f; // Velocità di discesa

    void Update()
    {
        // Calcola la nuova posizione abbassando l'asse Y
        transform.position -= new Vector3(0f, fallSpeed * Time.deltaTime, 0f);

        if (transform.position.y < -50f) // Soglia per distruggere
        {
            npc.SetActive(false);
        }
    }
}
