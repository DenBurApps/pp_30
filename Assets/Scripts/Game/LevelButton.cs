using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _startLevelButton;
    [SerializeField] private List<Image> _stars;
    [SerializeField] private Sprite _star;
    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private GameObject _locker;
    private int _levelIndex = 0;
    public Action<int> StartLevel;
    public Action ClosedLevel;


    public void Init(int index)
    {
        _levelIndex = index;
        _levelNumber.text = (_levelIndex + 1).ToString();
    }

    public void UpdateLevel()
    {
        _startLevelButton.onClick.RemoveAllListeners();
        if (_levelIndex <= GameManager.instance.UnlockedLevels)
        {
            _levelNumber.gameObject.SetActive(true);
            _locker.SetActive(false);
            _startLevelButton.onClick.AddListener(OnStartButtonClicked);
        }
        else
        {
            _levelNumber.gameObject.SetActive(false);
            _locker.SetActive(true);
            _startLevelButton.onClick.AddListener(OnClosedLevelClicked);
        }
        for (int i = 0; i < GameManager.instance.stars[_levelIndex]; i++)
        {
            _stars[i].sprite = _star;
        }
    }

    private void OnStartButtonClicked()
    {
        StartLevel?.Invoke(_levelIndex);
    }

    private void OnClosedLevelClicked()
    {
        ClosedLevel?.Invoke();
    }
}
