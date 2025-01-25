using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // La camera principale
    private PlayerInput input;

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

    private void DetectAndDestroy()
    {
        // Posizione del mouse
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Raycast 2D
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Npc"))
        {
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


                // Distruggi l'oggetto dopo che l'animazione è terminata
                StartCoroutine(DestroyAfterAnimation(objAnimator, hit.collider.gameObject));
            }
        }
        else
        {
            Debug.Log("Nessun oggetto con tag 'Npc' colpito");
        }
    }

    private IEnumerator DestroyAfterAnimation(Animator animator, GameObject obj)
    {
        // Aspetta fino alla fine dell'animazione corrente
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Distruggi l'oggetto
        Destroy(obj);
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
