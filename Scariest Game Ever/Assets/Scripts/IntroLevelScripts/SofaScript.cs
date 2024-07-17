using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaScript : MonoBehaviour
{
    public GameObject player;
    public GameObject preTriggerTours;
    public IntroScript gameManager;
    public GameObject interactor;
    public GameObject uiElement;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactor.SetActive(false);
            uiElement.SetActive(false);
            player.SetActive(true);
            preTriggerTours.SetActive(false);
            gameManager.startTour = true;
            this.gameObject.SetActive(false);
        }    
    }
}
