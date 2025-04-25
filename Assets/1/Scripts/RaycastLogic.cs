using TMPro;
using UnityEngine;

public class RaycastLogic : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3f;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public InteractionDisplay currentInteraction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractionDisplay interactableObject = hit.collider.GetComponent<InteractionDisplay>();

            if (interactableObject != null && interactableObject != currentInteraction)
            {
                currentInteraction = interactableObject;
                interactionCanvas.enabled = true;
                interactionText.text = currentInteraction.GetInteractionText();
                interactableObject.objectNameDisplay.text = interactableObject.objectNameText;
                interactableObject.objectDescriptionDisplay.text = interactableObject.objectDescriptionText;
            }
        }

        else
        {
            if (currentInteraction != null)
            {
                currentInteraction.DisableDescription();
                currentInteraction = null;
            }
            interactionCanvas.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteraction != null)
        {
            currentInteraction.Interact();
        }
    }
}
