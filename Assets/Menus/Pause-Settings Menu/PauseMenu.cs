using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{

    // TODO: This could be better and animate in or something. Fix it if time permits.
    [SerializeField] GameObject menu;
    [SerializeField] GameObject firstSelectedElement;
    [SerializeField] GameObject returnToElement;

    private void Awake()
    {
        if (menu.activeSelf) menu.SetActive(false);
    }

    private void Start()
    {
        GameController.instance.OnStateChanged += HandleToggleMenu;
    }

    private void OnDestroy()
    {
        GameController.instance.OnStateChanged -= HandleToggleMenu;
    }

    void HandleToggleMenu(GameController.GAMESTATE state, GameController.GAMESTATE prevState)
    {
        if (state.Equals(GameController.GAMESTATE.PAUSED))
        {
            menu.SetActive(true);
            if (firstSelectedElement != null)
            {
                EventSystem.current?.SetSelectedGameObject(null);
                EventSystem.current?.SetSelectedGameObject(firstSelectedElement);
            }
        }
        else
        {
            menu.SetActive(false);
            if (returnToElement != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(returnToElement);
            }
        }
    }
}
