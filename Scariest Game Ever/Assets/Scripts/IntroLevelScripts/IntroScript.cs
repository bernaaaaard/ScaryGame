using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroScript : MonoBehaviour
{
    public int sequence = 0;
    bool startTour;
    bool messedUpOnce = false;
    GameObject PlayerCharacter1;
    GameObject PlayerCharacter2;
    Transform teleportPlace;
    ColliderScript surrealRealm;
    GameObject TriggerBoi1;
    GameObject TriggerBoi2;
    GameObject TriggerBoi3;
    GameObject TriggerBoi4;
    GameObject AntiStairsColldier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTour == true)
        {
            AntiStairsColldier.SetActive(true);

            switch (sequence)
            {
                case 0:
                    TriggerBoi1.SetActive(true);
                    TriggerBoi2.SetActive(true);
                break;

                case 1:
                    TriggerBoi1.SetActive(false);
                    TriggerBoi2.SetActive(false);
                    TriggerBoi3.SetActive(true);
                break;

                case 2:
                    TriggerBoi3.SetActive(false);
                    TriggerBoi4.SetActive(true);
                break;
            }
                       
        }
        if (startTour == true && sequence == 0)
        {
            AntiStairsColldier.SetActive(true);
            TriggerBoi1.SetActive(true);
        }
        if (startTour == false)
        {
            AntiStairsColldier.SetActive(false);
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
