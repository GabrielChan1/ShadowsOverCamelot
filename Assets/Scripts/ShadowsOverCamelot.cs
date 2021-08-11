using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowsOverCamelot : MonoBehaviour
{
    public static ShadowsOverCamelot Instance { get; private set; }

    // Variables created here are meant to be globally accessible
    public Knight currentKnight;        // Reference to the current Knight. Needed for awarding relics
    [HideInInspector] public bool heroismActive;      // Flag determining whether the Heroism card is active
    [HideInInspector] public bool vivienActive;       // Flag determining whether the Vivien card is active
    [HideInInspector] public bool mistsOfAvalon;      // Flag determining whether the Mists of Avalon card is active

    // References to Quests
    public Camelot camelotQuest;
    public WarQuest pictsQuest;
    public WarQuest saxonsQuest;
    public Quest blackKnightQuest;
    public Quest excaliburQuest;
    public Quest lancelotDragonQuest;
    public Quest grailQuest;

    // References to Knights
    public Knight arthur;
    public Knight galahad;
    public Knight gawain;
    public Knight kay;
    public Knight palamedes;
    public Knight percival;
    public Knight tristan;
                      
    public SwordCounter swordCounter;       // Reference to the sword counter
    public SiegeEngineCounter siegeEngineCounter;       // Reference to the siege engine counter

    // Singleton implementation;
    void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        heroismActive = false;
        vivienActive = false;
        mistsOfAvalon = false;

        /*
        GameObject[] quests = GameObject.FindGameObjectsWithTag("QuestPanel");
        foreach (GameObject q in quests)
        {
            Debug.Log(q.name);
        }
        */
        //Debug.Log(1);
        //Debug.Log(camelotQuest.questName);
    }

    // Update is called once per frame
    void Update()
    {
        if (siegeEngineCounter.twelveEngines)
        {
            // Game ends and forces of Evil wins
        }
        if (swordCounter.sevenBlack)
        {
            // Game ends and forces of Evil wins
        }
        if (swordCounter.twelveTotal)
        {
            if (swordCounter.majorityWhite)
            {
                // Game ends and knights of Camelot wins
            }
            else
            {
                // Game ends and forces of Evil wins
            }
        }
    }

    // Return all the quests in a list
    public List<Quest> AllQuests()
    {
        List<Quest> quests = new List<Quest>();
        quests.Add(camelotQuest);
        quests.Add(pictsQuest);
        quests.Add(saxonsQuest);
        quests.Add(blackKnightQuest);
        quests.Add(excaliburQuest);
        quests.Add(grailQuest);
        quests.Add(lancelotDragonQuest);
        return quests;
    }

    // Return all the knights in a list
    public List<Knight> AllKnights()
    {
        List<Knight> knights = new List<Knight>();
        knights.Add(arthur);
        knights.Add(galahad);
        knights.Add(gawain);
        knights.Add(kay);
        knights.Add(palamedes);
        knights.Add(percival);
        knights.Add(tristan);
        return knights;
    }
}
