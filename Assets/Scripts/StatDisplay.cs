using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    [SerializeField] private Text statText;

    // Update is called once per frame
    void Update()
    {
        statText.text = ShadowsOverCamelot.Instance.currentKnight.title + 
            "\nQuest: " + ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName + 
            "\nLife: " + ShadowsOverCamelot.Instance.currentKnight.life.ToString();
    }
}
