using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Wallet
{
    public static int CurrentMoney { get; private set; }

    public static event Action MoneyChanged;

    public static void SetStartMoney()
    {
        CurrentMoney = GameManager.instance.crystals;
    }

    public static void AddMoney(int count)
    {
        CurrentMoney += count;
        GameManager.instance.AddToCrystals(count);
        MoneyChanged?.Invoke();
    }

    public static void RemoveMoney(int count)
    {
        CurrentMoney -= count;
        GameManager.instance.AddToCrystals(-count);
        MoneyChanged?.Invoke();
    }

    public static bool CanRemoveMoney(int count)
    {
        if (CurrentMoney >= count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
