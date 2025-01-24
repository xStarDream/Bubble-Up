using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public Rigidbody2D rb; // Rigidbody2D per la pallina
    private Vector2 targetPosition;
    private bool isMoving;
    private PlayerInput input;
    public float speed = 5f; // Velocità di movimento

    void Awake()
    {
        input = new PlayerInput();

        // Assegna l'input per il click del mouse
        input.CharacterControls.MouseSxDx.performed += ctx =>
        {
            if (ctx.control.name == "leftButton")
            {
                HandleLeftClick();
            }
        };
    }

    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
        //evito che la pallina parta con qualche velocita strana
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private void HandleLeftClick()
    {
        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Converti la posizione del mouse in coordinate del mondo
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Imposta il targetPosition (con Z=0 per il 2D)
        targetPosition = new Vector2(worldPosition.x, worldPosition.y);
        isMoving = true;
    }

    private void FixedUpdate()
    {
        Debug.Log("Pallina: " + rb.position + " Target: " + targetPosition);

        if (isMoving)
        {
            // Movimento fluido con Rigidbody2D
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

            // Ferma il movimento quando raggiunge il target
            if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
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

    /*
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Rigidbody2D rb;

    Vector3 targetPosition;
    bool isMoving; //non so se utile
    PlayerInput input;
    public float speed = 5f; // Velocità di movimento

    void Awake()
    {
        input = new PlayerInput();

        // Assegna l'input per il click del mouse
        input.CharacterControls.MouseSxDx.performed += ctx =>
        {
            if (ctx.control.name == "leftButton") // Controlla se è stato cliccato il tasto sinistro
            {
                HandleLeftClick();
            }
            else if (ctx.control.name == "rightButton") // Controlla se è stato cliccato il tasto destro
            {
                HandleRightClick();
            }
        };
    }

    void Start()
    {
        // Posizione iniziale del target è la posizione della pallina
        targetPosition = transform.position;
        isMoving = false;

    }

    private void HandleLeftClick()
    {
        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Converti la posizione del mouse in coordinate del mondo
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Imposta la posizione target al punto in cui il ray colpisce
            targetPosition = hit.point;
            isMoving = true;
        }
    }

    private void HandleRightClick()
    {
        // Puoi definire un comportamento per il clic destro
        Debug.Log("Right mouse button clicked!");
    }

    /*public void OnClick(InputValue value)
    {
        // Ottieni la posizione del mouse in coordinate dello schermo
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Converti la posizione del mouse in coordinate del mondo
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Imposta la posizione target al punto in cui il ray colpisce
            targetPosition = hit.point;
            isMoving = true;
        }
    }*/
    /*
    private void Update()
    {
        if (isMoving)
        {
            // Movimento fluido verso il target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Ferma il movimento quando raggiunge il target
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    private void OnEnable()
    {
        // Abilita la mappa di controllo del player
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        // Disabilita la mappa di controllo del player
        input.CharacterControls.Disable();
    }*/
}
