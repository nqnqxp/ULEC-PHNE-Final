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
    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;
    public GameObject choice1Panel;
    public GameObject choice2Panel;

    private Story story;
    public bool isDialoguePlaying;
    private AssignInk currentAssignInk;
    private RaycastLogic raycastLogic;
    private GameObject triggeredObject;
    private GameObject endingObject;
    public GameObject buttonObject;

    private int currentChoiceIndex = 0;

    [Header("Ending")]
    public GameObject reviveObject;
    public GameObject stayObject;
    public Canvas reviveCanvas;
    public Canvas stayCanvas;

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

        raycastLogic = GetComponent<RaycastLogic>();
    }

    private void Update()
    {
        if (isDialoguePlaying)
        {
            if (story.currentChoices.Count > 0)
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
            else
            {
                if (story.canContinue && Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueStory();
                }
                else if (!story.canContinue && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerDialogue"))
        {
            raycastLogic.StartDialogue(other.gameObject);

            triggeredObject = other.gameObject;
        }
        else if (other.CompareTag("EndingTrigger"))
        {
            raycastLogic.StartDialogue(other.gameObject);

            endingObject = other.gameObject;
            triggeredObject = null;
        }
        else if (other.CompareTag("CollisionDialogue"))
        {
            raycastLogic.StartDialogue(other.gameObject);
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

        if (story.variablesState.GlobalVariableExistsWithName("staySilent"))
        {
            story.variablesState["staySilent"] = assignInk.staySilent;
        }

        if (story.variablesState.GlobalVariableExistsWithName("pressButton") &&
    story.variablesState.GlobalVariableExistsWithName("hasTalked"))
        {
            bool pressButton = (bool)story.variablesState["pressButton"];
            bool hasTalked = (bool)story.variablesState["hasTalked"];

            if (pressButton && hasTalked)
            {
                reviveCanvas.gameObject.SetActive(true);
            }
            else if (!pressButton && hasTalked) 
            {
                stayCanvas.gameObject.SetActive(true);
            }
            else
            {
                dialogueCanvas.gameObject.SetActive(true);
            }
        }
        else
        {
            dialogueCanvas.gameObject.SetActive(true);
        }

        isDialoguePlaying = true;
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
            if (endingObject != null)
            {
                return;
            }

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
        if (story.variablesState["staySilent"] != null && currentAssignInk != null)
        {
            currentAssignInk.staySilent = (bool)story.variablesState["staySilent"];
        }

        isDialoguePlaying = false;
        dialogueCanvas.gameObject.SetActive(false);
        blueprintCanvas.gameObject.SetActive(false);

        if (story.variablesState["pressButton"] != null && story.variablesState["hasTalked"] != null) {
            bool pressButton = (bool)story.variablesState["pressButton"];
            bool hasTalked = (bool)story.variablesState["hasTalked"];

            if (pressButton && hasTalked)
            {
                reviveObject.SetActive(true);
            }
            else if (hasTalked && !pressButton)
            {
                stayObject.SetActive(true);
            }
        }

        if (CharacterSpriteManager.instance != null)
        {
            CharacterSpriteManager.instance.ChangeSprite("idle");
        }

        dialogueText.text = "";
        dialogueNameText.text = "";

        FindObjectOfType<RaycastLogic>().SetJustFinishedDialogue();

        if (triggeredObject != null && triggeredObject != endingObject)
        {
            triggeredObject.SetActive(false);
        }

        if (buttonObject != null)
        {
            buttonObject.SetActive(false);
        }
    }
}

