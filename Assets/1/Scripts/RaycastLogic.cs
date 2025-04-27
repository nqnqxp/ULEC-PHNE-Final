using TMPro;
using System;
using UnityEngine;
using StarterAssets;

public class RaycastLogic : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask interactableLayer;
    public Camera playerCamera;
    public Canvas interactionCanvas;
    public Canvas dialogueCanvas;
    public Canvas blueprintCanvas;
    public TextMeshProUGUI interactionTextObject;

    private GameObject currentTarget;
    private string interactionText;
    private float OGMoveSpeed;
    private FirstPersonController playerController;
    private DialogueManager dialogueManager;

    private void Awake()
    {
        playerController = GetComponent<FirstPersonController>();
        dialogueManager = GetComponent<DialogueManager>();
    }

    private void Start()
    {
        interactionCanvas.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
        blueprintCanvas.gameObject.SetActive(false);

        OGMoveSpeed = playerController.MoveSpeed;
    }

    private void Update()
    {
        if (dialogueManager.isDialoguePlaying)
        {
            interactionCanvas.gameObject.SetActive(false);
            playerController.MoveSpeed = 0;
            return;
        }
        else
        {
            playerController.MoveSpeed = OGMoveSpeed;
        }

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            interactionTextObject.text = interactionText;

            currentTarget = hit.collider.gameObject; interactionCanvas.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue(currentTarget);
                if (hit.collider.CompareTag("Blueprint"))
                {
                blueprintCanvas.gameObject.SetActive(true);
                }
            }

            if (hit.collider.CompareTag("NPC"))
            {
                interactionText = "Talk";
            }
            else if (hit.collider.CompareTag("Psychometry"))
            {
                interactionText = "Use Psychometry";
            }
            else if (hit.collider.CompareTag("Read") || hit.collider.CompareTag("Blueprint"))
            {
                interactionText = "Read";
            }
        }
        else
        {
            interactionCanvas.gameObject.SetActive(false);
        }
    }

    void StartDialogue(GameObject target)
    {
        AssignInk inkTarget = target.GetComponent<AssignInk>();

        DialogueManager.instance.StartDialogue(inkTarget.inkJSON, inkTarget);
        interactionCanvas.gameObject.SetActive(false );
    }
}
