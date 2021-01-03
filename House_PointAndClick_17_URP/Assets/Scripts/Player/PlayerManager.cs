using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    public PlayerPrefsData prefsData { get; private set; }
    
    public GameObject allCanvas;
    public Camera cam;
    public DoubleClick doubleClick;

    public TimelineController timelineController;
    public PlayableDirector playableDirector;
    //public TimelineAsset[] timelineAsset;
    //TimelineAsset timeline;
    //public CondicionsSave escalesCondicio;

    public CanvasGroup inventoryCanvasGroup;
    private AudioSource playerSource;
    public AudioSource grills;
    public AudioSource piano;
    public AudioSource esbufec;
    public AudioSource campanes;
    private GameObject gObj = null;
    private Plane objPlane;
    private Vector3 mouseOffset;

    public int index = 0;

   // private TargetGObj targetGObj;

    PlayerRotation playerRotation;
    Transform targetPlace;
   
    DestinationPlace place;
    BackPlace backPlace;

    Transform newTransform;
    string targetName;
    string goBackTag;
    float previousTouchDistance;
    float deltaDistance;

    private float deltaX = 0f;
    private float deltaY = 0f;
    private Touch initTouch = new Touch();
    float posX;
    Vector3 position;
    bool on;
    bool back;

    bool moveEnded;
    string locationName;
    bool enable;
    private bool prefsDelete;


    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        moveEnded = true;
        playerSource = GetComponent<AudioSource>();
        
    }
    
    private void OnEnable()
    {
        playerRotation = GetComponent<PlayerRotation>();

        prefsData = PlayerPrefsPersistentData.LoadData();

        locationName = prefsData.LocationName;
        index = prefsData.index;

        Debug.Log("index " + index);

        //Debug.Log("locationName " + locationName);
        if (locationName == "StartPosition" || locationName == "Porta" || locationName == "TimbreEntrada")
        {
            grills.Play();
            
        }
        else
        {
            grills.loop = false;
            grills.Stop();
        }

        if(locationName == "Sacerdotessa" || locationName == "GerroGroc")
        {
            piano.Play();
        }

        if (index == 1)
        {
            //timeline = timelineAsset[2];
            //playableDirector.Play(timeline);
            timelineController.PlayFromTimelines(2);

        }
    }

    private void OnDisable()
    {
        PlayerPrefsPersistentData.SaveData(this);
        if (prefsDelete)
        {
            PlayerPrefs.DeleteAll();
            prefsDelete = false;
        }



    }
    public void ErasePrefsData()
    {
        prefsDelete = true;

    }

    private void Start()
    {
        
        playerRotation = GetComponent<PlayerRotation>();


        place = GameObject.Find(locationName).GetComponent<DestinationPlace>();
        transform.parent = place.interactiveLocation;

        SetNewTransform(place);

    }

    // Update is called once per frame
    void Update()
    {

        if (newTransform)
            Move();

        
        //Detectem nodes on es desplaça el player i activem el desplaçament amb un doble "tap"
        if (doubleClick.doubleClickDone)
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {

                if (moveEnded)
                {
                   
                    place = hit.collider.GetComponent<DestinationPlace>();
                   // backPlace = hit.collider.GetComponent<BackPlace>();



                    if (place != null)
                    {
                        Debug.Log("place collider: " + hit.collider.name);

                        SetNewTransform(place);
                       // playerSource.Play();
                       if(hit.collider.name == "EntradaVestibul")
                        {
                            grills.loop = false;
                            hit.collider.GetComponent<AudioSource>().Play();
                        }
                        

                    }



                    if (hit.collider.tag == "Stairs")
                    {

                        if (index > 1)
                            index = 0;


                        //timeline = timelineAsset[index];
                        //playableDirector.Play(timeline);
                        timelineController.PlayFromTimelines(index);


                        index++;
                        
                    }


                }

                
            }
            
            doubleClick.doubleClickDone = false;
        }

        //Usem dos dits per retornar a una posició 
       

        if (Input.touchCount == 2)
        {
            

            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
            {
                //Debug.Log("Began");
                playerRotation.enabled = false;

                previousTouchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                backPlace = transform.parent.parent.GetComponent<BackPlace>();
               

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                //Debug.Log("Move");
                float distance;
                Vector2 touch1 = Input.GetTouch(0).position;
                Vector2 touch2 = Input.GetTouch(1).position;
                distance = Vector2.Distance(touch1, touch2);
                deltaDistance = previousTouchDistance - distance;

                
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                if (!inventoryCanvasGroup.blocksRaycasts)
                    inventoryCanvasGroup.blocksRaycasts = true;

                if (moveEnded)
                {
                    if (backPlace != null)
                    {
                        place = backPlace.backPlace;
                        SetNewTransform(place);
                       // playerSource.Play();

                    }


                }
                deltaDistance = 0;
                playerRotation.enabled = true;

            }

        }
        
        if( Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 4f))
            {
                Interactuable interactuable = hit.collider.GetComponentInChildren<Interactuable>();
                if(interactuable != null)
                {
                    interactuable.Interactua();
                    Debug.Log("Interactuable amb " + hit.collider);

                    if (hit.collider.name == "MobleCubParet")
                    {
                        inventoryCanvasGroup.blocksRaycasts = false;
                       

                    }
                                       

                }

                switch (hit.collider.name)
                {
                    case "BlueGlass":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "RedGlass":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "GreenGlass":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "YellowGlass":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "Red":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "Yellow":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "Green":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "Blue":
                        hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "EntradaSalaPlantaBaixa":
                        piano.Play();
                        break;
                    case "IniciEscalaPlantaBaixa":
                        piano.loop = false;
                        piano.Stop();
                        esbufec.Play();
                        break;
                    case "EntradaPlanta":
                        piano.loop = true;
                        piano.Play();
                        break;
                    case "EntradaSalaMúsica":
                        piano.loop = false;
                        piano.Stop();
                        campanes.Play();
                        //hit.collider.GetComponent<AudioSource>().Play();
                        break;
                    case "PortaSalaMusica":
                        campanes.Stop();
                        break;

                }
                
               
            }


        }
       

    }
    bool newTransformAgain;

    void SetNewTransform(DestinationPlace _place)
    {
        //Desvinculem del pare
        transform.parent = null;
        //Assignem el lloc de destí
        newTransform = _place.interactiveLocation;
        //Orientem correctament el lloc de destí
        newTransform.localRotation = Quaternion.identity;
        //Assignem el lloc de destí com a pare
        transform.parent = newTransform;
        targetName = newTransform.tag;
        //rotació
        playerRotation.SetRotationValues(0, 0, Quaternion.identity);
        playerRotation.GetTargetName(targetName);
        //Activem els nodes
        _place.ReachablePlaces();
        place = _place;
    }
    void SetCurrentTransform(DestinationPlace _place)
    {
        newTransform = _place.interactiveLocation;
        targetName = newTransform.tag;
        playerRotation.GetTargetName(targetName);
        _place.ReachablePlaces();
        place = _place;
    }

    void Move()
    {
        playerRotation.enabled = false;
        moveEnded = false;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime * 4f);
       // transform.parent.localRotation = Quaternion.identity;
       // playerRotation.enabled = false;

        if (targetName == "Panoramic")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);

            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;
            }
        }
        if (targetName == "LookAt")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -2), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -2)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -2);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "Detail")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -0.5f), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -0.5f)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -0.5f);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "NoRotation")
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                moveEnded = true;

                // playerRotation.enabled = true;
            }
        }

       
    }

   

    //private void OnApplicationQuit()
    //{
    //    SaveSystemJSON.SavePlayerData(this);
    //}



    //private void OnApplicationPause(bool pause)
    //{
    //    SaveSystemJSON.SavePlayerData(this);
    //}

}
