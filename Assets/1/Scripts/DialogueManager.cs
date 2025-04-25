using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextAsset currentInk;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI dialogueText;

    private Story story;
    private bool isDialoguePlaying;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isDialoguePlaying && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void StartDialogue (TextAsset inkJSON)
    {
        currentInk = inkJSON;
        story = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialogueCanvas.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            string nextline = story.Continue();
            dialogueText.text = nextline.Trim();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isDialoguePlaying = false;
        dialogueCanvas.gameObject.SetActive(false);
        dialogueText.text = "";
    }
}

