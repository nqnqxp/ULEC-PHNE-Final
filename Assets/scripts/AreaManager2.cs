using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager2 : MonoBehaviour
{
    public AssignInk[] interactables;
    public AssignInk[] interactables2;

    void Update()
    {
        if (AllTalkedTo() && AnyTalkedTo())
        {
            gameObject.SetActive(false);
        }

    }

    private bool AllTalkedTo()
    {
        foreach (AssignInk interactable in interactables)
        {
            if (!interactable.hasTalked)
            {
                return false;
            }
        }
        return true;
    }

    private bool AnyTalkedTo()
    {
        foreach (AssignInk interactable in interactables2)
        {
            if (interactable.hasTalked)
            {
                return true;
            }
        }
        return false;
    }
}
