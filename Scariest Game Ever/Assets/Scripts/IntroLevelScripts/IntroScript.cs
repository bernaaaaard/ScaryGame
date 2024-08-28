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
    public GameObject KitchenTrigger1;
    public GameObject StairsTrigger1;
    public GameObject LivingRoomTrigger;
    public GameObject BathroomTrigger;
    public GameObject HallwayTrigger1;
    public GameObject HallwayTrigger2;
    public GameObject KitchenTrigger2;
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
                    KitchenTrigger1.SetActive(true);
                    StairsTrigger1.SetActive(true);
                    teleportPlace = InteractionCylinder1.transform;
                break;

                case 1:
                    KitchenTrigger1.SetActive(false);
                    LivingRoomTrigger.SetActive(true);
                    BathroomTrigger.SetActive(true);
                    teleportPlace = InteractionCylinder2.transform;
                break;

                case 2:
                    HallwayTrigger2.SetActive(true);
                    BathroomTrigger.SetActive(false);
                    teleportPlace = InteractionCylinder3.transform;
                break;

                case 3:
                    StairsTrigger1.SetActive(false);
                    teleportPlace = InteractionCylinder4.transform;
                break;

                case 4:
                    LivingRoomTrigger.SetActive(false);
                    KitchenTrigger2.SetActive(true);
                    AntiStairsColldier.SetActive(false);
                    teleportPlace = InteractionCylinder5.transform;
                break;

                case 5:
                    KitchenTrigger1.SetActive(false);
                    StairsTrigger1.SetActive(false);
                    LivingRoomTrigger.SetActive(false);
                    BathroomTrigger.SetActive(false);
                    HallwayTrigger1.SetActive(false);
                    HallwayTrigger2.SetActive(false);
                    KitchenTrigger2.SetActive(false);
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
