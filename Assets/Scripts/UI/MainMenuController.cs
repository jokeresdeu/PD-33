using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : BaseGameMenuController
{
    [Header("MainMenu")]
    [SerializeField] private Button _chooseLvl;
    [SerializeField] private Button _reset;

    [SerializeField] private GameObject _lvlMenu;
    [SerializeField] private Button _closeLvlMenu;

    private int _lvl = 1;

    protected override void Start()
    {
        base.Start();
        _chooseLvl.onClick.AddListener(OnLvlMenuClicked);
        _closeLvlMenu.onClick.AddListener(OnLvlMenuClicked);
        if (PlayerPrefs.HasKey(GamePrefs.LastPlayedLvl.ToString()))
        {
            _play.GetComponentInChildren<TMP_Text>().text = "Resume";
            _lvl = PlayerPrefs.GetInt(GamePrefs.LastPlayedLvl.ToString());
        }
        _play.onClick.AddListener(OnPlayClicked);
        _reset.onClick.AddListener(OnResetClicked);
           
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _chooseLvl.onClick.RemoveListener(OnLvlMenuClicked);
        _closeLvlMenu.onClick.RemoveListener(OnLvlMenuClicked);
        _play.onClick.RemoveListener(OnPlayClicked);
        _reset.onClick.RemoveListener(_serviceManager.ResetProgres);
    }

    private void OnLvlMenuClicked()
    {
        _lvlMenu.SetActive(!_lvlMenu.activeInHierarchy);
        OnMenuClicked();
    }

    private void OnPlayClicked()
    {
        _serviceManager.ChangeLvl(_lvl);
        _audioManager.Play(UiClipNames.Play);
    }

    private void OnResetClicked()
    {
        _play.GetComponentInChildren<TMP_Text>().text = "Play";
        _serviceManager.ResetProgres();
    }
}
