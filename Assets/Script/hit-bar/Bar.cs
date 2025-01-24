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
    private BarState state;
    public BarState State
    {
        get { return state; }
        set { state = value; }
    }
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        state = BarState.ToUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
