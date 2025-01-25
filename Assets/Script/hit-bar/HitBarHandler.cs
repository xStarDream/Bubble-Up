using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarHandler : MonoBehaviour
{
    [SerializeField] Bar Bar;
    [SerializeField] BubbleCharacter bubblePlayer;
    [SerializeField] BubbleCharacter bubbleNPC;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Bar.isAtCenter && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            //MoveBubble(bubblePlayer, 1);
            //MoveBubble(bubbleNPC, -1);
        }
        // if ((position == BarPosition.At_Up || position == BarPosition.At_Down) && Input.GetMouseButtonDown(0))
        // {
        //     isBarKeyDOwn = false;
        //     Debug.Log("Tasto premuto: " + isBarKeyDOwn);
        // }
    }

    void MoveBubble(BubbleCharacter bubbleCharacter, float speed)
    {
        Vector3 newPosition = bubbleCharacter.transform.position;
        newPosition.x += speed;
        bubbleCharacter.transform.position = newPosition;
    }
    
}
