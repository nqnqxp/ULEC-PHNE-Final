using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public AssignInk[] interactables;

    void Update()
    {
        if (AllTalkedTo())
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
}
