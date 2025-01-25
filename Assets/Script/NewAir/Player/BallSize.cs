using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    [SerializeField] Transform trPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Usa CompareTag per controllare il tag invece del nome
        if (other.CompareTag("Good") && !(trPlayer.transform.localScale.x > 2.2f))
        {
            trPlayer.transform.localScale *= 1.2f;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Bad"))
        {
            trPlayer.transform.localScale *= 0.8f;
            other.gameObject.SetActive(false);
        }

        if (trPlayer.transform.localScale.x <= 0.5f)
        {
            Debug.Log("PARTITA ANIMAZIONE SCOPPIO");
        }
    }
}