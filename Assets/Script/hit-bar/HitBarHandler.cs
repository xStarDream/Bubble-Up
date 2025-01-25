using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarHandler : MonoBehaviour
{
    [SerializeField] Bar Bar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Bar.Position == BarPosition.At_Center && Input.GetMouseButtonDown(0))
        {

        }
        // if ((position == BarPosition.At_Up || position == BarPosition.At_Down) && Input.GetMouseButtonDown(0))
        // {
        //     isBarKeyDOwn = false;
        //     Debug.Log("Tasto premuto: " + isBarKeyDOwn);
        // }
    }

    
}
