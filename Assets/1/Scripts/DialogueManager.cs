using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public Text dialogueText;
    public TextAsset inkJSONAsset;

    private Story story;

    private void Awake()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        story = new Story(inkJSONAsset.text);
        DisplayNextLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        if (story.canContinue)
        {
            string text = story.Continue();
            dialogueText.text = text;
        }
        else
        {
            dialogueCanvas.gameObject.SetActive(false);
        }
    }
}

