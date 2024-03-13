using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBall : MonoBehaviour
{
    [SerializeField]
    private int cost;

    [SerializeField]
    private int productNumber;
    [SerializeField]
    private GameObject notBuyObj;

    private void Awake()
    {
        if (GameManager.instance.CheckBuyedBallsArr(productNumber))
        {
            ForbidBuying();
        }
        else
        {
            GetComponent<Button>().onClick.AddListener(Buy);
        }
    }
    public void Buy()
    {
        if (GameManager.instance.CheckCanBuy(cost))
        {
            ForbidBuying();
            GameManager.instance.ChangeBuyedBallsArr(productNumber);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
    private void ForbidBuying()
    {
        notBuyObj.SetActive(false);
    }
}
