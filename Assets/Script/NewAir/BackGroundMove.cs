using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] GameObject[] gameObj;
    [SerializeField] float fallSpeed = 1f; // Velocità della discesa, maggiore valore = più veloce

    void Start()
    {
        StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        while (true)
        {
            foreach (GameObject go in gameObj)
            {
                // Aggiungi una quantità alla posizione Y del gameObject
                Vector3 currentPosition = go.transform.position;
                currentPosition.y -= fallSpeed * Time.deltaTime; // Fallisce in modo fluido e lento
                go.transform.position = currentPosition;

                // Puoi aggiungere una condizione di stop, per esempio, fermarsi quando il gameObject arriva a una certa posizione
                if (go.transform.position.y < -50.2f) // Ferma la discesa quando raggiunge un certo punto (ad esempio -5)
                {
                    Scene_Controller.NextLevel();
                    break;
                }
            }
            yield return null;
        }
    }
}
