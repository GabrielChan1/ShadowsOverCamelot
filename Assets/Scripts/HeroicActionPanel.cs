using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroicActionPanel : MonoBehaviour
{
    [SerializeField] private MovementPanel mp;      // Reference to the movement panel

    // Open the movement panel when the move button is pressed
    public void StartMovement()
    {
        mp.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
