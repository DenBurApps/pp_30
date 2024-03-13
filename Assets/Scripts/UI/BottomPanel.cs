using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    [SerializeField]
    private Color disabledColor;
    [Serializable]
    private struct buttonsAndWindows
    {
        public Button button;
        public Image buttonImage;
        public TextMeshProUGUI buttonText;
        public GameObject window;
    }
    [SerializeField]
    private buttonsAndWindows[] BAW;
    private void Awake()
    {
        foreach (var obj in BAW)
        {
            obj.button.onClick.AddListener(() =>
            OnClick(obj));
        }
    }
    private void OnClick(buttonsAndWindows properties)
    {
        foreach(var obj in BAW)
        {
            obj.buttonImage.color = disabledColor;
            obj.buttonText.color = disabledColor;
            obj.window.SetActive(false);
        }

        properties.buttonImage.color = Color.white;
        properties.buttonText.color = Color.white;
        properties.window.SetActive(true);

        foreach (Transform t in properties.window.transform)
        {
            if (t.gameObject.activeInHierarchy)
                UIController.UIControllerS.ChangeActiveScreen(t.gameObject);
        }
    }
}
