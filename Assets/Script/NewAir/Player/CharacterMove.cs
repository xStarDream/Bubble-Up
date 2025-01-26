using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public Rigidbody2D rb; // Rigidbody2D per la pallina
    public static Vector2 targetPosition;
    private bool isMoving;
    private PlayerInput input;
    public float speed = 5f; // Velocità di movimento
    float speedMultiplier = 1f; // Moltiplicatore di velocità per il movimento sinistro

    public Vector2 worldPosition;

    private bool cooldown = false; // Per verificare se il tasto destro è in cooldown
    private float rightClickCooldownTime = 0.75f; // Durata del cooldown in secondi

    float multiply = 1f;

    public Animator animator;  // Riferimento all'Animator


    void Awake()
    {
        input = new PlayerInput();

        // Assegna l'input per il click del mouse
        input.CharacterControls.MouseSxDx.started += ctx =>
        {
            if (ctx.control.name == "leftButton")
            {
                multiply = 1f;
                Debug.Log("entrato leftbutton");
                animator.SetBool("IsMove", true);
                //animator.SetBool("Sprint", false);
                isMoving = true; // Avvia il movimento
                
            }
        };

        input.CharacterControls.MouseSxDx.performed += ctx =>
        {
            if (ctx.control.name == "rightButton" && !cooldown)
            {
                animator.SetBool("Sprint", true);

                StartCoroutine(HandleRightClickCooldown()); // Avvia la coroutine per il cooldown
                HandleRightClick(); // Gestisce il click destro
            }
        };

        input.CharacterControls.MouseSxDx.canceled += ctx =>
        {
            if (ctx.control.name == "leftButton")
            {
                isMoving = false; // Ferma il movimento quando il tasto sinistro è rilasciato
            }
        };
    }

    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
        // Evita che la pallina parta con qualche velocità strana
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private void HandleRightClick()
    {
        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        // Converti la posizione del mouse in coordinate del mondo
        worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        // Imposta il targetPosition (con Z=0 per il 2D)
        targetPosition = new Vector2(worldPosition.x, worldPosition.y);
        multiply = 1.5f;
        // Muovi la pallina direttamente verso il target con velocità costante
        MoveTowardsTarget(speed);
    }

    private void HandleClick(float multiplier)
    {
        // Imposta la velocità di movimento per il tasto sinistro
        speedMultiplier = multiplier;
        // Aggiorna la posizione del target
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        targetPosition = new Vector2(worldPosition.x, worldPosition.y);
    }

    private void FixedUpdate()
    {
        float stopDistance = 0.1f; // Distanza tollerata prima di fermarsi
        if (isMoving)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            targetPosition = new Vector2(worldPosition.x, worldPosition.y);

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, (speed * speedMultiplier) * Time.fixedDeltaTime));

            // Imposta il parametro 'isMoving' su true quando il personaggio si muove
            animator.SetBool("IsMove", true);
        }
        else
        {
            if (Vector2.Distance(rb.position, targetPosition) > stopDistance)
            {
                MoveTowardsTarget(speed);
            }
            else
            {
                rb.velocity = Vector2.zero; // Ferma la pallina quando è abbastanza vicina al target
                // Imposta il parametro 'isMoving' su false quando il personaggio è fermo
                animator.SetBool("IsMove", false);
                //animator.SetBool("Sprint", false);
            }
        }
    }

    private void MoveTowardsTarget(float moveSpeed)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed * multiply; // Muovi la pallina verso il target
    }

    private IEnumerator HandleRightClickCooldown()
    {
        animator.SetBool("Sprint", false);
        cooldown = true; // Attiva il cooldown
        yield return new WaitForSeconds(rightClickCooldownTime); // Aspetta per il tempo del cooldown
        cooldown = false; // Disabilita il cooldown
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
