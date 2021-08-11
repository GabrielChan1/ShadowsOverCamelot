using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camelot : Quest
{
    [SerializeField] protected Deck whiteDeck;        // Reference to the white deck

    // Start is called before the first frame update
    protected override void Start()
    {
        
        base.Start();
        questName = "Camelot";
        if (ShadowsOverCamelot.Instance.arthur != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.arthur);
        }
        if (ShadowsOverCamelot.Instance.galahad != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.galahad);
        }
        if (ShadowsOverCamelot.Instance.gawain != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.gawain);
        }
        if (ShadowsOverCamelot.Instance.kay != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.kay);
        }
        if (ShadowsOverCamelot.Instance.palamedes != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.palamedes);
        }
        if (ShadowsOverCamelot.Instance.percival != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.percival);
        }
        if (ShadowsOverCamelot.Instance.tristan != null)
        {
            activeKnights.Add(ShadowsOverCamelot.Instance.tristan);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Draw()
    {
        if (ShadowsOverCamelot.Instance.currentKnight.hand.hand.Count < 13)
        {
            ShadowsOverCamelot.Instance.currentKnight.hand.DrawCards(2);
        }
    }

    
    public void ConfirmChoice()
    {
        // Attempt to destroy siege engine

        int playerStrength = 0;
        foreach (Card card in dz.playersChoice)
        {
            if (card.cardName.Equals("Fight1"))
            {
                playerStrength += 1;
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
            whiteDeck.Discard(card);
        }
        dz.playersChoice.Clear();

        int opponentStrength = Random.Range(1, 9);

        Debug.Log("Camelot: Player strength: " + playerStrength.ToString());
        Debug.Log("Camelot: Opponent strength " + opponentStrength.ToString());

        if (playerStrength > opponentStrength)
        {
            Debug.Log("Camelot: Victory");
            ShadowsOverCamelot.Instance.siegeEngineCounter.RemoveSiegeEngines(1);
        }
        else
        {
            Debug.Log("Camelot: Defeat");
            ShadowsOverCamelot.Instance.currentKnight.LoseLife(1);
        }

        dz.SetVisibility(false);
    }
    
}
