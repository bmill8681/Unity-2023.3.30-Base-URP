using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject firstSelectedElement;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedElement);
    }
    public void StartGame()
    {
        SceneController.instance.TransitionToScene(SceneController.SCENE.MAIN_GAME);
        MusicController.instance.PlayMusic(SOUNDTRACK.TEST_TRACK_1);
    }

    public void OpenSettings()
    {
        GameController.instance.SetState(GameController.GAMESTATE.PAUSED);
    }

    public void QuitGame()
    {
        GameController.instance.QuitGame();
    }
}
