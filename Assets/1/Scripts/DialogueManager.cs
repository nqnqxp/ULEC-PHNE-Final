using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.UIElements;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextAsset currentInk;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueNameText;

    private Story story;
    public bool isDialoguePlaying;
    private AssignInk currentAssignInk;

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

    public void StartDialogue (TextAsset inkJSON, AssignInk assignInk)
    {
        currentInk = inkJSON;
        currentAssignInk = assignInk;

        story = new Story(inkJSON.text);
        if (story.variablesState.GlobalVariableExistsWithName("hasTalked"))
        {
            story.variablesState["hasTalked"] = assignInk.hasTalked;
        }

        isDialoguePlaying = true;
        dialogueCanvas.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            string nextline = story.Continue();

            if (nextline.Contains(":"))
            {
                string[] parts = nextline.Split(new[] { ':' }, 2);
                dialogueNameText.text = parts[0].Trim();
                dialogueText.text = parts[1].Trim();
            }
            else
            {
                dialogueNameText.text = "";
                dialogueText.text = nextline;
            }
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        if (story.variablesState["hasTalked"] != null && currentAssignInk != null)
        {
            currentAssignInk.hasTalked = (bool)story.variablesState["hasTalked"];
        }

        isDialoguePlaying = false;
        dialogueCanvas.gameObject.SetActive(false);
        dialogueText.text = "";
    }
}

