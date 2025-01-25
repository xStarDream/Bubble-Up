using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoryboardManager : MonoBehaviour
{
    [SerializeField] Dictionary<float, Sprite> Scenes;
    UnityEngine.UI.Image ImageA, ImageB;
    bool odds = false;
    Canvas canvas;


    float timePassed =0f;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (Scenes.TryGetValue(timePassed, out var scenes))
        {
            odds = !odds;
            if (odds)
            {
                ImageB.sprite = scenes;
                ImageA.CrossFadeAlpha(0, 2.0f, true);
                ImageB.CrossFadeAlpha(1, 2.0f, true);
            }
            else
            {
                ImageA.sprite = scenes;
                ImageB.CrossFadeAlpha(0, 2.0f, true);
                ImageA.CrossFadeAlpha(1, 2.0f, true);
            }
        }
    }
}
