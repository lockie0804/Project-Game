using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //ref to out screens x and y divided by our aspect ratio
    public static Vector2 scr;

    //Singleton 
    private static UIManager _uiManagerInstance;
    public static UIManager UIManagerInstance
    {
        //See, Read, Look at
        get { return _uiManagerInstance; }
        // get => _uiManagerInstance;
        //Change, Write, Adjust
        private set
        {
            //if there is no reference
            if (_uiManagerInstance == null)
            {
                //set our reference to this instance
                _uiManagerInstance = value;
            }
            //else if instance is not the same instance as the value
            else if (_uiManagerInstance != value)
            {
                //Debug
                Debug.Log($"{nameof(UIManager)} instance already exists, destroy the duplicate! THERE CAN BE ONLY ONE!!!");
                //MURDER KILL DESTROY THE IMPOSTER
                Destroy(value);
            }
        }
    }
    public void UpdateUIScale()
    {
        if (new Vector2(Screen.width/16,Screen.height/9) != scr)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
    }
    private void Awake()
    {
        UIManagerInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUIScale();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIScale();
    }
}
