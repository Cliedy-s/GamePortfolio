using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonClick : MonoBehaviour
{
    public Button buybutton;
    // unity functions
    void Start()
    {
        buybutton.onClick.AddListener(ClickBuyButton);
    }
    void Update()
    {
        
    }
    // custom functions
    public void ClickBuyButton(){
        Debug.Log("ClickBuy");
        buybutton.onClick.RemoveListener(ClickBuyButton);
    }
}
