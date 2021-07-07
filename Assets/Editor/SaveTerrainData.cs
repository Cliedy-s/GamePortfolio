using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class SaveTerrainData : EditorWindow
{
    static string filename;
    static List<string> buildinglist;

    [MenuItem("Custom/Tool")]
    static void Init(){
        SaveTerrainData window = (SaveTerrainData)EditorWindow.GetWindow(typeof(SaveTerrainData));
        window.Show();
    }

    [MenuItem("Custom/Save")]
    static void Save()
    {
        Debug.Log("Save Terrain Data");

        filename = EditorUtility.SaveFilePanel("Export BuildingInfo", "", filename, "csv");
        if(filename.Equals("")){
            Debug.Log("파일 이름을 입력해주세요");
            return;
        }
        GameObject [] objs = GameObject.FindGameObjectsWithTag("Building");
        if(objs.Length <= 0){
            Debug.Log("Building이 Hierachy에 존재하지 않습니다.");
            return;
        }
        
        string datas = string.Empty;
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("index,name,posx,posy,posz");
            for (int i = 0; i < objs.Length; i++)
            {
                datas = (i + 1).ToString();
                datas += ",";
                datas += objs[i].name;
                datas += ",";

                if(IsParent(objs[i].transform))
                    datas+= "-1";
                else
                {
                    int? usindex = GetParentObjectIndex(objs[i].transform);
                    if(usindex.HasValue)
                    {
                        datas += usindex.Value.ToString();
                    }
                }

                datas += ",";

                datas += objs[i].transform.position.x;
                datas += ",";
                datas += objs[i].transform.position.y;
                datas += ",";
                datas += objs[i].transform.position.z;
                datas += ",";
                datas += GetResourceName(objs[i].name);

                writer.WriteLine(datas);

                buildinglist.Add(datas);
                datas = string.Empty;
            }
            writer.Close();
        }


    }

    public static bool IsParent(Transform tr)
    {
        if(tr.parent.gameObject.name == "Building")
            return true;
        return false;
    }
    public static int? GetParentObjectIndex(Transform tr)
    {
        GameObject obj = tr.parent.gameObject;
        foreach (string one in buildinglist)
        {
            string[] lineData = one.Split(',');

            ushort index = ushort.Parse(lineData[0]);
            string name = lineData[1];
            int parentIndex = int.Parse(lineData[2]);
            int xpos = int.Parse(lineData[3]);
            int ypos = int.Parse(lineData[4]);
            int zpos = int.Parse(lineData[5]);

            if(obj.name == name && 
                Mathf.Approximately(xpos, obj.transform.position.x) &&
                Mathf.Approximately(ypos, obj.transform.position.y) &&
                Mathf.Approximately(zpos, obj.transform.position.z))
                return index;
        }
        return null;
    }

    static void GetChildTransform(Transform tr){
        if(tr.childCount != 0){
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform chtr = tr.GetChild(i);
                Debug.Log(chtr.gameObject.name);
                GetChildTransform(chtr);
            }
        }
    }

    [MenuItem("CSV/ImportBuildingCSV")]
    static void LoadBuilding(){
        filename = EditorUtility.OpenFilePanel("Open BuildingInfo", "", "csv");

        using(StreamReader sr = new StreamReader(filename)){
            sr.ReadLine();
            string data = string.Empty;

            while((data = sr.ReadLine()) != null){
                Debug.Log(data);
                
                string[] lineData = data.Split(',');

                ushort index = ushort.Parse(lineData[0]);
                string name = lineData[1];
                float xpos = float.Parse(lineData[2]);
                float ypos = float.Parse(lineData[3]);
                float zpos = float.Parse(lineData[4]);

                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(xpos, ypos, zpos);
            }
            sr.Close();
        }
    }

    public static string GetResourceName(string objname)
    {
        int n = objname.IndexOf('_');
        if(n == -1)
            return objname;

        string name = objname.Substring(0, n);
        return name;
    }

    static string inputData  = string.Empty;
    private int index = 0;
    private string[] option = new string[] {"Single", "Open Field", "Dungeon"};

    void OnGUI() {
        GUILayout.Label("Fill out filname nad press save button");
        inputData = EditorGUILayout.TextField("입력하세요 : ", inputData);
        index = EditorGUILayout.Popup(index, option);
        Debug.Log(index);

        GUILayoutOption[] opbuttons = new GUILayoutOption[2];
        opbuttons[0] = GUILayout.Height(30);
        opbuttons[1] = GUILayout.Width(150);

        if(GUILayout.Button("Test", opbuttons)){
            Debug.Log("Test버튼 눌림");
        }
    }


}
