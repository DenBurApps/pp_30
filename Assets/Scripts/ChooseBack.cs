using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBack : MonoBehaviour
{
    public List<GameObject> spawned = new List<GameObject>();
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private BackInChoose prefab;
    private void OnEnable()
    {
        var gm = GameManager.instance;
        int spawnedPlatesCount = 0;
        for (int i = 0; i < gm.buyedBacks.Length; i++)
        {
            int k = i;
            if (gm.buyedBacks[k])
            {
                int f = spawnedPlatesCount;
                var obj = Instantiate(prefab, spawnPoint);
                obj.backImage.sprite = gm.BackSprites[k];
                obj.GetComponent<Button>().onClick.AddListener(() => OnClick(k,f));
                spawned.Add(obj.gameObject);
                if (k == gm.ChoosedBack)
                    OnClick(k,f);
                spawnedPlatesCount++;
            }
        }
    }
    private void OnDisable()
    {
        foreach (GameObject item in spawned)
        {
            item.GetComponent<Button>().onClick.RemoveAllListeners();
            Destroy(item);
        }
        spawned.Clear();
    }
    private void OnClick(int i, int f)
    {
        GameManager.instance.ChoosedBack = i;
        foreach (GameObject item in spawned)
        {
            item.GetComponent<BackInChoose>().IsChoosed.SetActive(false);
            item.GetComponent<Button>().interactable = true;

        }
        spawned[f].GetComponent<BackInChoose>().IsChoosed.SetActive(true);
        spawned[f].GetComponent<Button>().interactable = false;
        GameManager.instance.ChangeBackground(i);
    }
}
