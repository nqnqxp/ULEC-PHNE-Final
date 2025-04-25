using TMPro;
using UnityEngine;

public class RaycastLogic : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask interactableLayer;
    public Camera playerCamera;
    public Canvas interactionCanvas;
    public Canvas dialogueCanvas;

    private GameObject currentTarget;
    private bool canInteract = false;
    private string interactionText;

    private void Start()
    {
        interactionCanvas.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            currentTarget = hit.collider.gameObject; interactionCanvas.gameObject.SetActive(true);

            canInteract = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue(currentTarget);
            }

            if (hit.collider.CompareTag("NPC"))
            {
                interactionText = "Talk";
            }
            else if (hit.collider.CompareTag("Object"))
            {
                interactionText = "Use Psychometry";
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

        DialogueManager.instance.StartDialogue(inkTarget.inkJSON);
        interactionCanvas.gameObject.SetActive(false );

        target.layer = LayerMask.NameToLayer("Default");

    }
}
