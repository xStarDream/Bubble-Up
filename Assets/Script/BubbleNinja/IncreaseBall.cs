using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBall : MonoBehaviour
{
    [SerializeField] private GameObject prefab;  // Prefab da incrementare
    [SerializeField] private float incrementSpeed = 0.1f;  // Velocità di incremento della scala
    private Vector3 targetScale = new Vector3(1f, 1f, 1f);  // Scala finale

    private void Start()
    {
        // Avvia la coroutine che incrementa la scala del prefab
        StartCoroutine(IncrementScaleOverTime(prefab));
    }

    IEnumerator IncrementScaleOverTime(GameObject obj)
    {
        // Scala attuale del prefab
        Vector3 initialScale = obj.transform.localScale;
        float elapsedTime = 0f;
        float incrementDuration = 1.8f;

        // Finché la scala del prefab non raggiunge il valore target
        while (obj.transform.localScale.x < targetScale.x && obj.transform.localScale.y < targetScale.y && obj.transform.localScale.z < targetScale.z)
        {
            // Incrementa il tempo
            elapsedTime += Time.deltaTime;  // Incrementa normalmente il tempo

            if(elapsedTime > incrementDuration) { break; }

            // Incrementa la scala lentamente
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, targetScale, incrementSpeed * Time.deltaTime);
            yield return null;  // Aspetta fino al prossimo frame
        }

        // Una volta raggiunta la scala finale, puoi eseguire altre azioni (se necessario)
        Debug.Log("Scala finale raggiunta!");
    }

    void bubbleDestroy()
    {
        Destroy(gameObject);
    }
}
