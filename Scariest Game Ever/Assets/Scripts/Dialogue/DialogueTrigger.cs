using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public abstract class DialogueTrigger : MonoBehaviour
{
    [Header("Set me plz")]
    [SerializeField] protected TextAsset inkStoryToPlay;
    [Tooltip("Write in the name of the Ink Knot that this trigger is supposed to start from. Leave empty if intending to start from the beginning of file")]
    [SerializeField] protected string knotToStartFrom;
    [Tooltip("Will the ink story only be allowed to be triggered once? When false, it can be triggered as many times as the story allows")]
    [SerializeField] protected bool isOneShot = false;

    [Header("Debug")]
    [SerializeField] protected bool hasBeenTriggered = false;
    [SerializeField] protected DialogueManager dialogueManager;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        // Some error checking
        if (DialogueManager.Instance == null)
        {
            Debug.LogError("There's no DialogueManager in the scene. No dialogue shall be managed");
            return;
        }

        if (inkStoryToPlay == null)
        {
            Debug.LogWarning("There's a dialogue trigger without an assigned ink story. FIX THIS OR YOU'LL REGRET IT >:(");
        }
    }
}
