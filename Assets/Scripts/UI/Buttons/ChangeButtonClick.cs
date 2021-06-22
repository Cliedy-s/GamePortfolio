using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonClick : MonoBehaviour
{
    public Image image;
    // unity functions
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    // custom functions
    public void PopUpUI(){
        
    }
    public void ChangeUIImage(){
        image.sprite = Resources.Load<Sprite>("");
    }
}
