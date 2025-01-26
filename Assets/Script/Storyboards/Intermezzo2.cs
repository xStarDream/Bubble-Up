using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermezzo2 : MonoBehaviour
{
    [SerializeField] GameObject ImageA, ImageB, ImageC, Background;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject player, bolla, bollaFriend,Friend;
    [SerializeField] GameObject particles;
    [SerializeField] Sprite[] spritePlayer,spriteFriend;

    Sequence playerTween, FriendTween;



    // Start is called before the first frame update
    void Start()
    {
        //particles.SetActive(true);

        player.GetComponent<SpriteRenderer>().flipX = true;
        Friend.GetComponent<SpriteRenderer>().flipX = false;
        player.GetComponent<SpriteRenderer>().sprite = spritePlayer[0];
        Friend.GetComponent<SpriteRenderer>().sprite = spriteFriend[0];


        bolla.transform.localScale = Vector3.one * 0.2f;
        bolla.transform.localPosition = new Vector3(0.42f, -3.64f, 0.1f);
        bollaFriend.transform.localScale = Vector3.one * 0.2f;
        bollaFriend.transform.localPosition = new Vector3(1.8f, 3.59f, 0.1f);
        playerTween = Sequence.Create()
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(0.7f, -2.6f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-2.8f, -1.5f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.23f, 0.38f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.8f, 0.38f, -0.1f), duration: 0.5f, ease: Ease.OutSine))
            //.Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.53f, 0.38f, -0.1f), duration: 0.5f, ease: Ease.OutSine))
            
            .OnComplete(target:this , target=> NextAnimation());
        ;

        playerTween = Sequence.Create()
            .Chain(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(0.18f, 3.07f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(2.63f, 1.24f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(0.7f, 0.4f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(1.7f, 0.4f, -0.1f), duration: 0.5f, ease: Ease.OutSine))
            //.Chain(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(1.22f, 0.4f, -0.1f), duration: 0.5f, ease: Ease.OutSine))

            ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NextAnimation()
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
        Friend.GetComponent<SpriteRenderer>().flipX = true;
        player.GetComponent <SpriteRenderer>().sprite = spritePlayer[1];
        Friend.GetComponent<SpriteRenderer>().sprite = spriteFriend[1];
        playerTween = Sequence.Create()
            .Chain(Tween.Delay(4f))
            .Group(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.23f, 0.4f, -0.1f), duration: 0.4f, ease: Ease.InSine))
            .Group(Tween.LocalPosition(bollaFriend.transform, endValue: new Vector3(0.7f, 0.4f, -0.1f), duration: 0.4f, ease: Ease.InSine))
            .OnComplete(target: this, target => NextScene());

        ;
    }
    void NextScene()
    {
        Scene_Controller.NextLevel();
    }
}

