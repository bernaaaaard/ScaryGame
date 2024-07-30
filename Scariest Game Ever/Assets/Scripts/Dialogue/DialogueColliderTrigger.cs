using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueColliderTrigger : DialogueTrigger
{
    override protected void Start()
    {
        // Error checking
        base.Start();

        // reset triggered
        hasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        // Cue start of dialogue if we hit the player
        if (other.gameObject.GetComponent<FirstPersonController>() != null)
        {
            // Oneshot behavior
            if (isOneShot && hasBeenTriggered)
            {
                return;
            }

            // Start dialogue
            DialogueManager.Instance.EnterDialogueMode(inkStoryToPlay, knotToStartFrom, isNote);
            hasBeenTriggered = true;
        }
    }
}
