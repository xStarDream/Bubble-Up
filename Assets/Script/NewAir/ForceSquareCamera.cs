using UnityEngine;

public class ForceSquareCamera : MonoBehaviour
{
    void Start()
    {
        // Aspect ratio desiderato (9:9 è 1:1)
        float targetAspect = 1f;

        // Ottieni il rapporto dello schermo corrente
        float windowAspect = (float)Screen.width / Screen.height;

        // Calcola il fattore di scala
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1f)
        {
            // Aggiungi barre nere sopra e sotto (letterbox)
            Rect rect = camera.rect;

            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0f;
            rect.y = (1f - scaleHeight) / 2f;

            camera.rect = rect;
        }
        else
        {
            // Aggiungi barre nere ai lati (pillarbox)
            float scaleWidth = 1f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0f;

            camera.rect = rect;
        }
    }
}
