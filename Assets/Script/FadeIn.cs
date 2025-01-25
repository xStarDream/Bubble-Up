using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] float fadeDuration = 2f;

    private void Start()
    {
        // Assicuriamoci che tutti i figli del canvas partano con alpha 0
        SetAlphaForAll(0);

        // Avvia il fade-in
        //StartCoroutine(FadeInElements());
    }

    // Metodo per avviare il fade-in
    public void StartFadeIn()
    {
        StartCoroutine(FadeInElements());
    }

    // Coroutine per far comparire gradualmente tutti gli elementi figli
    private IEnumerator FadeInElements()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            // Aggiorna l'alpha di tutti gli elementi
            SetAlphaForAll(alpha);

            yield return null;
        }

        // Assicuriamoci che alla fine l'alpha sia esattamente 1
        SetAlphaForAll(1);
    }

    // Metodo per impostare l'alpha su tutti gli elementi figli del canvas
    private void SetAlphaForAll(float alpha)
    {
        foreach (Graphic graphic in canvas.GetComponentsInChildren<Graphic>())
        {
            Color color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }
    }
}
