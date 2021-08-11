using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropZone : MonoBehaviour
{
    [SerializeField] private Quest quest;       // Reference to this drop zone's quest
    [HideInInspector] public List<Card> playersChoice;      // Card(s) players put into the drop zone
    public Button cancelButton;     // Reference to the cancel button
    public Button confirmButton;    // Reference to the confirm button

    [SerializeField] private BoxCollider2D bc;      // Component for managing the quest's drop zone
    [SerializeField] private CanvasGroup cg;        // Component for making the panel visible or invisible to the player

    // Start is called before the first frame update
    void Start()
    {
        playersChoice = new List<Card>();
        cancelButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
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
        bc.enabled = setting;
    }
}
