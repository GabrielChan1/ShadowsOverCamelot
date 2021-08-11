using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public string title;        // The name of this Knight
    public Quest currentQuest { get; private set; }      // This knight's current location
    public int life { get; private set; }        // How much life this knight has
    public Hand hand;     // Reference to this Knight's hand
    //private bool actionAvailable;       // Flag determining if this Knight has an action to spend

    // Start is called before the first frame update
    void Start()
    {
        life = 4;
        //Debug.Log(2);
        currentQuest = ShadowsOverCamelot.Instance.camelotQuest;
        //Debug.Log(ShadowsOverCamelot.Instance.camelotQuest.questName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainLife(int n)
    {
        life += n;
        if (life > 6)
        {
            life = 6;
        }
    }

    public void LoseLife(int n)
    {
        life -= n;
        if (life < 0)
        {
            life = 0;
        }
    }

    // Move to a new Quest
    public void Move(Quest newQuest)
    {
        currentQuest.activeKnights.Remove(this);
        newQuest.activeKnights.Add(this);
        currentQuest = newQuest;
    }
}
