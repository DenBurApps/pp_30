using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBall : MonoBehaviour
{
    public List<GameObject> spawned = new List<GameObject>();
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private BallInChoose prefab;
    private void OnEnable()
    {
        var gm = GameManager.instance;
        int spawnedPlatesCount = 0;
        for (int i = 0; i < gm.buyedBalls.Length; i++)
        {
            int k = i;
            if (gm.buyedBalls[k])
            {
                int f = spawnedPlatesCount;
                var obj = Instantiate(prefab, spawnPoint);
                obj.ballImage.sprite = gm.BallSprites[k];
                obj.GetComponent<Button>().onClick.AddListener(() => OnClick(k,f));
                spawned.Add(obj.gameObject);
                if(k == gm.ChoosedBall)
                    OnClick(k, f);
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
    private void OnClick(int i,int f)
    {
        GameManager.instance.ChoosedBall = i;
        foreach(GameObject item in spawned)
        {
            item.GetComponent<BallInChoose>().IsChoosed.SetActive(false);
            item.GetComponent<Button>().interactable = true;

        }
        Debug.Log("Plate number is " + f);
        spawned[f].GetComponent<BallInChoose>().IsChoosed.SetActive(true);
        spawned[f].GetComponent<Button>().interactable = false;
        GameManager.instance.ChangeBall(i);

    }
}
