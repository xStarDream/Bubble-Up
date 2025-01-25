using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Image img;
    [SerializeField] float fadeDuration;

    private void Start()
    {
        // Assicurati che l'alpha parta da 0 (completamente trasparente)
        if (img != null)
        {
            Color color = img.color;
            color.a = 0;
            img.color = color;
        }
    }

    // Metodo per avviare il fade-in
    public static void StartFadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        float timeElapsed = 0f;

        // Fai un fade-in da alpha = 0 a alpha = 1
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            Color color = image.color;
            color.a = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            image.color = color;
            yield return null;
        }

        // Assicurati che l'alpha sia esattamente 1 alla fine
        Color finalColor = image.color;
        finalColor.a = 1;
        image.color = finalColor;
    }
}
