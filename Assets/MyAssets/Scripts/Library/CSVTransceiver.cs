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
        Debug.Log("�f�[�^��M�J�n�E�E�E");
        var request = UnityWebRequest.Get("https://script.google.com/macros/s/" + accessKey + "/exec");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("�f�[�^��M�����I");
                foreach (var record in records)
                {
                    Debug.Log("Name�F" + record.name + "�AResult�F" + record.result + "�AEnemy:" + record.enemy);
                }
            }
            else
            {
                Debug.LogError("�f�[�^��M���s�F" + request.responseCode);
            }
        }
        else
        {
            Debug.LogError("�f�[�^��M���s" + request.result);
        }
    }

    private IEnumerator PostData(string address, string username, string result, string enemy)
    {
        Debug.Log("�f�[�^���M�J�n�E�E�E");
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
                Debug.Log("�f�[�^���M�����I");
                foreach (var record in records)
                {
                    Debug.Log("Name�F" + record.name + "�AResult�F" + record.result + "�AEnemy:" + record.enemy);
                }
            }
            else
            {
                Debug.LogError("�f�[�^���M���s" + request.responseCode);
            }
        }
        else
        {
            Debug.Log("�f�[�^���M���s" + request.result);
        }
    }
}
