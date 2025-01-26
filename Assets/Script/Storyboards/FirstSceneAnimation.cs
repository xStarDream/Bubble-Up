using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using PrimeTween;

public class StoryboardManager : MonoBehaviour
{
    [SerializeField] GameObject ImageA, ImageB, ImageC,Background;
    [SerializeField] Canvas canvas;
    [SerializeField]GameObject player,bolla;
    [SerializeField]
    GameObject particles;
    [SerializeField] Sprite seduto;
    Sequence playerTween, backgroundTween;
    


    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
        bolla.transform.localScale = Vector3.one*0.2f;
        bolla.transform.localPosition = new Vector3(1.62f, -1.19f, 0.1f);
        playerTween = Sequence.Create()
            .Group(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.2f, -2.6f, 0.1f), duration: 1.5f, ease: Ease.InOutSine))
            //.Group(Tween.Scale(bolla.transform, endValue: new Vector3(1, 1, 1), duration: 1f, ease: Ease.InOutSine))
            .Chain(Tween.Alpha(player.GetComponent<SpriteRenderer>(), endValue: 0, duration: 1, ease: Ease.Linear))
            .Chain(Tween.Delay(1f)).OnComplete(target: this, target=> {
                NextAnimation();
            });
        backgroundTween = Sequence.Create()
            .Group(Tween.Delay(1.5f))
            .Chain(Tween.Alpha(ImageA.GetComponent<SpriteRenderer>(), endValue: 0, duration: 1, ease: Ease.Linear))
            .Chain(Tween.Delay(1f)).OnComplete(target: this, target => NextAnimation());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextAnimation()
    {
        Tween.StopAll();
        //ImageC.transform.localPosition = Vector3.down*10.5f;
        Background.transform.localPosition = Vector3.down * 10;
        bolla.transform.position = new Vector3(0.86f, 3.52f, 0.1f);

        backgroundTween = Sequence.Create()
            .Group(Tween.Alpha(ImageC.GetComponent<SpriteRenderer>(), endValue: 1, duration: 0.1f, ease: Ease.InOutSine))
            //.Group(Tween.Alpha(Background.GetComponent<SpriteRenderer>(), endValue: 1, duration: 0.1f, ease: Ease.InOutSine))
            .Group(Tween.Alpha(ImageB.GetComponent<SpriteRenderer>(), endValue: 1, duration: 1, ease: Ease.InOutSine))
            //.Group(Tween.LocalPosition(ImageB.transform, endValue: new Vector3(0f, 11, 0f), duration: 5f, ease: Ease.Linear))
            //.Group(Tween.LocalPosition(ImageC.transform, endValue: new Vector3(0f, 11, 0f), duration: 10, ease: Ease.Linear))
            .Group(Tween.LocalPosition(Background.transform, endValue: new Vector3(0f, 11f, 0f), duration: 10f, ease: Ease.Linear));
        playerTween = Sequence.Create()
            .Group(Tween.Alpha(player.GetComponent<SpriteRenderer>(), endValue: 1, duration: 1f, ease: Ease.InOutSine))
            .Group(Tween.Alpha(bolla.GetComponent<SpriteRenderer>(), endValue: 1, duration: 1f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-0.33f, 1.58f, 0.1f), duration: 3f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(0.86f, -1.52f, 0.1f), duration: 3f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-0.33f, -3.58f, 0.1f), duration: 3f, ease: Ease.InOutSine))
            .Chain(Tween.Delay(1.5f))
            .OnComplete(target: this, target => ShowMenu());
    }

    void ShowMenu()
    {
        Tween.StopAll();
        particles.SetActive(true);
        player.GetComponent<SpriteRenderer>().sprite = seduto;
        canvas.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Scene_Controller.LoadScene(1);
    }

    public void Credit()
    {
        Scene_Controller.GetCredit();
    }
}
