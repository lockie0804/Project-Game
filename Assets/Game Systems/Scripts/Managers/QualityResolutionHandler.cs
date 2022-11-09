using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QualityResolutionHandler : MonoBehaviour
{
    #region Quality
    //public so that we can attach it to the dropdown UI as an event
    //int qualityIndex is used coz the dropdown is an array and we want the element value from it
    public void Quality(int qualityIndex)
    {
        //Quality settings allow us to set the quality level to the dropdowns element
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    #endregion
    #region Fullscreen
    public Toggle fullscreenToggle;

    //the toggle is a bool value known as isOn
    public void SetFullscreen(bool isFullscreen)
    {
        //Screen has a full screen bool inbuilt that handles windowed vs fullscreen
        //we send the toggle value to the screens bool to change the value
        Screen.fullScreen = isFullscreen;
    }
    #endregion
    #region Resolution
    public Resolution[] resolutions;
    public Dropdown resDropdown;
    void ResSetup()
    {
        //hold onto all resolutions our screen supports
        resolutions = Screen.resolutions;
        //clear all options out of the resolution dropdown so that we can set our own
        resDropdown.ClearOptions();
        //create a dynamic container that changes size during runtime
        List<string> options = new List<string>();
        //current index value for current resolution
        int curResIndex = 0;
        //loop through the resolutions and format them then add them to the container of strings so we can display them on the dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            //formatting the string
            string option = resolutions[i].width + " x " + resolutions[i].height;
            //adding the string to our list
            options.Add(option);
            if (Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
            {
                curResIndex = i;
            }
        }
        //set the dropdown option list to the list of options
        resDropdown.AddOptions(options);
        //the current resolution is displayed on the dropdown
        resDropdown.value = curResIndex;
        //refresh to make sure changes apply
        resDropdown.RefreshShownValue();
    }
    //public function to be connected to the dropdown and use the dynamic value
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        //Set the screens resolution to the resolution selected and current fullscren/windowed value
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }
    #endregion
    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        ResSetup();
    }
}
