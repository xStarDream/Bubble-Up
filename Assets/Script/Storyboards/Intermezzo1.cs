using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermezzo1 : MonoBehaviour
{

    [SerializeField] GameObject ImageA, ImageB, ImageC, Background;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject player, bolla;
    [SerializeField] GameObject particles;
    [SerializeField] Sprite seduto;
    Sequence playerTween, backgroundTween;


    // Start is called before the first frame update
    void Start()
    {
        //particles.SetActive(true);
        bolla.transform.localScale = Vector3.one * 0.2f;
        bolla.transform.localPosition = new Vector3(0.42f, -3.64f, 0.1f);
        playerTween = Sequence.Create()
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(0.35f, -2.68f, - 0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.7f, -1.15f, - 0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(0.63f, 1.46f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            .Chain(Tween.LocalPosition(bolla.transform, endValue: new Vector3(-1.7f, 5.92f, -0.1f), duration: 2f, ease: Ease.InOutSine))
            //.OnComplete(target:this , target=> NextScene());
        ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextScene()
    {
        Scene_Controller.NextLevel();
    }
}
