using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController UIControllerS;
    [SerializeField]
    private GameObject _ActiveScreen;

    private void Start()
    {
        UIControllerS = this;
    }

    public void ChangeActiveScreen(GameObject screen)
    {
        _ActiveScreen = screen;
    }
    public void CloseScreen(bool cantCloseActiveScreen)
    {
        if (!cantCloseActiveScreen)
            _ActiveScreen.SetActive(false);
    }
}
