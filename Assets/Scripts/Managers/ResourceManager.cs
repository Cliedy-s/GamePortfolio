using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    List<GameObject> rcOthers = new List<GameObject>();
    List<GameObject> rcPlayer = new List<GameObject>();

    public List<GameObject> RcOthers { get => rcOthers; set => rcOthers = value; }
    public List<GameObject> RcPlayer { get => rcPlayer; set => rcPlayer = value; }

    // Custom function
    public void LoadOthersByFolder(string path)
    {
        GameObject[] objects = Resources.LoadAll<GameObject>(path);
        foreach (GameObject item in objects)
        {
            rcOthers.Add(item);
        }
    }
    public void LoadPlayerByFolder(string path)
    {
        GameObject[] objects = Resources.LoadAll<GameObject>(path);
        foreach (GameObject item in objects)
        {
            rcPlayer.Add(item);
        }

    }

    public GameObject GetOther(string name){ 
        return RcOthers.Find((x)=> x.name.Equals(name));
    }
    public GameObject GetPlayer(string name){ 
        return RcPlayer.Find((x)=> x.name.Equals(name));
    }
}
