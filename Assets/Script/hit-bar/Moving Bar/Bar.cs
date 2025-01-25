using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BarState
{
    ToUp,
    ToDown
}
public class Bar : MonoBehaviour
{
    [SerializeField] LimitUp Limit_Up;
    [SerializeField] LimitDown Limit_Down;
    [SerializeField] CenterSquare Center_Square;
    [SerializeField] float speed;

    Collider2D trigger_center;
    BarState state;
    public bool isBarAtCenter = false;
    bool isBarKeyDOwn = false;
    // Start is called before the first frame update
    void Start()
    {
        state = BarState.ToUp;
        trigger_center = Center_Square.GetComponent<Collider2D>();
        // Debug.Log(trigger_center.isTrigger);
        // Debug.Log($"Limit_Up Y: {Limit_Up.transform.position.y}, Limit_Down Y: {Limit_Down.transform.position.y}");

    }

    // Update is called once per frame
    void Update()
    {
        if (State == BarState.ToUp)
        {
            MoveBar(Vector3.up, Limit_Up.transform.position.y, BarState.ToDown);
        }
        else if (State == BarState.ToDown)
        {
            MoveBar(Vector3.down, Limit_Down.transform.position.y, BarState.ToUp);
        }

        if (isBarAtCenter && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bingo");
            isBarKeyDOwn = true;
            Debug.Log("Tasto premuto: " + isBarKeyDOwn);
        }
    }

        private void MoveBar(Vector3 direction, float targetY, BarState nextState)
    {
        // Debug.Log($"Moving in direction: {direction}, Target Y: {targetY}, Current Y: {transform.position.y}");
        float newY = transform.position.y + direction.y * Speed * Time.deltaTime;
        if ((direction.y > 0 && newY >= targetY) || (direction.y < 0 && newY <= targetY))
        {
            transform.position = new Vector3(transform.position.x, targetY);
            State = nextState;
        }
        else
        {
            transform.position += Speed * Time.deltaTime * direction;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == trigger_center)
        {
            isBarAtCenter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other == trigger_center)
        {
            isBarAtCenter = false;
        }
    }
    public BarState State
    {
        get { return state; }
        set { state = value; }
    }

    public float Speed { get => speed; set => speed = value; }
}
