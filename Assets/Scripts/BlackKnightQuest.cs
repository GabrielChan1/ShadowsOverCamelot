using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackKnightQuest : Quest
{
    [HideInInspector] public List<Card> blackCards;     // Black cards that have been played on this quest
    [HideInInspector] public int opponentStrength;      // Total value of black cards played on this quest
    [HideInInspector] public int playerStrength;        // Total value of white cards played on this quest
    [SerializeField] private Transform opponentPanel;       // Panel displaying opponent's strength
    [SerializeField] private Transform playerPanel;     // Panel displaying player's strength
    [SerializeField] private Text opponentStrengthDisplay;
    [SerializeField] private Text playerStrengthDisplay;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        questName = "BlackKnight";
        blackCards = new List<Card>();
        opponentStrength = 0;
        playerStrength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cardsPlayed.Count == 4 || blackCards.Count == 4)
        {
            if (playerStrength > opponentStrength)
            {
                WinQuest(1, 3, 1);
            }
            else
            {
                FailQuest(1, 1);
            }
        }

        opponentStrengthDisplay.text = "Strength: " + opponentStrength.ToString();
        playerStrengthDisplay.text = "Strength: " + playerStrength.ToString();
    }

    protected override void WinQuest(int swords, int cards, int life)
    {
        base.WinQuest(swords, cards, life);
        blackCards.Clear();
    }

    protected override void FailQuest(int swords, int life)
    {
        base.FailQuest(swords, life);
        blackCards.Clear();
    }

    public void ConfirmChoice()
    {
        // Add the card to the list of white cards committed to this quest
        Card card = dz.playersChoice[0];
        cardsPlayed.Add(card);
        card.transform.SetParent(playerPanel);
        dz.playersChoice.Clear();

        // Add the card's fight value to the strength counter
        if (card.cardName.Equals("Fight1"))
        {
            playerStrength++;
        }
        else if (card.cardName.Equals("Fight2"))
        {
            playerStrength += 2;
        }
        else if (card.cardName.Equals("Fight3"))
        {
            playerStrength += 3;
        }
        else if (card.cardName.Equals("Fight4"))
        {
            playerStrength += 4;
        }
        else if (card.cardName.Equals("Fight5"))
        {
            playerStrength += 5;
        }

        // Reset the drop zone buttons for the next card to be dropped
        dz.cancelButton.gameObject.SetActive(false);
        dz.confirmButton.gameObject.SetActive(false);
        dz.SetVisibility(false);
    }
}
