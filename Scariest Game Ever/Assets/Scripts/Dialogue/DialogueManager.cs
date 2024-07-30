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
    [SerializeField] private GameObject notePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI noteText;


    [Header("Debug")]
    [SerializeField] private bool testingMode = true;
    [SerializeField] private TextAsset currentStoryJSON;
    [SerializeField] private TextAsset testingAsset;

    private Story currentStory;
    private GameObject currentPanel;
    private TextMeshProUGUI currentText;
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
        if (dialoguePanel == null || notePanel == null)
        {
            // Grab 
            TextMeshProUGUI[] dialogueTextObj = FindObjectsByType<TextMeshProUGUI>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (TextMeshProUGUI text in dialogueTextObj)
            {
                if (text.name == "DialogueText")
                {
                    dialogueText = text;
                    dialoguePanel = text.transform.parent.gameObject;
                }

                if (text.name == "NoteText")
                {
                    noteText = text;
                    notePanel = text.transform.parent.gameObject;
                }
            }


            // Yell at u if still null
            if (dialoguePanel == null) 
            {
                Debug.LogError("Couldn't find the dialogue panel in the scene. Either add the DialogueCanvas prefab or link to it directly in the DialogueManager");
                return;
            }

            if (notePanel == null) 
            {
                Debug.LogError("Couldn't find the note panel in the scene. Either add the DialogueCanvas prefab or link to it directly in the DialogueManager");
                return;
            }

            // If the panels aren't set, the text probably isn't either
            dialogueText = dialoguePanel.transform.GetComponentInChildren<TextMeshProUGUI>();
            noteText = notePanel.transform.GetComponentInChildren<TextMeshProUGUI>();
        }


        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        notePanel.SetActive(false);
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

    public void EnterDialogueMode(TextAsset inkJSON, string knotToStartFrom = "", bool isNote = false)
    {
        // Setup dialogue
        currentStoryJSON = inkJSON;

        if (currentStoryJSON == null)
        {
            Debug.LogWarning("Dialogue manager was not passed in a story. Running test in place.");
            currentStoryJSON = testingAsset;
        }

        currentStory = new Story(inkJSON.text);

        // Get right panel / text
        if (isNote)
        {
            currentPanel = notePanel;
            currentText = noteText;

        }
        else
        {
            currentPanel = dialoguePanel;
            currentText = dialogueText;
        }

        // Knot start
        if (knotToStartFrom != "")
        {
            Debug.Log("Starting Dialouge from " + knotToStartFrom + " knot. (If no dialogue happens, check spelling of knot)");
            currentStory.ChoosePathString(knotToStartFrom);
        }

        DialogueIsPlaying = true;
        currentPanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        // Run next line
        if (currentStory.canContinue)
        {
            currentText.text = currentStory.Continue();

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
        currentPanel.SetActive(false);
        currentText.text = "";
    }
}
