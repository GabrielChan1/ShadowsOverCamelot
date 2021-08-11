using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPanel : MonoBehaviour
{
    [SerializeField] private HeroicActionPanel hap;     // Reference to the heroic action panel

    // References to buttons for moving to quests
    [SerializeField] private Button camelotButton;
    [SerializeField] private Button pictsButton;
    [SerializeField] private Button saxonsButton;
    [SerializeField] private Button blackKnightButton;
    [SerializeField] private Button excaliburButton;
    [SerializeField] private Button grailButton;
    [SerializeField] private Button lancelotDragonButton;

    // Start is called before the first frame update
    void Start()
    {
        // The movement panel should only open when the move button is pressed
        gameObject.SetActive(false);

        saxonsButton.interactable = false;
        blackKnightButton.interactable = false;
        excaliburButton.interactable = false;
        grailButton.interactable = false;
        lancelotDragonButton.interactable = false;
    }

    // Functions for moving Knights to the specified quest
    public void MoveToCamelot()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.camelotQuest);
    }

    public void MoveToPicts()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.pictsQuest);
    }

    public void MoveToSaxons()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.saxonsQuest);
    }

    public void MoveToBlackKnight()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.blackKnightQuest);
    }

    public void MoveToExcalibur()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.excaliburQuest);
    }

    public void MoveToGrail()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.grailQuest);
    }

    public void MoveToLancelotDragon()
    {
        ShadowsOverCamelot.Instance.currentKnight.Move(ShadowsOverCamelot.Instance.lancelotDragonQuest);
    }

    // Cancel movement and return to the previous panel
    public void CancelMovement()
    {
        hap.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
