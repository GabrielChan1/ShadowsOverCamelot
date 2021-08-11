using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    private List<Card> deck;      // Cards that are still in the deck
    private List<Card> discard;       // Cards that have gone into the discard pile
    [SerializeField] private char type;     // Flag determining whether the deck is black or white
    private static bool deckEmpty;      // Flag determining if either the white or black deck is empty

    [SerializeField] private Text counter;        // UI component displaying the number cards in the deck and discard pile
    [SerializeField] private Card cardPrefab;      // Reference to the card prefab to populate this deck with

    void Awake()
    {
        deck = new List<Card>();
        discard = new List<Card>();
        deckEmpty = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Card card;
        // If the deck is white, create white cards
        if (type.Equals('W'))
        {
            // Create 7 Merlin cards
            for (int i = 0; i < 7; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Merlin", 'W');
                deck.Add(card);
            }
            // Create 14 Fight1 cards
            for (int i = 0; i < 14; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Fight1", 'W');
                deck.Add(card);
            }
            // Create 12 Fight2 cards
            for (int i = 0; i < 12; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Fight2", 'W');
                deck.Add(card);
            }
            // Create 10 Fight3 cards
            for (int i = 0; i < 10; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Fight3", 'W');
                deck.Add(card);
            }
            // Create 8 Fight4 cards
            for (int i = 0; i < 8; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Fight4", 'W');
                deck.Add(card);
            }
            // Create 7 Fight5 cards
            for (int i = 0; i < 7; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Fight5", 'W');
                deck.Add(card);
            }
            // Create 18 Grail cards
            for (int i = 0; i < 18; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Grail", 'W');
                deck.Add(card);
            }
            // Create special white cards
            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Convocation", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Fate", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Heroism", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Lady Of The Lake", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Messenger", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Piety", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Clairvoyance", 'W');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Reinforcements", 'W');
            deck.Add(card);

            Shuffle();
        }
        // If the deck is black, create black cards
        else if (type.Equals('B'))
        {
            // Create 5 Black Knight1 cards
            for (int i = 0; i < 5; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Knight1", 'B');
                deck.Add(card);
            }
            // Create 3 Black Knight3 cards
            for (int i = 0; i < 3; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Knight3", 'B');
                deck.Add(card);
            }
            // Create 2 Black Knight5 cards
            for (int i = 0; i < 2; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Knight5", 'B');
                deck.Add(card);
            }
            // Create 1 Black Knight7 card
            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Knight7", 'B');
            deck.Add(card);
            // Create 15 Despair cards
            for (int i = 0; i < 15; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Despair", 'B');
                deck.Add(card);
            }
            // Create 15 Excalibur cards
            for (int i = 0; i < 15; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Excalibur", 'B');
                deck.Add(card);
            }
            // Create 4 Lancelot1/Dragon5 cards
            for (int i = 0; i < 4; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Lancelot1/Dragon5", 'B');
                deck.Add(card);
            }
            // Create 3 Lancelot3/Dragon7 cards
            for (int i = 0; i < 3; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Lancelot3/Dragon7", 'B');
                deck.Add(card);
            }
            // Create 3 Lancelot5/Dragon9 cards
            for (int i = 0; i < 3; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Lancelot5/Dragon9", 'B');
                deck.Add(card);
            }
            // Create 1 Lancelot7/Dragon11 card
            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Lancelot7/Dragon11", 'B');
            deck.Add(card);
            // Create 4 Mercenaries cards
            for (int i = 0; i < 4; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Mercenaries", 'B');
                deck.Add(card);
            }
            // Create 4 Picts cards
            for (int i = 0; i < 4; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Picts", 'B');
                deck.Add(card);
            }
            // Create 4 Saxons cards
            for (int i = 0; i < 4; i++)
            {
                card = Instantiate<Card>(cardPrefab, transform);
                card.Initialize("Saxons", 'B');
                deck.Add(card);
            }
            // Create special black cards
            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Desolation", 'B');
            deck.Add(card);
            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Desolation", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Dark Forest", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Guinevere", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Mists Of Avalon", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Mordred", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Morgan1", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Morgan2", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Morgan3", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Morgan4", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Morgan5", 'B');
            deck.Add(card);

            card = Instantiate<Card>(cardPrefab, transform);
            card.Initialize("Vivien", 'B');
            deck.Add(card);

            Shuffle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Display the number of cards in the deck and discard pile
        counter.text = deck.Count.ToString() + "/" + discard.Count.ToString();

        // If either deck is empty, shuffle both decks
        if (deck.Count == 0)
        {
            deckEmpty = true;
        }
        if (deckEmpty)
        {
            Shuffle();
            deckEmpty = false;
        }
    }

    // Shuffle this deck
    public void Shuffle()
    {
        // Add all the cards in the discard back into the deck
        deck.AddRange(discard);
        discard.Clear();

        System.Random random = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            Card temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }

    // Draw a card from this deck
    public Card Draw()
    {
        Card card = deck[deck.Count - 1];
        deck.RemoveAt(deck.Count - 1);
        return card;
    }

    // Add a card to the discard deck
    public void Discard(Card card)
    {
        discard.Add(card);
        card.transform.SetParent(transform);
        card.SetVisibility(false);
    }
}
