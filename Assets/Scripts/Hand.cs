using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Deck whiteDeck;          // Reference to the white deck
    [SerializeField] private Knight knight;           // Knight that this hand belongs to
    [HideInInspector] public List<Card> hand;        // List of cards in this hand
    [SerializeField] private CanvasGroup cg;        // Component for making the panel visible or invisible to the player
    public bool isVisible { get; private set; }     // Flag determining if this component is visible to the player

    // Start is called before the first frame update
    void Start()
    {
        hand = new List<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add n cards from the white deck to this hand
    public void DrawCards(int n)
    {
        Card card;
        // For each card drawn
        for (int i = 0; i < n; i++)
        {
            card = whiteDeck.Draw();
            // Add the card to the hand
            hand.Add(card);
            // Set the card transform to be a child of the parent transform
            card.transform.SetParent(transform);
            // Make the card visible to the player
            card.SetVisibility(true);
        }
    }

    // Make this component visible or invisible to the player
    public void SetVisibility(bool setting)
    {
        if (setting)
        {
            cg.alpha = 1f;
        }
        else
        {
            cg.alpha = 0f;
        }
        cg.interactable = setting;
        cg.blocksRaycasts = setting;
        isVisible = setting;
    }
}
