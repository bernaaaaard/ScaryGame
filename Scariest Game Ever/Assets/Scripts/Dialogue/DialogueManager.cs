using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Singleton
    public static DialogueManager Instance { get; private set; }

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Testing")]
    [SerializeField] private TextAsset testingAsset;

    private Story currentStory;
    private bool dialogueIsPlaying = false;


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
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueIsPlaying) 
        {
            if (Input.GetMouseButtonDown(0))
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
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        // Run next line
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
