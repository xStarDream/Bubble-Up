using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMB : MonoBehaviour
{
    [SerializeField] int max_hp;
    // [SerializeField] BubbleMB bubble;
    int current_hp;

    public int Max_Hp { get => max_hp; set => max_hp = value; }
    public int Current_hp { get => current_hp; set => current_hp = value; }
    // public BubbleMB Bubble { get => bubble; set => bubble = value; }

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
