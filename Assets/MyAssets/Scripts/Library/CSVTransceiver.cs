using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;

public class CSVTransceiver : MonoBehaviour
{
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
        public string result;
        public string created;
        public string updated;
        public string enemy;
    }

    [SerializeField] private string accessKey;

    public string address;
    public string name;
    public string result;
    public string enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GetData());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(PostData(address, name, result, enemy));
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
                    Debug.Log("Name：" + record.name + "、Result：" + record.result + "、Enemy:" + record.enemy);
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

    private IEnumerator PostData(string address, string username, string result, string enemy)
    {
        Debug.Log("データ送信開始・・・");
        var form = new WWWForm();
        form.AddField("address", address);
        form.AddField("name", username);
        form.AddField("result", result);
        form.AddField("enemy", enemy);

        var request = UnityWebRequest.Post("https://script.google.com/macros/s/" + accessKey + "/exec", form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("データ送信成功！");
                foreach (var record in records)
                {
                    Debug.Log("Name：" + record.name + "、Result：" + record.result + "、Enemy:" + record.enemy);
                }
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
