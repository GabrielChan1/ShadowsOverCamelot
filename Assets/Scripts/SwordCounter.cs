using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCounter : MonoBehaviour
{
    private int whiteSwords;     // Number of white swords
    private int blackSwords;     // Number of black swords
    public bool sevenBlack { get; private set; }     // Flag determining whether there are 7 or more black swords placed
    public bool twelveTotal { get; private set; }       // Flag determining whether there are 12 or more swords placed
    public bool majorityWhite { get; private set; }       // Flag determining whether the majority of at least 12 swords are white

    [SerializeField] private Text counter;        // UI component displaying the number of swords placed

    // Start is called before the first frame update
    void Start()
    {
        whiteSwords = 0;
        blackSwords = 0;
        sevenBlack = false;
        twelveTotal = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "W: " + whiteSwords.ToString() + "  B: " + blackSwords.ToString() + "/7  T: " + (whiteSwords + blackSwords).ToString() + "/12";

        if (blackSwords >= 7)
        {
            sevenBlack = true;
        }
        if (whiteSwords + blackSwords >= 12)
        {
            twelveTotal = true;
            if (whiteSwords > blackSwords)
            {
                majorityWhite = true;
            }
            else
            {
                majorityWhite = false;
            }
        }
    }

    public void AddSwords(char type, int n)
    {
        // If adding white swords
        if (type.Equals('W'))
        {
            whiteSwords += n;
        }
        // If adding black swords
        else if (type.Equals('B'))
        {
            blackSwords += n;
        }
    }
}
