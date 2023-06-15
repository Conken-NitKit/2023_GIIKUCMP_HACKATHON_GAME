using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class CardDB : MonoBehaviour
{
    [SerializeField]
    string _sheetID;
    [SerializeField]
    string _sheetName;

    private List<string> cardDBTexts = new List<string>();
    
    public void Start(){
        StartCoroutine(LoadGoogleSheet(_sheetName));     
    }
    
    IEnumerator LoadGoogleSheet(string sheetName){
        UnityWebRequest request = UnityWebRequest.Get($"https://docs.google.com/spreadsheets/d/{_sheetID}/gviz/tq?tqx=out:csv&sheet={sheetName}");
        yield return request.SendWebRequest();
        
        var httpError    = request.result == UnityWebRequest.Result.ProtocolError   ? true : false;
        var networkError = request.result == UnityWebRequest.Result.ConnectionError ? true : false;
        
        if (httpError || networkError)  {
            Debug.Log(request.error);
        }
        else{
            var convertArry = ConvertCSVtoJaggedArray(request.downloadHandler.text);
            foreach (var vector in convertArry)
            {
                foreach (var text in vector)
                {
                    if (!string.IsNullOrEmpty(text))cardDBTexts.Add(text);
                }
            }
        }
    }
    static string[][] ConvertCSVtoJaggedArray(string t)
    {
        var reader = new StringReader(t);
        reader.ReadLine();  //ヘッダ読み飛ばし
        var rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine();        // 一行ずつ読み込み
            var elements = line.Split(',');    // 行のセルは,で区切られる
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }

}
