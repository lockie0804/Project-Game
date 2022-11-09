using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoiceApproval : OneChoice
{
    [Header("How much the NPC likes us")]
    public int approval;
    [Header("The Dialogue based on approval")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void ChangeDlg(int approval)
    {
        switch (approval)
        {
            case -1:
                dialogue = dislikeText;
                break;
            case 0:
                dialogue = neutralText;
                break;
            case 1:
                dialogue = likeText;
                break;
        }
    }
    void Start()
    {
        //set dialogue and values to neutral
        approval = 0;
        ChangeDlg(approval);
    }
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDlg)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen
            /*...this box also displays the NPC name and current line of dialogue*/
            GUI.Box(new Rect(0, 6 * UIManager.scr.y, Screen.width, 3 * UIManager.scr.y), $"{charName}: {dialogue[index]}");
            //if we are not yet at the end of dialogue and we are not the choice index
            if (index < dialogue.Length - 1 && index != choiceIndex)
            {
                //display a button that says next in the bottom right area somewhere of the screen and if its pressed...then
                if (GUI.Button(new Rect(13.5f * UIManager.scr.x, 8.25f * UIManager.scr.y, 2.5f * UIManager.scr.x, 0.75f * UIManager.scr.y), "Next"))
                {
                    //increase index by 1
                    index++;
                }
            }
            //otherwise if we are the choice
            else if (index == choiceIndex)
            {
                //if yes
                if (GUI.Button(new Rect(11f * UIManager.scr.x, 8.25f * UIManager.scr.y, 2.5f * UIManager.scr.x, 0.75f * UIManager.scr.y), "Yes"))
                {
                    //increase index by 1
                    index++;
                    if (approval < 1)
                    {
                        approval++;
                    }
                    ChangeDlg(approval);
                }
                //if no
                if (GUI.Button(new Rect(13.5f * UIManager.scr.x, 8.25f * UIManager.scr.y, 2.5f * UIManager.scr.x, 0.75f * UIManager.scr.y), "No"))
                {
                    //increase index by 1
                    index = dialogue.Length - 1;
                    if (approval > -1)
                    {
                        approval--;
                    }
                    ChangeDlg(approval);
                }
            }
            //else we are on the last line of dialogue
            else
            {
                //display bye button where next was and if triggered 
                if (GUI.Button(new Rect(13.5f * UIManager.scr.x, 8.25f * UIManager.scr.y, 2.5f * UIManager.scr.x, 0.75f * UIManager.scr.y), "Bye."))
                {
                    //run parent End DLG code
                    EndDialogue();
                }
            }
        }
    }
}
