using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

public class InteractionDisplay : MonoBehaviour
{
    public string interactionText = "Use psychometry";
    public Canvas descriptionCanvas;
    public TextMeshProUGUI objectNameDisplay;
    public TextMeshProUGUI objectDescriptionDisplay;
    public string objectNameText;
    public string objectDescriptionText;
    public UnityEvent onInteract;

    void Start()
    {
        objectNameDisplay.text = objectNameText;
        objectDescriptionDisplay.text = objectDescriptionText;
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        onInteract.Invoke();
        descriptionCanvas.enabled = true;
    }

    public void DisableDescription()
    {
        descriptionCanvas.enabled = false;
    }
}
