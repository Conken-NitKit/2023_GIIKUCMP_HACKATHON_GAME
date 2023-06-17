using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;

[Serializable]
public class Records
{
    public Record[] records;
}

[Serializable]
public class Record
{
    public string address;
    public string name;
    public int result;
    public string created;
    public string updated;
    public string enemy;
    public int score;
}

public class CsvTransceiver1 : MonoBehaviour
{

    public string happyPlayerName;
    public string badPlayerName;
    public string text;
    public string winHappy;

    [SerializeField] private string accessKey;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GetData());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(PostData(happyPlayerName, badPlayerName, text, winHappy));
        }
    }

    private IEnumerator GetData()
    {
        Debug.Log("データ受信開始・・・");
        var request = UnityWebRequest.Get("https://script.google.com/macros/s/" + accessKey + "/exec");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("データ受信成功！");
                foreach (var record in records)
                {
                    Debug.Log("Name：" + record.name + "、Result：" + record.result + "、Result:" + record.result);
                }
            }
            else
            {
                Debug.LogError("データ受信失敗：" + request.responseCode);
            }
        }
        else
        {
            Debug.LogError("データ受信失敗" + request.result);
        }
    }

    private IEnumerator PostData(string happyPlayerName, string badPlayerName, string text, string winHappy)
    {

        string address = happyPlayerName + "," + badPlayerName + "," + text + "," + winHappy;

        Debug.Log("データ送信開始・・・");
        var form = new WWWForm();
        form.AddField("address", address);

        var request = UnityWebRequest.Post("https://script.google.com/macros/s/" + accessKey + "/exec", form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("データ送信成功！");
            }
            else
            {
                Debug.LogError("データ送信失敗" + request.responseCode);
            }
        }
        else
        {
            Debug.Log("データ送信失敗" + request.result);
        }
    }
}
