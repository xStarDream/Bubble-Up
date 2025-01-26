using System.Collections;
using UnityEngine;

public class BubbleMB : MonoBehaviour
{
    // PlayerMB Player;
    // Vector3 originalScale;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     Player = GetComponentInParent<PlayerMB>();
    //     originalScale = transform.localScale;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     StartCoroutine(UpdateBubble(Player.Current_hp));
    //     Player.Current_hp--;
    //     Debug.Log(Player.Current_hp);
    // }

    // IEnumerator UpdateBubble(float newHP)
    // {
    //     float currentScale = transform.localScale.x;
    //     float targetScale = originalScale.x * newHP / Player.Max_Hp; // Assuming 100 is the max HP
    //     float changeSpeed = 0.1f;

    //     while (Mathf.Abs(currentScale - targetScale) > Mathf.Epsilon)
    //     {
    //         currentScale = Mathf.Lerp(currentScale, targetScale, changeSpeed * Time.deltaTime);
    //         transform.localScale = new Vector3(currentScale, currentScale, originalScale.z);
    //         yield return null;
    //     }
    //     transform.localScale = new Vector3(targetScale, targetScale, originalScale.z);
    // }
}
