using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarState
{
    ToUp,
    ToDown
}

public enum BarPosition
{
    At_Up,
    At_Center,
    At_Down
}

public class Bar : MonoBehaviour
{
    [SerializeField] LimitUp Limit_Up;
    [SerializeField] LimitDown Limit_Down;
    [SerializeField] UpSquare Up_Square;
    [SerializeField] DownSquare Down_Square;
    [SerializeField] CenterSquare Center_Square;
    [SerializeField] float speed;

    Collider2D trigger_up;
    Collider2D trigger_center;
    Collider2D trigger_down;
    BarState state;
    BarPosition position;
    public bool isAtCenter = false;
    // bool isBarKeyDOwn = false;

    void Start()
    {
        state = BarState.ToUp;
        trigger_center = Center_Square.GetComponent<Collider2D>();
        trigger_up = Up_Square.GetComponent<Collider2D>();
        trigger_down = Down_Square.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (state == BarState.ToUp)
        {
            MoveBar(Vector3.up, Limit_Up.transform.position.y, BarState.ToDown);
        }
        else if (state == BarState.ToDown)
        {
            MoveBar(Vector3.down, Limit_Down.transform.position.y, BarState.ToUp);
        }

    }

    private void MoveBar(Vector3 direction, float targetY, BarState nextState)
    {
        float newY = transform.position.y + direction.y * speed * Time.deltaTime;
        if ((direction.y > 0 && newY >= targetY) || (direction.y < 0 && newY <= targetY))
        {
            transform.position = new Vector3(transform.position.x, targetY);
            state = nextState;
        }
        else
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == trigger_up)
        {
            Position = BarPosition.At_Up;
            isAtCenter = false;
        }
        if (other == trigger_center)
        {
            Position = BarPosition.At_Center;
            isAtCenter = true;
        }
        if (other == trigger_down)
        {
            Position = BarPosition.At_Down;
            isAtCenter = false;
        }
    }

    public BarState State
    {
        get { return state; }
        set { state = value; }
    }

    public float Speed { get => speed; set => speed = value; }
    public BarPosition Position { get => position; set => position = value; }
}
