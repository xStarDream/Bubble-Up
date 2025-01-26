using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum GameState
{
    Run,
    Win
}

public class HitBarHandler : MonoBehaviour
{
    [SerializeField] Bar Bar;
    [SerializeField] BubbleCharacter bubblePlayer;
    [SerializeField] BubbleCharacter bubbleNPC;
    [SerializeField] BubbleCharacter newBubble;

    [SerializeField] AudioSource buttonCenterPress;
    [SerializeField] AudioSource buttonWrongPress;

    [SerializeField] Canvas Canvas;
    [SerializeField] Image cover;
    [SerializeField] float fadeDuration = 2.0f;

    [SerializeField] float SpeedBubble = 0.20f;
    [SerializeField] float collisionThreshold = 0.5f;

    GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Run)
        {
            //MoveBar();
            if (Bar.isAtCenter && Input.GetMouseButtonDown(0))
            {
                MoveBubble(bubblePlayer, SpeedBubble);
                MoveBubble(bubbleNPC, -SpeedBubble);
                AddSpeed();
                Bar.transform.localPosition = Vector3.zero;
                buttonCenterPress.Play();
            }
            if (!Bar.isAtCenter && Input.GetMouseButtonDown(0))
            {
                MoveBubble(bubblePlayer, -SpeedBubble);
                MoveBubble(bubbleNPC, +SpeedBubble);
                Bar.Speed -= 0.25f;
                if (Bar.Speed < 0.25f)
                {
                    Bar.Speed = 0.25f;
                }

                Bar.transform.localPosition = Vector3.zero;
                // buttonWrongPress.Play();
            }
            CheckCollision();
        }
        else if (gameState == GameState.Win)
        {
            bubblePlayer.gameObject.SetActive(false);
            bubbleNPC.gameObject.SetActive(false);
            newBubble.gameObject.SetActive(true);

            Canvas.gameObject.SetActive(true);
            StartCoroutine(FadeIn());
        }

    }

    private void AddSpeed()
    {
        if (Bar.Speed < 1 )
        {
            Bar.Speed += 0.25f;
        } else {
            Bar.Speed = 1;
        }
    }

    void MoveBubble(BubbleCharacter bubbleCharacter, float speed)
    {
        Vector3 newPosition = bubbleCharacter.transform.position;
        newPosition.x += speed;
        bubbleCharacter.transform.position = newPosition;
    }

    void CheckCollision()
    {
        float distance = Vector3.Distance(bubblePlayer.transform.position, bubbleNPC.transform.position);
        if (distance < collisionThreshold)
        {
            // Debug.Log("Collision Detected");
            gameState = GameState.Win;

        }
    }

    void MoveBar()
    {
        if (Bar.State == BarState.ToLeft)
        {
            Bar.MoveTo(Vector3.left, Bar.Limit_Left.transform.position.x, BarState.ToRight);
        }
        else if (Bar.State == BarState.ToRight)
        {
            Bar.MoveTo(Vector3.right, Bar.Limit_Right.transform.position.x, BarState.ToLeft);
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            Color color = cover.color;
            color.a = alpha;

            cover.color = color;

            yield return null;
        }
        Scene_Controller.NextLevel();
    }

}
