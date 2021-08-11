using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public void CamelotOnClick()
    {
        // Only one quest panel should be open at a time
        if (ShadowsOverCamelot.Instance.pictsQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.pictsQuest.SetVisibility(false);
        }
        /*
        if (ShadowsOverCamelot.Instance.saxonsQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.saxonsQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.blackKnightQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.blackKnightQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.excaliburQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.excaliburQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.grailQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.grailQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.lancelotDragonQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.lancelotDragonQuest.SetVisibility(false);
        }
        */

        // If the quest panel matching the button is already open, close it
        if (ShadowsOverCamelot.Instance.camelotQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.camelotQuest.SetVisibility(false);
        }
        else
        {
            ShadowsOverCamelot.Instance.camelotQuest.SetVisibility(true);
        }
        
    }

    public void PictsOnClick()
    {
        // Only one quest panel should be open at a time
        if (ShadowsOverCamelot.Instance.camelotQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.camelotQuest.SetVisibility(false);
        }
        /*
        if (ShadowsOverCamelot.Instance.saxonsQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.saxonsQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.blackKnightQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.blackKnightQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.excaliburQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.excaliburQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.grailQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.grailQuest.SetVisibility(false);
        }
        if (ShadowsOverCamelot.Instance.lancelotDragonQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.lancelotDragonQuest.SetVisibility(false);
        }
        */

        // If the quest panel matching the button is already open, close it
        if (ShadowsOverCamelot.Instance.pictsQuest.isVisible)
        {
            ShadowsOverCamelot.Instance.pictsQuest.SetVisibility(false);
        }
        else
        {
            ShadowsOverCamelot.Instance.pictsQuest.SetVisibility(true);
        }
    }

    public void SaxonsOnClick()
    {

    }

    public void BlackKnightOnClick()
    {

    }

    public void ExcaliburOnClick()
    {

    }

    public void GrailOnClick()
    {

    }

    public void LancelotDragonOnClick()
    {

    }
}
