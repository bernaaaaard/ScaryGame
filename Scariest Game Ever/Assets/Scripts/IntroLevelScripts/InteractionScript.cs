using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public GameObject EpicUI;
    public IntroScript GameManager;
    public bool couchSitdown;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            EpicUI.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            EpicUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            if (couchSitdown == true)
            {
                GameManager.startTour = true;
            }
            ManagerSequencer();
        }
    }

    public void ManagerSequencer()
    {
        GameManager.sequence = GameManager.sequence + 1;
        Destroy(this.gameObject);
    }
}
