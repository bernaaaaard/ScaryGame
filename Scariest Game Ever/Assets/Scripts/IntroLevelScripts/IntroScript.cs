using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroScript : MonoBehaviour
{
    public int sequence = 0;
    public bool startTour;
    bool messedUpOnce = false;
    GameObject PlayerCharacter1;
    GameObject PlayerCharacter2;
    Transform teleportPlace;
    ColliderScript surrealRealm;
    public Transform teleportLocation;
    public GameObject TriggerBoi1;
    public GameObject TriggerBoi2;
    public GameObject TriggerBoi3;
    public GameObject TriggerBoi4;
    public GameObject TriggerBoi5;
    public GameObject TriggerBoi6;
    public GameObject TriggerBoi7;
    public GameObject InteractionCylinder1;
    public GameObject InteractionCylinder2;
    public GameObject InteractionCylinder3;
    public GameObject InteractionCylinder4;
    public GameObject InteractionCylinder5;
    public GameObject AntiStairsColldier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTour == true)
        {
            InteractionCylinder1.SetActive(true);
            InteractionCylinder2.SetActive(true);
            InteractionCylinder3.SetActive(true);
            InteractionCylinder4.SetActive(true);
            InteractionCylinder5.SetActive(true);

            switch (sequence)
            {
                case 0:
                    AntiStairsColldier.SetActive(true);
                    TriggerBoi1.SetActive(true);
                    TriggerBoi2.SetActive(true);
                    teleportPlace = InteractionCylinder1.transform;
                break;

                case 1:
                    TriggerBoi1.SetActive(false);
                    TriggerBoi3.SetActive(true);
                    TriggerBoi4.SetActive(true);
                    teleportPlace = InteractionCylinder2.transform;
                break;

                case 2:
                    TriggerBoi6.SetActive(true);
                    TriggerBoi4.SetActive(false);
                    teleportPlace = InteractionCylinder3.transform;
                break;

                case 3:
                    TriggerBoi2.SetActive(false);
                    teleportPlace = InteractionCylinder4.transform;
                break;

                case 4:
                    TriggerBoi3.SetActive(false);
                    TriggerBoi7.SetActive(true);
                    AntiStairsColldier.SetActive(false);
                    teleportPlace = InteractionCylinder5.transform;
                break;

                case 5:
                    TriggerBoi1.SetActive(false);
                    TriggerBoi2.SetActive(false);
                    TriggerBoi3.SetActive(false);
                    TriggerBoi4.SetActive(false);
                    TriggerBoi5.SetActive(false);
                    TriggerBoi6.SetActive(false);
                    TriggerBoi7.SetActive(false);
                    startTour = false;
                break;

                default:
                    break;
            }
                       
        }
    }

    public void surrealChange()
    {
        surrealRealm.teleportTarget = teleportPlace;
    }

    public void jumpscareIntro()
    {

    }
}
