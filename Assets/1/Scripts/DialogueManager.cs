using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SearchService;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextAsset currentInk;
    public Canvas dialogueCanvas;
    public Canvas blueprintCanvas;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueNameText;
    public GameObject choicesObject;

    [Header("Choices")]
    public TextMeshProUGUI dialogueTextObject;
    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;
    public GameObject choice1Panel;
    public GameObject choice2Panel;

    private Story story;
    public bool isDialoguePlaying;
    private AssignInk currentAssignInk;

    private int currentChoiceIndex = 0;

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
        if (isDialoguePlaying)
        {
            if (story.canContinue && Input.GetKeyDown(KeyCode.Space))
            {
                ContinueStory();
            }
            else if (!story.canContinue && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
            }
            else if (story.currentChoices.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    currentChoiceIndex = Mathf.Max(currentChoiceIndex - 1, 0);

                    choice1Panel.SetActive(true);
                    choice2Panel.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    currentChoiceIndex = Mathf.Min(currentChoiceIndex + 1, story.currentChoices.Count - 1);

                    choice1Panel.SetActive(false);
                    choice2Panel.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    MakeChoice(currentChoiceIndex);
                    currentChoiceIndex = 0;
                    choice1Panel.SetActive(true);
                    choice2Panel.SetActive(false);
                }
            }
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
        dialogueCanvas.gameObject.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            string nextline = story.Continue();

            HandleTags(story.currentTags);
            DisplayLine(nextline);
        }
        else
        {
            EndDialogue();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

          CharacterSpriteManager.instance.ChangeSprite(tagValue);
        }
    }

    private void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();

        while (story.canContinue)
        {
            string nextline = story.Continue().Trim();
            if (!string.IsNullOrEmpty(nextline))
            {
                DisplayLine(nextline);
                return;
            }
        }
    }

    private void DisplayLine(string line)
    {
        if (line.Contains(":"))
        {
            string[] parts = line.Split(new[] { ':' }, 2);
            dialogueNameText.text = parts[0].Trim();
            dialogueText.text = parts[1].Trim();
        }
        else
        {
            dialogueNameText.text = "";
            dialogueText.text = line;
        }

        bool hasChoices = story.currentChoices.Count > 0;

        dialogueText.gameObject.SetActive(!hasChoices);
        choicesObject.SetActive(hasChoices);

        if (hasChoices)
        {
            choice1Text.text = story.currentChoices[0].text;
            choice2Text.text = story.currentChoices[1].text;
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
        blueprintCanvas.gameObject.SetActive(false);

        CharacterSpriteManager.instance.ChangeSprite("idle");

        dialogueText.text = "";
        dialogueNameText.text = "";
    }
}

