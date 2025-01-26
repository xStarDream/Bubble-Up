using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarState
{
    ToLeft,
    ToRight
}

public enum BarPosition
{
    At_Left,
    At_Center,
    At_Right
}

public class Bar : MonoBehaviour
{
    [SerializeField] LimitLeft LimitLeft;
    [SerializeField] LimitRight LimitRight;
    [SerializeField] LeftSquare Left_Square;
    [SerializeField] RightSquare Right_Square;
    [SerializeField] CenterSquare Center_Square;
    [SerializeField] float speed = 0.5f;

    Collider2D trigger_center;
    BarState state;
    BarPosition position;
    public bool isAtCenter = false;
    // bool isBarKeyDOwn = false;

    void Start()
    {
        state = BarState.ToLeft;
        trigger_center = Center_Square.GetComponent<Collider2D>();
    }

    void Update()
    {


    }

    public void MoveTo(Vector3 direction, float targetX, BarState nextState)
    {
        float newX = transform.position.x + direction.x * speed * Time.deltaTime;
        if ((direction.x > 0 && newX >= targetX) || (direction.x < 0 && newX <= targetX))
        {
            transform.position = new Vector3(targetX, transform.position.y);
            state = nextState;
        }
        else
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == trigger_center)
        {
            isAtCenter = true;
#if UNITY_EDITOR
            //Debug.Log("Bar is at center");
#endif
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == trigger_center)
        {
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
    public LimitLeft Limit_Left { get => LimitLeft; set => LimitLeft = value; }
    public LimitRight Limit_Right { get => LimitRight; set => LimitRight = value; }
}
