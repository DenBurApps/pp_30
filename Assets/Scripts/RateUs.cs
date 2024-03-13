using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RateUs : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => { OnStarButtonClick(button);});
        }
    }
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private Sprite enabledSprite;

    private void OnStarButtonClick(Button clickedButton)
    {
        foreach (var button in buttons)
        {
            button.gameObject.GetComponent<Image>().sprite = disabledSprite;
        }
        int i = 0;
        foreach (var button in buttons)
        {
            i++;
            button.gameObject.GetComponent<Image>().sprite = enabledSprite;
            if (button == clickedButton)
            {
                break;
            }
        }
    }
}
