using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Game Systems/NPC/Dialogue/Linear")]
public class LinearDlg : DialogueManager
{
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDlg)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen
            /*...this box also displays the NPC name and current line of dialogue*/
            GUI.Box(new Rect(0, 6 * UIManager.scr.y, Screen.width, 3 * UIManager.scr.y),$"{charName}: {dialogue[index]}");
            //if we are not yet at the end of dialogue
            if (index < dialogue.Length-1)
            {
                //display a button that says next in the bottom right area somewhere of the screen and if its pressed...then
                if (GUI.Button(new Rect(13.5f*UIManager.scr.x, 8.25f*UIManager.scr.y, 2.5f *UIManager.scr.x, 0.75f * UIManager.scr.y),"Next"))
                {
                    //increase index by 1
                    index++;
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
