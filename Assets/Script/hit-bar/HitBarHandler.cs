using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarHandler : MonoBehaviour
{
    [SerializeField] PlayerMB Player;
    [SerializeField] Bar Bar;

    [SerializeField] BubbleMB bubble;

    Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = new Vector3(0.5f,0.5f,0.5f);
        transform.position = originalScale;
        StartCoroutine(ReduceHealthOverTime());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float HP_Percentage = (float)Player.Current_hp / Player.Max_Hp;
        StartCoroutine(UpdateBubble(HP_Percentage));
        Debug.Log(HP_Percentage);
        if (Player.Current_hp <= 0)
        {
            Debug.Log("You lose...");
        }

        if (Bar.Position == BarPosition.At_Center && Input.GetMouseButtonDown(0))
        {
            Player.Current_hp += 10;

            if (Player.Current_hp > Player.Max_Hp)
            {
                Player.Current_hp = Player.Max_Hp;
            }
        }
        // if ((position == BarPosition.At_Up || position == BarPosition.At_Down) && Input.GetMouseButtonDown(0))
        // {
        //     isBarKeyDOwn = false;
        //     Debug.Log("Tasto premuto: " + isBarKeyDOwn);
        // }
    }

    IEnumerator UpdateBubble(float newHP)
    {
        float current_hp = bubble.transform.localScale.x;
        float change_hp = current_hp - newHP;

        while (current_hp - newHP > Mathf.Epsilon)
        {
            current_hp -= change_hp * Time.deltaTime;
            bubble.transform.localScale = new Vector3(originalScale.x * current_hp, originalScale.y * current_hp, originalScale.z);
            yield return null;
        }
        bubble.transform.localScale = new Vector3(originalScale.x * newHP, originalScale.y * newHP);
    }

    IEnumerator ReduceHealthOverTime()
    {
        while (Player.Current_hp > 0)
        {
            yield return new WaitForSeconds(1);
            Player.Current_hp--;
        }
    }
}
