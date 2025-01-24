using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBar : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public GameObject center;

    public Bar bar;

    public bool isBarAtCenter = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bar.State == BarState.ToUp)
        {
            MoveBar(Vector3.up, up.transform.position.y, BarState.ToDown);
        }
        else if (bar.State == BarState.ToDown)
        {
            MoveBar(Vector3.down, down.transform.position.y, BarState.ToUp);
        }

        if (isBarAtCenter && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bingo");
        }
    }

    private void MoveBar(Vector3 direction, float targetY, BarState nextState)
    {
        float newY = bar.transform.position.y + direction.y * bar.speed * Time.deltaTime;
        if ((direction.y > 0 && newY >= targetY) || (direction.y < 0 && newY <= targetY))
        {
            bar.transform.position = new Vector3(bar.transform.position.x, targetY);
            bar.State = nextState;
        }
        else
        {
            bar.transform.position += bar.speed * Time.deltaTime * direction;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == center)
        {
            isBarAtCenter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == center)
        {
            isBarAtCenter = false;
        }
    }
}
