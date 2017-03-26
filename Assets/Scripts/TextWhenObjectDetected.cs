using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using Vuforia;
using System.Drawing;
using UnityEngine.UI;
using System.Text;
//[RequireComponent(typeof(AudioSource))]
public class TextWhenObjectDetected : MonoBehaviour, ITrackableEventHandler
{

    

    private TrackableBehaviour mTrackableBehaviour;
    private bool mShowGUIButton = false;
    private Rect mButtonRect = new Rect();
    private string myText = "";
    private string trackableName;
    private Boolean showText = false;
    string htmlString = "";
    string monumentText = ""; 
    int count = 0;
    StringBuilder htmlBuilder = new StringBuilder();
    // [SerializeField]
    // private string buttonText;
    [SerializeField]
    private Texture buttonTexture;
    [SerializeField]
    public GUIStyle _myButtonStyle;
    public GUIStyle _myTextStyle;
    








    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowGUIButton = true;
        }
        else
        {
            mShowGUIButton = false;
        }
    }

    // Use this for initialization
    void Start () {

        //GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "ya rab yeshtaghal");
        //  GameObject newGO = new GameObject("ClickableText");
        //newGO.transform.SetParent(this.transform);
        AddTextToCanvas( "TESSTT TESSST", new GameObject("ClickableText"));
        //Text myText = newGO.AddComponent<Text>();
        //myText.text = "Ta-dah!";
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }



    }


    public static Text AddTextToCanvas(string textString, GameObject canvasGameObject)
    {
        Text text = canvasGameObject.AddComponent<Text>();
        text.text = textString;

        UnityEngine.Font ArialFont = (UnityEngine.Font)Resources.GetBuiltinResource(typeof(UnityEngine.Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        return text;
    }

    // Update is called once per frame
    void Update () {

        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        Debug.Log("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            trackableName = tb.TrackableName;
            Debug.Log("Trackable name is : " + tb.TrackableName);
        }

    }


    // IEnumerator DisplayTime()
    //{
    //    Debug.Log("Destroyed0");
    //    yield return new WaitForSeconds(time);
    //    Destroy(gameObject);
    //    Debug.Log("Destroyed");
    //}

    void OnGUI()
    {
        if (mShowGUIButton)
        {
            // draw the GUI button

            Brush brush = new SolidBrush(System.Drawing.Color.Red);
            mButtonRect.height = 45;
            mButtonRect.width = 100;
            mButtonRect.x = Screen.width / 2;
            mButtonRect.y = Screen.height / 2;
            GUI.Label(new Rect(Screen.width/3, Screen.height/3, 50,50),"HELLLOOOOOOOOOOOO");
            // Debug.Log("int enter here" + count++ );
            if (GUI.Button(new Rect(80, 80, 270, 150), new GUIContent("Display History of " + Environment.NewLine + trackableName, "")))
            {
                
                showText = true;      
                mShowGUIButton = false;  
                Debug.Log("button clicked");
            }
 
        }
        else if (showText)
             {
                monumentText = "This is forno" + Environment.NewLine+ "forno is healthy" + Environment.NewLine + "Eat forno";
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), monumentText);
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            //DisplayTime();
            Debug.Log("displaytimecalled");
            }   
            GUI.skin.label = _myTextStyle;
            GUI.skin.button = _myButtonStyle;
    }
    public float time = 5; //Seconds to read the text

    
    void DrawQuad(Rect position, UnityEngine.Color color)
    {
        Debug.Log("i entered here");
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        GUI.contentColor = UnityEngine.Color.black;
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(position, GUIContent.none);


    }
    string ConvertDataTableToHtml()
    {
        htmlBuilder.Append("<html>");
        htmlBuilder.Append("<br>");
        htmlBuilder.Append(trackableName);
        htmlBuilder.Append("</br>");
        htmlBuilder.Append("</html>");
        htmlString = htmlBuilder.ToString();
        Debug.Log(Environment.NewLine);
        return "";
    }
   

}

