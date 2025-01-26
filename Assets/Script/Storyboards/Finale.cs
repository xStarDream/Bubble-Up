using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class Finale : MonoBehaviour
{
    [SerializeField] GameObject ImageA, FadeWhite, Background;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject player, friend, bolla, playerFree, BublePop;
    [SerializeField]
    GameObject particles;
    [SerializeField] Sprite[] playerSprite;
    [SerializeField] Sprite[] friendSprite;
    [SerializeField] private Camera mainCamera; // La camera principale

    public AudioSource bop;
    public Animator animator;
    private PlayerInput input;

    Sequence playerTween, backgroundTween, friendTween;

    private void Awake()
    {
        input = new PlayerInput();

        // Listener per il click sinistro
        input.CharacterControls.MouseSxDx.started += ctx =>
        {
            if (ctx.control.name == "leftButton")
            {
                DetectAndDestroy();
            }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        bolla.transform.localScale = Vector3.one * 0.4f;
        bolla.transform.localPosition = new Vector3(0f, -3.50f, 0.1f);
        BublePop.gameObject.GetComponent<Collider2D>().enabled=false;
        playerTween = Sequence.Create()
            .Group(Tween.LocalPosition(bolla.transform, endValue: new Vector3(0.0f, 2.8f, 0.1f), duration: 8f, ease: Ease.InOutSine))
            //.Group(Tween.Scale(bolla.transform, endValue: new Vector3(1, 1, 1), duration: 1f, ease: Ease.InOutSine))
            .Chain(Tween.Custom(new Color(255, 255, 255, 0.0f), endValue: new Color(255, 255, 255, 1.0f), duration: 4f, onValueChange: newVal => FadeWhite.GetComponent<Image>().color = newVal))
            .Chain(Tween.Delay(1f))
            .OnComplete(target: this, target =>
            {
                NextAnimation();
            });
        backgroundTween = Sequence.Create()
                   .Chain(Tween.Delay(4f));
        //.Group(Tween.Alpha(ImageC.GetComponent<SpriteRenderer>(), endValue: 1, duration: 0.1f, ease: Ease.InOutSine))
        //.Group(Tween.Alpha(Background.GetComponent<SpriteRenderer>(), endValue: 1, duration: 0.1f, ease: Ease.InOutSine))
        //.Group(Tween.LocalPosition(ImageB.transform, endValue: new Vector3(0f, 11, 0f), duration: 5f, ease: Ease.Linear))
        //.Group(Tween.LocalPosition(ImageC.transform, endValue: new Vector3(0f, 11, 0f), duration: 10, ease: Ease.Linear))
        //.Group(Tween.LocalPosition(Background.transform, endValue: new Vector3(0f, 11f, 0f), duration: 10f, ease: Ease.Linear));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NextAnimation()
    {
        Debug.Log("spiaggia");
        Background.SetActive(false);
        ImageA.SetActive(true);
        bolla.SetActive(false);
        playerFree.SetActive(true);
        playerTween = Sequence.Create()
            .Chain(Tween.Custom(Color.white, endValue: new Color(255, 255, 255, 0.0f), duration: 4f, onValueChange: newVal => FadeWhite.GetComponent<Image>().color = newVal));
        BublePop.GetComponent<Collider2D>().enabled = true;
        Tween.Scale(BublePop.transform, endValue: new Vector3(4f, 4f, 1f), duration: 1f, ease: Ease.InOutSine, cycles: -1, cycleMode: CycleMode.Yoyo);

    }

    public void BubblePop()
    {
        animator.SetBool("explosion", true);
        Debug.Log("PooP");
        Tween.StopAll();
        //BublePop.SetActive(false);
        playerTween = Sequence.Create()
            .Group(Tween.Delay(1f))
            .Chain(Tween.Position(playerFree.transform, endValue: new Vector3(1.62f, -1.19f, 0.1f), duration: 5f, ease: Ease.InOutSine))
            .Group(Tween.Alpha(BublePop.GetComponent<SpriteRenderer>(),endValue:0f,duration:0.01f,ease: Ease.Linear))
            .OnComplete(target:this, target=>CallCredit());

    }

    private void DetectAndDestroy()
    {
        // Posizione del mouse
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Raycast 2D
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            BubblePop();
            BublePop.GetComponent<Collider2D>().enabled = false;
            // Ottieni l'animator dall'oggetto colpito
            Animator objAnimator = hit.collider.GetComponent<Animator>();

            // Attiva l'animazione di esplosione
            objAnimator.SetTrigger("Explosion");
            bop.Play();
        }

        else
        {
            Debug.Log("Nessun oggetto con tag 'Npc' colpito");
        }
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }
    void CallCredit()
    {
        Scene_Controller.GetCredit();
    }
}

