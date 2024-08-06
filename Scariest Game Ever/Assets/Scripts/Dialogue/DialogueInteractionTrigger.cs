using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractionTrigger : DialogueTrigger
{
    [Header("Debug: Interaction Trigger")]
    [SerializeField] private bool isInRange = false;
    [SerializeField] private FirstPersonController firstPersonController;

    override protected void Start()
    {
        base.Start();
        hasBeenTriggered = false;
        //isNote = true;
        //isOneShot = false;

        if (firstPersonController == null)
        {
            firstPersonController = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>();
        }
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(firstPersonController.interactionKey))
        {
            Debug.Log("Hype");

            // Start dialogue
            DialogueManager.Instance.EnterDialogueMode(inkStoryToPlay, knotToStartFrom, isNote);
            hasBeenTriggered = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }
}