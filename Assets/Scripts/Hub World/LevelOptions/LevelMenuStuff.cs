﻿using UnityEngine;
public class LevelMenuStuff : MonoBehaviour
{
    [SerializeField] private GameObject menuBox = null;
    [SerializeField] private EnterLevelOptionsButton enterLevelOptions = null;
    public LevelMenuButtons levelMenuButtons = null;
    public LevelSelectOptions levelSelectOptions = null;
    public RaceModeOptions raceModeOptions = null;
    public LapsOptions lapsOptions = null;
    public AiOptions aiOptions = null;
    public DifficultyOptions difficultyOptions = null;
    public WeatherOptions weatherOptions = null;
    public TimeOfDayOptions timeOfDayOptions = null;
    public MirrorTrackOptions mirrorTrackOptions = null;
    public ReverseTrackOptions reverseTrackOptions = null;
    [SerializeField] private Transform lockTransform = null;
    [SerializeField] private float sinkDuration = 0.45f;
    public float SinkDuration { get { return sinkDuration; } }
    private void Start()
    {
        menuBox.SetActive(false);
        enterLevelOptions.gameObject.SetActive(true);
    }
    public void EnterMenu()
    {
        respawnAndDespawnSphere.SphereState = false;
        GameManager.player.GetComponent<PlayerMenuController>().LockPlayerToPosition(lockTransform.position, lockTransform.rotation);
        ResetOptions();
        menuBox.SetActive(true);
        enterLevelOptions.gameObject.SetActive(false);
    }
    public void ExitMenu()
    {
        respawnAndDespawnSphere.SphereState = true;
        GameManager.player.GetComponent<PlayerMenuController>().UnlockPlayerPosition();
        menuBox.SetActive(false);
        enterLevelOptions.gameObject.SetActive(true);
    }
    public void ResetOptions()
    {
        levelSelectOptions.ResetOptions();
        raceModeOptions.ResetOptions();
        lapsOptions.ResetOptions();
        aiOptions.ResetOptions();
        difficultyOptions.ResetOptions();
        weatherOptions.ResetOptions();
        timeOfDayOptions.ResetOptions();
        mirrorTrackOptions.ResetOptions();
        reverseTrackOptions.ResetOptions();
    }
    public void DefaultOptions()
    {
        levelMenuButtons.DefaultOptions();
        levelSelectOptions.DefaultOptions();
        raceModeOptions.DefaultOptions();
        lapsOptions.DefaultOptions();
        aiOptions.DefaultOptions();
        difficultyOptions.DefaultOptions();
        weatherOptions.DefaultOptions();
        timeOfDayOptions.DefaultOptions();
        mirrorTrackOptions.DefaultOptions();
        reverseTrackOptions.DefaultOptions();
    }
    public void ConfirmOptions()
    {
        levelMenuButtons.ConfirmOptions();
        levelSelectOptions.ConfirmOptions();
        raceModeOptions.ConfirmOptions();
        lapsOptions.ConfirmOptions();
        aiOptions.ConfirmOptions();
        difficultyOptions.ConfirmOptions();
        weatherOptions.ConfirmOptions();
        timeOfDayOptions.ConfirmOptions();
        mirrorTrackOptions.ConfirmOptions();
        reverseTrackOptions.ConfirmOptions();
        ExitMenu();
    }
}