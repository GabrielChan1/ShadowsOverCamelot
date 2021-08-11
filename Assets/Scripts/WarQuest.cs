using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarQuest : Quest
{
    private int invaders;       // The number of invaders that have landed
    [SerializeField] private string enemy;      // Flag determining whether the invaders are Picts or Saxons
    [HideInInspector] public bool mordredActive;       // Flag determining whether the Mordred card is active on this quest
    [SerializeField] private Transform opponentPanel;       // Panel displaying opponent's strength
    [SerializeField] private Transform playerPanel;     // Panel displaying player's strength

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        questName = enemy;
        invaders = 0;
        mordredActive = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (invaders >= 4)
        {
            FailQuest(1, 1);
        }
        if (mordredActive)
        {
            if (cardsPlayed.Count >= 6)
            {
                WinQuest(1, 4, 1);
            }
        }
        else
        {
            if (cardsPlayed.Count >= 5)
            {
                WinQuest(1, 4, 1);
            }
        }
    }

    protected override void WinQuest(int swords, int cards, int life)
    {
        base.WinQuest(swords, cards, life);
        Debug.Log("Resetting number of pict invaders");
        invaders = 0;
        // Mordred is removed whenever a Picts or Saxons war ends
        if (mordredActive)
        {
            Debug.Log("Removing mordred");
            mordredActive = false;
        }
    }

    protected override void FailQuest(int swords, int life)
    {
        base.FailQuest(swords, life);
        Debug.Log("Adding siege engines");
        ShadowsOverCamelot.Instance.siegeEngineCounter.AddSiegeEngines(2);
        Debug.Log("Resetting number of pict invaders");
        invaders = 0;
        // Mordred is removed whenever a Picts or Saxons war ends
        if (mordredActive)
        {
            Debug.Log("Removing mordred");
            mordredActive = false;
        }
    }

    public void ConfirmChoice()
    {
        // Add the card to the list of white cards committed to this quest
        Card card = dz.playersChoice[0];
        cardsPlayed.Add(card);
        card.transform.SetParent(playerPanel);
        dz.playersChoice.Clear();

        // Reset the drop zone buttons for the next card to be dropped
        dz.cancelButton.gameObject.SetActive(false);
        dz.confirmButton.gameObject.SetActive(false);
        dz.SetVisibility(false);
    }
}
