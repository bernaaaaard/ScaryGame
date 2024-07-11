using System;
using System.Collections;
using System.Collections.Generic;
using Ink;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Singleton
    public static DialogueManager Instance { get; private set; }

    [Header("Please Set")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Debug")]
    [SerializeField] private bool testingMode = true;
    [SerializeField] private TextAsset currentStoryJSON;
    [SerializeField] private TextAsset testingAsset;

    private Story currentStory;
    private List<string> currentLineTags;
    public bool DialogueIsPlaying {get; private set; }


    void Awake()
    {
        // Enforce singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Safefy assignments. I'm gonna assume that these might not be set
        if (dialoguePanel == null)
        {
            dialoguePanel = GameObject.Find("DialoguePanel");

            // Yell at u
            if (dialoguePanel == null) 
            {
                Debug.LogError("Couldn't find the dialogue panel in the scene. Either add the DialogueCanvas prefab or link to it directly in the DialogueManager");
                return;
            }

            // If the panel isn't set, the text probably isn't either
            dialogueText = dialoguePanel.transform.GetComponentInChildren<TextMeshProUGUI>();
        }


        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueIsPlaying) 
        {
            if (testingMode && Input.GetMouseButtonDown(0))
            {
                EnterDialogueMode(testingAsset);
            }

            return;
        }

        // Unsure if we want this to be the button that advances dialogue, but tossing it in for now
        if (Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        // Setup dialogue
        currentStoryJSON = inkJSON;

        if (currentStoryJSON == null)
        {
            Debug.LogWarning("Dialogue manager was not passed in a story. Running test in place.");
            currentStoryJSON = testingAsset;
        }

        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        // Run next line
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            // Check tags
            if (currentStory.currentTags.Count > 0)
            {
                currentLineTags = currentStory.currentTags;
                Debug.Log("Current line has tags");

                // TODO parse tags and do the jazz associated with them
                foreach(string tag in currentStory.currentTags)
                {
                    Debug.Log("Contains Tag: " + tag);
                }
                // Clear tags
                currentLineTags.Clear();
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
