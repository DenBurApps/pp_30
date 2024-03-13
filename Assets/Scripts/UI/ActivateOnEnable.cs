using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEnable : MonoBehaviour
{
    public GameObject obj;
    private void OnEnable()
    {
        obj.SetActive(true);
    }
}
