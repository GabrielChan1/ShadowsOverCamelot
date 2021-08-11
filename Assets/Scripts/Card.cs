using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName { get; private set; }        // The name of this card
    private char cardType;      // Flag determining whether the card is black or white

    [SerializeField] private Image cardFrame;       // Reference to this card's frame
    [SerializeField] private Text cardText;       // Reference to this card's text
    [SerializeField] private Image cardImage;     // Reference to this cards image
    [SerializeField] private CanvasGroup cg;        // Component for making the card inivisible to the player

    // Drag and Drop variables
    private bool isDragging;
    private bool overQuestDropZone;
    private bool overMiscDropZone;
    private Vector3 startPosition;
    private GameObject dropZone;

    public void Initialize(string name, char type)
    {
        cardName = name;
        cardType = type;
    }

    // Start is called before the first frame update
    void Start()
    {
        cardText.text = cardName;
        SetVisibility(false);
        isDragging = false;
        overQuestDropZone = false;
        overMiscDropZone = false;
        //Debug.Log(cardName);
    }

    // Update is called once per frame
    void Update()
    {
        // Only cards in a hand should be able to be dragged and dropped
        if (transform.parent.CompareTag("HandPanel"))
        {
            if (isDragging)
            {
                //Debug.Log("Currently dragging");
                transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
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
    }

    // Drag and Drop functions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("QuestPanel"))
        {
            overQuestDropZone = true;
        }
        else if (collision.gameObject.CompareTag("MiscDropZone"))
        {
            overMiscDropZone = true;
        }
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        overQuestDropZone = false;
        overMiscDropZone = false;
        dropZone = null;
    }

    // Begin dragging
    public void StartDrag()
    {
        // Record initial position
        startPosition = transform.position;
        isDragging = true;
        // Open the relevant quest panel for dragging and dropping
        ShadowsOverCamelot.Instance.currentKnight.currentQuest.SetVisibility(true);
        ShadowsOverCamelot.Instance.currentKnight.currentQuest.dz.SetVisibility(true);
    }

    // Drop the currently dragged card
    public void EndDrag()
    {
        isDragging = false;
        // If the white card is being used for a quest
        if (overQuestDropZone)
        {
            if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Camelot"))
            {
                // Card is being dropped on Camelot quest

                // Card being played needs to be a fight card
                if (cardName.Equals("Fight1") || cardName.Equals("Fight2") || cardName.Equals("Fight3") || cardName.Equals("Fight4") || cardName.Equals("Fight5"))
                {
                    // Remove this card from the player's hand
                    ShadowsOverCamelot.Instance.currentKnight.hand.hand.Remove(this);

                    // Add this card to the quest's drop zone
                    ShadowsOverCamelot.Instance.camelotQuest.dz.playersChoice.Add(this);
                    ShadowsOverCamelot.Instance.camelotQuest.dz.cancelButton.gameObject.SetActive(true);
                    ShadowsOverCamelot.Instance.camelotQuest.dz.confirmButton.gameObject.SetActive(true);
                    transform.SetParent(dropZone.transform, false);

                    // Only enable button for fighting siege engines when siege engines exist
                    if (ShadowsOverCamelot.Instance.siegeEngineCounter.engines == 0)
                    {
                        ShadowsOverCamelot.Instance.camelotQuest.dz.confirmButton.interactable = false;
                    }
                    else
                    {
                        ShadowsOverCamelot.Instance.camelotQuest.dz.confirmButton.interactable = true;
                    }
                }
                // Invalid card type being played
                else
                {
                    transform.position = startPosition;
                    if (ShadowsOverCamelot.Instance.camelotQuest.dz.playersChoice.Count == 0)
                    {
                        ShadowsOverCamelot.Instance.camelotQuest.dz.SetVisibility(false);
                    }
                }
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Picts"))
            {
                // Card is being dropped on Picts quest

                // Only one card can be played at a time
                if (ShadowsOverCamelot.Instance.pictsQuest.dz.playersChoice.Count == 0)
                {
                    List<Card> cardsPlayed = ShadowsOverCamelot.Instance.pictsQuest.cardsPlayed;

                    // Cards must be played in an ascending straight
                    if (cardsPlayed.Count == 0)
                    {
                        if (cardName.Equals("Fight1"))
                        {
                            // Remove this card from the player's hand
                            ShadowsOverCamelot.Instance.currentKnight.hand.hand.Remove(this);

                            // Add this card to the quest's drop zone
                            ShadowsOverCamelot.Instance.pictsQuest.dz.playersChoice.Add(this);
                            ShadowsOverCamelot.Instance.pictsQuest.dz.cancelButton.gameObject.SetActive(true);
                            ShadowsOverCamelot.Instance.pictsQuest.dz.confirmButton.gameObject.SetActive(true);
                            transform.SetParent(dropZone.transform, false);
                        }
                        // Invalid card being played
                        else
                        {
                            transform.position = startPosition;
                            ShadowsOverCamelot.Instance.pictsQuest.dz.SetVisibility(false);
                        }
                    }
                    else if (cardsPlayed.Count > 0) 
                    {
                        if ((cardsPlayed[cardsPlayed.Count - 1].cardName.Equals("Fight1") && cardName.Equals("Fight2"))
                            || (cardsPlayed[cardsPlayed.Count - 1].cardName.Equals("Fight2") && cardName.Equals("Fight3"))
                            || (cardsPlayed[cardsPlayed.Count - 1].cardName.Equals("Fight3") && cardName.Equals("Fight4"))
                            || (cardsPlayed[cardsPlayed.Count - 1].cardName.Equals("Fight4") && cardName.Equals("Fight5"))
                            || (ShadowsOverCamelot.Instance.pictsQuest.mordredActive && cardsPlayed[cardsPlayed.Count - 1].cardName.Equals("Fight5") && cardName.Equals("Fight5")))
                        {
                            // Remove this card from the player's hand
                            ShadowsOverCamelot.Instance.currentKnight.hand.hand.Remove(this);

                            // Add this card to the quest's drop zone
                            ShadowsOverCamelot.Instance.pictsQuest.dz.playersChoice.Add(this);
                            ShadowsOverCamelot.Instance.pictsQuest.dz.cancelButton.gameObject.SetActive(true);
                            ShadowsOverCamelot.Instance.pictsQuest.dz.confirmButton.gameObject.SetActive(true);
                            transform.SetParent(dropZone.transform, false);
                        }
                        // Invalid card being played
                        else
                        {
                            transform.position = startPosition;
                            ShadowsOverCamelot.Instance.pictsQuest.dz.SetVisibility(false);
                        }
                    }
                   
                }
                // Player has already placed a card in the drop zone
                else
                {
                    transform.position = startPosition;
                }
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Saxons"))
            {
                // Card is being dropped on Saxons quest
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("BlackKnight"))
            {
                // Card is being dropped on Black Knight quest
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Excalibur"))
            {
                // Card is being dropped on Excalibur quest
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Grail"))
            {
                // Card is being dropped on Grail quest
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Lancelot"))
            {
                // Card is being dropped on Lancelot quest
            }
            else if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.questName.Equals("Dragon"))
            {
                // Card is being dropped on Dragon quest
            }
            
        }
        // If the white card is being used for something else
        else if (overMiscDropZone)
        {

        }
        // White card is not over any drop zone
        else
        {
            transform.position = startPosition;
            if (ShadowsOverCamelot.Instance.currentKnight.currentQuest.dz.playersChoice.Count == 0)
            {
                ShadowsOverCamelot.Instance.currentKnight.currentQuest.dz.SetVisibility(false);
            }   
        }
    }
}
