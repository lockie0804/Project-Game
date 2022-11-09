using System.Collections;//Allows Arrays
using System.Collections.Generic;//Allows Dictionaries or Lists
using UnityEngine.UI;//Allows us to edit UI elements
using UnityEngine;//Allows us to connect to Unity
using System;//allows us to serialise and convert

public class KeybindManager : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, KeyCode> keyInputs = new Dictionary<string, KeyCode>();
    [Serializable]
    public struct KeybindUI
    {
        public string inputName;
        public Text labelComponent;
        public Text keyDisplayComponent;
        public string keyDisplayValue;
        public string keyDefaultValue;
    }
    public KeybindUI[] inputKeys;

    public GameObject keyPrefab;
    public GameObject keyContainer;
    private GameObject _currentInput;

    public Color32 selectedColour = new Color32(239, 116, 36, 255);
    public Color32 changedColour = new Color32(39, 171, 249, 255);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            if (i > 0)
            {
                GameObject clone = Instantiate(keyPrefab, keyContainer.transform);
                inputKeys[i].labelComponent = clone.GetComponent<Text>();
                Text[] compsInChild = clone.GetComponentsInChildren<Text>();
                inputKeys[i].keyDisplayComponent = compsInChild[1];
                clone.GetComponentInChildren<Button>().name = inputKeys[i].inputName;
            }
            inputKeys[i].labelComponent.text = inputKeys[i].inputName;
            inputKeys[i].keyDisplayComponent.text = inputKeys[i].keyDefaultValue;
            keyInputs.Add(inputKeys[i].inputName, (KeyCode)Enum.Parse(typeof(KeyCode), inputKeys[i].keyDefaultValue));
        }
        foreach (var item in keyInputs)
        {
            Debug.Log(item.Key + " + " + item.Value);
        }
    }
    public void ChangeKey(GameObject clickedButton)
    {
        _currentInput = clickedButton;
        if (clickedButton != null)//if we have clicked a keybind button and its regestered that its selected
        {
            _currentInput.GetComponent<Image>().color = selectedColour;
            //change the colour to show the user that it is selected
        }
    }
    //allows us to run events
    void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;
        if (_currentInput != null)
        {
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }
            if (newKey != "")//if we have set a key
            {
                keyInputs[_currentInput.name] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey);
                _currentInput.GetComponentInChildren<Text>().text = newKey;
                _currentInput.GetComponent<Image>().color = changedColour;
                _currentInput = null;
                return;
            }
        }
    }
}
