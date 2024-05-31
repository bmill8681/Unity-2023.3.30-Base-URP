using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusProtector : MonoBehaviour
{
    protected GameObject lastSelected;
    protected void HandleFocusLoss()
    {

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (lastSelected && lastSelected.gameObject.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(lastSelected);
                return;
            }
        }
        else
        {
            lastSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}
