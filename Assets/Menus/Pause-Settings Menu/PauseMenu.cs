using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    // TODO: This could be better and animate in or something. Fix it if time permits.
    [SerializeField] GameObject menu;

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
        if (state.Equals(GameController.GAMESTATE.PAUSED)) menu.SetActive(true);
        else menu.SetActive(false);
    }
}
