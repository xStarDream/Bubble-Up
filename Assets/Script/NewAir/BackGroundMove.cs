using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] GameObject gameObj;
    [SerializeField] float fallSpeed = 0.15f; // Velocità della discesa, maggiore valore = più veloce

    void Start()
    {
        StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        while (true)
        {
            // Aggiungi una quantità alla posizione Y del gameObject
            Vector3 currentPosition = gameObj.transform.position;
            currentPosition.y -= fallSpeed * Time.deltaTime; // Fallisce in modo fluido e lento
            gameObj.transform.position = currentPosition;

            // Puoi aggiungere una condizione di stop, per esempio, fermarsi quando il gameObject arriva a una certa posizione
            if (gameObj.transform.position.y < -50f) // Ferma la discesa quando raggiunge un certo punto (ad esempio -5)
            {
                break;
            }

            yield return null;
        }
    }
}
