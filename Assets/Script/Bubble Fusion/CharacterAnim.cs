using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnim : MonoBehaviour
{
    [SerializeField] Sprite[] initialAnim;
    [SerializeField] float frameRate = 0.1f;

    SpriteRenderer spriteRenderer;
    int currentFrame = 0;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (initialAnim.Length > 0)
        {
            spriteRenderer.sprite = initialAnim[currentFrame];
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % initialAnim.Length;
            spriteRenderer.sprite = initialAnim[currentFrame];
        }
    }
}
