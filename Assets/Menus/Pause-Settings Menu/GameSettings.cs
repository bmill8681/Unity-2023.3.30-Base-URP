using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameSettings : MonoBehaviour
{
    [SerializeField] GameSettingsSO settings;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    private void Awake()
    {
        if (!settings) throw new Exception("GameSettings requires a GameSettingsSO object");

        masterVolumeSlider.value = settings.MasterVolume;
        musicVolumeSlider.value = settings.MusicVolume;
        sfxVolumeSlider.value = settings.SfxVolume;
    }

    private void Start()
    {
        InputController.instance.OnToggleMenuActions += ToggleInputSubscription;
    }

    private void OnDestroy()
    {
        InputController.instance.OnToggleMenuActions -= ToggleInputSubscription;
    }

    void ToggleInputSubscription(bool enabled)
    {
        if (enabled) InputController.instance.PlayerInput.MenuActions.Selection.performed += HandleSelectionInput;
        else InputController.instance.PlayerInput.MenuActions.Selection.performed -= HandleSelectionInput;
    }

    void HandleSelectionInput(InputAction.CallbackContext ctx)
    {
        Debug.Log("Performed");
    }

    public void SetMasterVolume()
    {
        settings.MasterVolume = masterVolumeSlider.value;
        MusicController.instance.SetMusicVolume(settings.MasterVolume * settings.MusicVolume);
    }
    public void SetMusicVolume()
    {
        settings.MusicVolume = musicVolumeSlider.value;
        MusicController.instance.SetMusicVolume(settings.MasterVolume * settings.MusicVolume);
    }

    // TODO: When a strategy is set for handling sound effects, set the sound effect volume here.
    public void SetSfxVolume() { settings.SfxVolume = sfxVolumeSlider.value; }
}
