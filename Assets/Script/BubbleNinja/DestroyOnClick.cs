using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // La camera principale
    private PlayerInput input;
    float secretScore = 3f;
    bool dead = false;
    [SerializeField] FadeIn fadeIn;
    [SerializeField] GameObject puls1;
    [SerializeField] GameObject puls2;
    public AudioSource bop;

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

        StartCoroutine(DurataLivello());
    }

    private void Update()
    {
        if (dead == false)
        {
            if (secretScore <= 0f)
            {
                Debug.Log("condizione avverata sconfitta");
                dead = true;
                fadeIn.StartFadeIn();
                puls1.SetActive(true);
                puls2.SetActive(true);

            }
            else if (secretScore > 6f)
            {
                Debug.Log("condizione avverata vittoria punti");
                dead = true;
                Scene_Controller.NextLevel();
                Debug.Log("CAMBIO SCENA NEXT LEVEL");
            }
        }
    }

    private void DetectAndDestroy()
    {
        // Posizione del mouse
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Raycast 2D
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Good"))
        {
            Debug.Log("secretscore " + secretScore);
            secretScore -= 1f;

            // Ottieni l'animator dall'oggetto colpito
            Animator objAnimator = hit.collider.GetComponent<Animator>();

            if (objAnimator != null)
            {
                var exp = Random.Range(0, 2);
                if (exp == 0)
                {
                    // Attiva l'animazione di esplosione
                    objAnimator.SetTrigger("Explosion");
                }
                else
                {
                    // Attiva l'animazione di esplosione
                    objAnimator.SetTrigger("Explosion2");
                }
                bop.Play();



                // Distruggi l'oggetto dopo che l'animazione è terminata
                StartCoroutine(DestroyAfterAnimation(objAnimator, hit.collider.gameObject));
            }
        }
        else if (hit.collider != null && hit.collider.CompareTag("Bad"))
        {
            secretScore += 1f;

            // Ottieni l'animator dall'oggetto colpito
            Animator objAnimator = hit.collider.GetComponent<Animator>();

            if (objAnimator != null)
            {
                var exp = Random.Range(0, 2);
                if (exp == 0)
                {
                    // Attiva l'animazione di esplosione
                    objAnimator.SetTrigger("Explosion");
                }
                else
                {
                    // Attiva l'animazione di esplosione
                    objAnimator.SetTrigger("Explosion2");
                }
                bop.Play();


                // Distruggi l'oggetto dopo che l'animazione è terminata
                StartCoroutine(DestroyAfterAnimation(objAnimator, hit.collider.gameObject));
            }

            else
            {
                Debug.Log("Nessun oggetto con tag 'Npc' colpito");
            }
            Debug.Log("secret score " + secretScore);
        }
    }

    private IEnumerator DestroyAfterAnimation(Animator animator, GameObject obj)
    {
        // Aspetta fino alla fine dell'animazione corrente
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Distruggi l'oggetto
        Destroy(obj);
    }

    public IEnumerator DurataLivello()
    {
        yield return new WaitForSeconds(42f);
        Debug.Log("CAMBIO SCENA FINE LIVELLO");
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }
}
