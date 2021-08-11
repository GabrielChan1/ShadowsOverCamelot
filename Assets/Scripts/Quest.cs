using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName { get; protected set; }                // The name of this quest
    [HideInInspector] public List<Card> cardsPlayed;        // White cards that have been played on this quest
    [HideInInspector] public List<Knight> activeKnights;      // The knights that are currently attempting this quest
    //[SerializeField] protected Deck whiteDeck;        // Reference to the white deck
    public DropZone dz;
    [SerializeField] private CanvasGroup cg;        // Component for making the panel visible or invisible to the player
    public bool isVisible { get; private set; }     // Flag determining if this component is visible to the player

    // Start is called before the first frame update
    protected virtual void Start()
    {
        cardsPlayed = new List<Card>();
        activeKnights = new List<Knight>();
        SetVisibility(false);
        dz.SetVisibility(false);
        isVisible = false;
    }

    protected virtual void WinQuest(int swords, int cards, int life)
    {
        Debug.Log("Quest: Quest " + questName + " has been completed by " + ShadowsOverCamelot.Instance.currentKnight.title);
        Debug.Log("Quest: Now adding " + swords.ToString() + " white swords");
        // Add white swords
        ShadowsOverCamelot.Instance.swordCounter.AddSwords('W', swords);
        int n = 0;
        // Draw and randomly distribute cards to knights on this quest (placeholder implementation; will need to change this later)
        while (n < cards)
        {
            foreach (Knight knight in activeKnights)
            {
                Debug.Log("Quest: Card drawn");
                // Draw white cards
                knight.hand.DrawCards(1);
                n++;
                if (n >= cards)
                {
                    break;
                }
            }
        }

        foreach (Knight knight in activeKnights)
        {
            Debug.Log("Quest: Healing " + knight.title);
            // Add life points
            knight.GainLife(life);
            Debug.Log("Quest: Moving " + knight.title + " back to camelot");
            // Return knight to Camelot quest
            knight.Move(ShadowsOverCamelot.Instance.camelotQuest);
        }
        
        cardsPlayed.Clear();
    }

    protected virtual void FailQuest(int swords, int life)
    {
        Debug.Log("Quest: Quest " + questName + " has been failed");
        Debug.Log("Quest: Now adding " + swords.ToString() + " black swords");
        // Add black swords
        ShadowsOverCamelot.Instance.swordCounter.AddSwords('B', swords);
        // For each knight on this quest
        foreach (Knight knight in activeKnights)
        {
            Debug.Log("Quest: Damaging " + knight.title);
            // Subtract life points
            knight.LoseLife(life);
            Debug.Log("Quest: Moving " + knight.title + " back to camelot");
            // Return knight to Camelot quest
            knight.Move(ShadowsOverCamelot.Instance.camelotQuest);
        }

        cardsPlayed.Clear();
    }

    public void CancelChoice()
    {
        // Return all the cards dropped into the drop zone to the player's hand
        foreach (Card card in dz.playersChoice)
        {
            ShadowsOverCamelot.Instance.currentKnight.hand.hand.Add(card);
            card.transform.SetParent(ShadowsOverCamelot.Instance.currentKnight.hand.transform, false);
        }
        dz.playersChoice.Clear();
        dz.cancelButton.gameObject.SetActive(false);
        dz.confirmButton.gameObject.SetActive(false);
        dz.SetVisibility(false);
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

    public void Close()
    {
        if (dz.playersChoice.Count > 0)
        {
            CancelChoice();
        }
        else
        {
            dz.cancelButton.gameObject.SetActive(false);
            dz.confirmButton.gameObject.SetActive(false);
            dz.SetVisibility(false);
        }
        SetVisibility(false);
    }
}
