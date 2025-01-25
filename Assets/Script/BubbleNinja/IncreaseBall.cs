using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBall : MonoBehaviour
{
    [SerializeField] private GameObject prefab;  // Prefab da incrementare
    [SerializeField] private float incrementSpeed = 0.01f;  // Velocità di incremento della scala
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);  // Scala finale


    private void Start()
    {
        // Avvia la coroutine che incrementa la scala del prefab
        StartCoroutine(IncrementScaleOverTime(prefab));
    }

    IEnumerator IncrementScaleOverTime(GameObject obj)
    {
        // Scala attuale del prefab
        Vector3 initialScale = obj.transform.localScale;

        // Finché la scala del prefab non raggiunge il valore target
        while (obj.transform.localScale.x < targetScale.x && obj.transform.localScale.y < targetScale.y && obj.transform.localScale.z < targetScale.z)
        {
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
