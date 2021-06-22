using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject item;
    public ScrollRect scrollRect;
    public float scrollspeed = 0.01f;

    List<ShopItem> list = new List<ShopItem>();
    // unity functions
    void Start(){
        // shopitem 확인
        int childc = scrollRect.content.transform.childCount;
        for (int i = 0; i < childc; i++)
        {
            Transform tr = scrollRect.content.transform.GetChild(i);
            if(tr.gameObject.activeSelf != true)
                continue;
            ShopItem shopItem = tr.gameObject.GetComponent<ShopItem>();
            list.Add(shopItem);
        }

        // temp 50개 생성
        for (int i = 0; i < 10; i++)
        {
            CreateShopItem($"tmpitem{i:00}");
        }

        scrollRect.normalizedPosition = new Vector2(0,1);

        // item size
        float itemSize = 0;
        float viewportSize = GetComponent<RectTransform>().sizeDelta.y;
        if(list.Count > 0)
            itemSize = list[0].GetComponent<RectTransform>().sizeDelta.y;
            
        // item location
        float targetPosPer = (itemSize / (scrollRect.content.sizeDelta.y - viewportSize)) * FindItemIdx("tmpitem04");
        StartCoroutine(AutoScroll(targetPosPer));

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.A)){
            CreateShopItem("tmpitem");
        }
    }
    // custom functions
    void CreateShopItem(string itemname){
        GameObject newobj = Instantiate<GameObject>(item);
        newobj.transform.SetParent(scrollRect.content.transform);
        newobj.SetActive(true);

        ShopItem sitem = newobj.GetComponent<ShopItem>();
        sitem.itemName.text = itemname;
        list.Add(sitem);
    }
    public ShopItem FindItem(string name){
        return list.Find((x) => x.itemName.text.Equals(name));
    }
    public int FindItemIdx(string name){
        return list.FindIndex((x) => x.itemName.text.Equals(name));
    }
    /// <summary>
    /// auto scroll
    /// </summary>
    /// <param name="targetPos">0 to 1</param>
    /// <returns></returns>
    public IEnumerator AutoScroll(float targetPosPer){
        Vector2 target = new Vector2(0, 1f - targetPosPer);

        while(true){
            scrollRect.normalizedPosition 
                = Vector2.MoveTowards(scrollRect.normalizedPosition, target, scrollspeed);
            if(scrollRect.normalizedPosition.y <= target.y)
                break;
            yield return null;
        }

    }
}