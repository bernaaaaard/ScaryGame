using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive;
    public GameObject EpicUI;
    public IntroScript GameManager;
    public bool couchSitdown;
    public bool failsafe;
    
    public bool introJumpscare;
    public GameObject player;
    public GameObject sofaCam;

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
        if ((triggerActive && Input.GetKeyDown(KeyCode.E)) && failsafe == false || introJumpscare == true)
        {
            if (couchSitdown == true)
            {
                failsafe = true;
                player.SetActive(false);
                sofaCam.SetActive(true);
                
                StartCoroutine(Failsafe());
            }
            if (couchSitdown == false)
            {
                ManagerSequencer();
            }
            
        }

        if (triggerActive && Input.GetKeyDown(KeyCode.E) && sofaCam.gameObject.activeSelf == true && failsafe == false)
        {
            failsafe = true;
            player.SetActive(true);
            sofaCam.SetActive(false);
        }
    }
    IEnumerator Failsafe()
    {
        yield return new WaitForSeconds(.05f);
        failsafe = false;
    }
    public void ManagerSequencer()
    {
        GameManager.sequence = GameManager.sequence + 1;
        Destroy(this.gameObject);
    }
}
