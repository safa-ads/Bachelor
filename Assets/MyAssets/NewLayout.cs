using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class NewLayout : MonoBehaviour, ITrackableEventHandler
{

    private bool mShowGUIButton = false;
    private bool showText = false;
    private TrackableBehaviour mTrackableBehaviour;
    private string trackableName;
    private string MonumentInfo;
    public Text MonumentText;
    public Texture monumentTexture;
    public GUIStyle _myButtonStyle;
    public GUIStyle _myTextStyle;
    //public Transform target;
    //Camera camera;

    // Use this for initialization
    void Start()
    {

        // camera = GetComponent<Camera>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);


        }

    }

    // Update is called once per frame
    void Update()
    {

        //if(camera != null){
        //    Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        //    Debug.Log("target is " + screenPos.x + " pixels from the left");
        //    Debug.Log("HERE OR WHAT");

        //}


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
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowGUIButton = true;
            Debug.Log("Detected");
            OnTrackingFound();


        }
        else
        {
            mShowGUIButton = false;
            OnTrackingLost();
        }
    }

    string infoDiaplayed()
    {
        if (trackableName == "A3farside2_2")
            MonumentInfo = "forno is healthy";
        else if (trackableName == "A3farside2_1")
            MonumentInfo = "this is orange back";
        else if (trackableName == "A3farside1_2")
            MonumentInfo = "this is orange back shadow";
        else if (trackableName == "A3farside1_1")
            MonumentInfo = "this is orange front";
        else if (trackableName == "A3side2_2")
            MonumentInfo = "this is orange side 1";
        else if (trackableName == "A3side2_1")
            MonumentInfo = "this is orange side 2";
        else if (trackableName == "A3side2")
            MonumentInfo = "this is back 2";
        else if (trackableName == "A3side1_2")
            MonumentInfo = "this is orange back 3";
        else if (trackableName == "Biscuits")
            MonumentInfo = Environment.NewLine + "Biscuit is a term used for a diverse variety of baked, commonly flour-based food products, The North American biscuit is typically a soft one    ";
        else if (trackableName == "Amenhotop3")
            MonumentInfo = "this is Amenhotop 3";
        else if (trackableName == "Amenhotop_3")
            MonumentInfo = "this is Amenhotop 3";
        else if (trackableName == "A3farNoflash")
            MonumentInfo = "this is Amenhotop 3";
        // MonumentInfo = Environment.NewLine +   "This is amenhotop "+ Environment.NewLine + "Egyptian mark";
        return MonumentInfo;
    }

    void OnGUI()
    {


        if (mShowGUIButton)
        {
            // draw the GUI button


            //MonumentText.text = trackableName;


            //GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 270, 150), TextTexture, ScaleMode.StretchToFill, true);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), new GUIContent(trackableName)))
            {

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                mShowGUIButton = false;
                showText = true;

            }
            GUI.skin.button = _myButtonStyle;
        }
        else if (showText)
        {

            //MonumentInfo = "daughter of King Thutmose I, Hatshepsut became queen of Egypt when she married her half - brother, Thutmose II, around the age of 12.";
            // GUI.Label(new Rect( Screen.width/2 -120, Screen.height/2-100 , 250,250), new GUIContent(infoDiaplayed()));
            // new GUIContent(trackableName)
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 250, 250), "hi" + MonumentText.text);
            GUI.DrawTexture(new Rect(Screen.width / 2 - 110, Screen.height / 2 - 70, 75, 75), monumentTexture, ScaleMode.StretchToFill, true);
            // MonumentText.text = trackableName;
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 70, 100, 50), new GUIContent("back")))
            {
                showText = false;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Pause();
            }

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            //DisplayTime();

        }
        GUI.skin.label.wordWrap = true;
        GUI.skin.label = _myTextStyle;
        //   GUI.skin.button = _myButtonStyle;
    }

    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        Debug.Log("Trackable hereee" + mTrackableBehaviour.TrackableName + " found");

        // Optionally play the video automatically when the target is found


    }
    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        /*
        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        */
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

    }
}

