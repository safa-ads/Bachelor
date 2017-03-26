using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class LayoutWithCnvas : MonoBehaviour, ITrackableEventHandler
{

    public GameObject panel;
    public Text title;
    public Text info;
    public Button close_btn;
    public Button discover_btn;
    //public UnityEngine.UI.Image statue_img;
    private bool isShowing = false;
    private bool mShowGUIButton = false;
    private TrackableBehaviour mTrackableBehaviour;
    private string trackableName;
 
    void Start()
    {

        Button btn = close_btn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick_close);
        Button btn1 = discover_btn.GetComponent<Button>();
        btn1.onClick.AddListener(OnClick_discover);
        discover_btn.gameObject.SetActive(false);
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);


        }
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {


        StateManager sm = TrackerManager.Instance.GetStateManager();

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
            discover_btn.gameObject.SetActive(false);
            OnTrackingLost();
        }
    }

    void OnClick_close()
    {
        panel.SetActive(false);
        
    }
    void OnClick_discover()
    {
        discover_btn.gameObject.SetActive(false);
        mShowGUIButton = false;
        isShowing = true;
        infoDiaplayed();
        panel.SetActive(isShowing);
    }
    void infoDiaplayed()
    {
        if (trackableName == "Iwnatfarside1" || trackableName == "Iwnitfar" || trackableName == "Iwnatfarside2" || trackableName == "Iwnatnearside2"
            || trackableName == "Iwnatnearside1" || trackableName == "Iwnatnear" || trackableName == "Iwnatnearside3" || trackableName == "Iwnatfarside3" ||
             trackableName == "Iwnatfarside4" || trackableName == "Iwantnearside5" || trackableName == "Iwantside6" || trackableName == "Iwantside7"
             || trackableName == "Iwantside8")
        {
            // MonumentInfo = "Iwnit was in the regin of Amenhotop III, it is an egyptain land mark.";
            title.text = "Amenhotop III";
            info.text = "Amenhotep III, also known as Amenhotep the Magnificent, was the ninth pharaoh of the Eighteenth Dynasty. According to different authors, he ruled Egypt from June 1386 to 1349 BC, or from June 1388 BC to December 1351 BC/1350 BC was the ninth pharaoh of the Eighteenth Dynasty ";
           // statue_img.sprite = Resources.Load<Sprite>("E:\Bachelor\Unity projects\Luxor\Assets\Textures\texture1.png");
            
            // monumentName = "Display history of" + Environment.NewLine + "Iwnit";
        }
        if (trackableName == "horhob1" || trackableName == "horhob2" || trackableName == "horhob3")
        {
           // MonumentInfo = "oremheb was the last pharaoh of Egyptian family of eighteen in Egypt 's history of the old, and it was the Pharaoh of Egypt from 1308 to late 1338 BC in the era of the modern state.The full meaning of his name Horemheb Mary Amon ";
           // monumentName = "Display history of" + Environment.NewLine + "Horemheb";
        }
        if (trackableName == "amnhotob3-1" || trackableName == "amonhotob3-2" || trackableName == "amonhotob3-3" || trackableName == "amonhotob3-5" ||
            trackableName == "amnhotob3-6" || trackableName == "amnhotob3-7")
        {
           // MonumentInfo = "Amenhotep III, also known as Amenhotep the Magnificent, was the ninth pharaoh of the Eighteenth Dynasty. According to different authors, he ruled Egypt from June 1386 to 1349 BC, or from June 1388 BC to December 1351 BC/1350 BC,after his father Thutmose IV died.";
           // monumentName = "Display history of" + Environment.NewLine + "Amenhotob III";
        }
        if (trackableName == "ramses1" || trackableName == "ramses2" || trackableName == "ramses3" || trackableName == "ramses4")
        {
           // MonumentInfo = "Throughout his life, Ramses II went on to build various monuments and thus his legacy of being a builder in Ancient Egypt and Nubia was born. Ramses II constructed monuments such as Abu Simbel, the mortuary temple Ramesseum, Pi-Ramesses in the Delta,";
            //monumentName = "Display history of" + Environment.NewLine + "Ramses II";
        }
        if (trackableName == "hormohb1" || trackableName == "hormohb2" || trackableName == "hormohb3" || trackableName == "hormohb4" || trackableName == "hormohb5")
        {
           // MonumentInfo = "oremheb was the last pharaoh of Egyptian family of eighteen in Egypt 's history of the old, and it was the Pharaoh of Egypt from 1308 to late 1338 BC in the era of the modern state.The full meaning of his name Horemheb Mary Amon ";
           // monumentName = "Display history of" + Environment.NewLine + "Hormohb";
        }
        if (trackableName == "hathor1" || trackableName == "hathor2" || trackableName == "hathor3")
        {
            //MonumentInfo = "is an Ancient Egyptian goddess who personified the principles of joy, feminine love, and motherhood. She was one of the most important and popular deities throughout the history of Ancient Egypt.Hathor was worshipped by royalty and common people alike.";
          //  monumentName = "Display history of" + Environment.NewLine + "Hathor";
        }
        if (trackableName == "hall1" || trackableName == "hall2" || trackableName == "hathor3")
        {
           // MonumentInfo = "Discover AL-KHABYA with our augmented reality Application" + Environment.NewLine + "We hope you enjoy your time";
           // monumentName = "Welcome to" + Environment.NewLine + "AL-KHABAYA";
        }


    }

    void OnGUI()
    {


        if (mShowGUIButton)
        {
            //MonumentText.text = trackableName;
            
            discover_btn.gameObject.SetActive(true);
            discover_btn.GetComponentInChildren<Text>().text = "AmenhotopIII";
          
        }
   
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

     
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

    }
}

