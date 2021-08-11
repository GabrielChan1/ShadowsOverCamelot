using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiegeEngineCounter : MonoBehaviour
{
    public int engines { get; private set; }     // Number of siege engines placed
    public bool twelveEngines { get; private set; }     // Flag determining if there are 12 or more siege engines placed

    [SerializeField] private Text counter;    // UI component displaying the number of siege engines placed

    // Start is called before the first frame update
    void Start()
    {
        engines = 0;
        twelveEngines = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "SE: " + engines.ToString() + "/12";
        if (engines >= 12)
        {
            twelveEngines = true;
        }
    }

    public void AddSiegeEngines(int n)
    {
        engines += n;
    }

    public void RemoveSiegeEngines(int n)
    {
        engines -= n;
    }
}
