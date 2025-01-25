using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarHandler : MonoBehaviour
{
    public HitBar hitbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            hitbar.gameObject.SetActive(!hitbar.gameObject.activeSelf);
        }
    }
}
