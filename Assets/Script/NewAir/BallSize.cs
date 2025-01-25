using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    [SerializeField] Transform trPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        string objectName = other.gameObject.name;
        if (objectName == "Good(Clone)")
        {
            trPlayer.transform.localScale *= 1.2f;
        }
        else
        {
            trPlayer.transform.localScale *= 0.8f;
        }
        
        other.gameObject.SetActive(false);
    }
}
