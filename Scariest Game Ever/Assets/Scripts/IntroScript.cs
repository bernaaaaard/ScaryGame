using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroScript : MonoBehaviour
{
    bool startTour;
    bool messedUpOnce = false;
    GameObject PlayerCharacter1;
    GameObject PlayerCharacter2;
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
            TriggerBoi1.SetActive(true); 
        }
        if (startTour == false)
        {
            AntiStairsColldier.SetActive(false);
        }
    }

    public void UhOhDimension()
    {
        if (messedUpOnce == false)
        {
            PlayerCharacter1.SetActive(false);
            PlayerCharacter2.SetActive(true);
            StartCoroutine(WaitForABit());
        }
    }

    IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(5);
        PlayerCharacter2.SetActive(false);
        PlayerCharacter1.SetActive(true);
    }
}
