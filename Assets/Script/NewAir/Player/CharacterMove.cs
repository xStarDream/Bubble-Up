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
    float speedMultiplier = 1f;
    public Vector2 worldPosition;

    private bool cooldown = false; // Per verificare se il tasto destro è in cooldown
    private float rightClickCooldownTime = 0.75f; // Durata del cooldown in secondi

    void Awake()
    {
        input = new PlayerInput();

        // Assegna l'input per il click del mouse
        input.CharacterControls.MouseSxDx.performed += ctx =>
        {
            if (ctx.control.name == "leftButton")
            {
                HandleClick(1f);
            }
            if (ctx.control.name == "rightButton" && cooldown == false)
            {
                StartCoroutine(HandleRightClickCooldown()); // Avvia la coroutine per il cooldown
                HandleClick(2f);
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

    private void HandleClick(float multiplier)
    {
        speedMultiplier = multiplier; //aggiorno la speedMultiplier globale

        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Converti la posizione del mouse in coordinate del mondo
        worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Imposta il targetPosition (con Z=0 per il 2D)
        targetPosition = new Vector2(worldPosition.x, worldPosition.y);
        isMoving = true;
    }

    private void FixedUpdate()
    {
        // Verifica che il player non sia dentro il limite prima di muoversi
        if (isMoving)
        {
            // Movimento fluido con Rigidbody2D
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, (speed * speedMultiplier) * Time.fixedDeltaTime));

            // Ferma il movimento quando raggiunge il target
            if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                speedMultiplier = 1f;
            }
        }
    }

    private IEnumerator HandleRightClickCooldown()
    {
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
