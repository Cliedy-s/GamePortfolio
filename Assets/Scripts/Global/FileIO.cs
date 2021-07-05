using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Timeline;

public class FileIO : MonoBehaviour
{
    // unity functions
    void Start()
    {
        string path = $"{Application.dataPath}/Save";
        string filename = "Test.txt";
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string data = string.Empty;
        using(StreamWriter sr = new StreamWriter($"{path}/{filename}")){
            data += "가다나";
            sr.WriteLine(data);
            sr.Close();
        }

        // 문자열 => 바이트
        byte[] byData = Encoding.UTF8.GetBytes(data);
        // 바이트 저장 > 플랫폼에 영향 x
        File.WriteAllBytes($"{path}/{filename}", byData);
        
        byte[] byRead = File.ReadAllBytes($"{path}/{filename}");
        string readstring = Encoding.Default.GetString(byRead);

        Debug.Log(readstring);

        // 디렉토리
        string curDir = Directory.GetCurrentDirectory();
        Debug.Log(curDir);

        string[] files = Directory.GetFiles(curDir);
        foreach (string item in files)
        {
            Debug.Log(item);
        }
        
        //
        string[] subDir = Directory.GetDirectories(curDir);
        foreach (string one in subDir)
        {
            Debug.Log(one);
        }

        // 파일 이동
        // File.Move($"{path}/{filename}", $"{path}/Test22.txt");

        // File.Delete($"{path}/{filename}");

    }
    void Update()
    {
        
    }
    // custom functions
}
