using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBack : MonoBehaviour
{
    [SerializeField]
    private int cost;

    [SerializeField]
    private int productNumber;
    [SerializeField]
    private GameObject buyObj;
    [SerializeField]
    private GameObject notBuyObj;

    private void Awake()
    {
        if (GameManager.instance.CheckBuyedBacksArr(productNumber))
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
            GameManager.instance.ChangeBuyedBacksArr(productNumber);
            GetComponent<Button>().onClick.RemoveAllListeners();

        }
    }
    private void ForbidBuying()
    {
        buyObj.SetActive(true);
        notBuyObj.SetActive(false);

    }
}
