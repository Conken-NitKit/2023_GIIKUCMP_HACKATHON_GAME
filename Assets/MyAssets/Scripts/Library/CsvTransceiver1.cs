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
                    Debug.Log("Name�F" + record.name + "�AResult�F" + record.result + "�AResult:" + record.result);
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

    private IEnumerator PostData(string happyPlayerName, string badPlayerName, string text, string winHappy)
    {

        string address = happyPlayerName + "," + badPlayerName + "," + text + "," + winHappy;

        Debug.Log("�f�[�^���M�J�n�E�E�E");
        var form = new WWWForm();
        form.AddField("address", address);

        var request = UnityWebRequest.Post("https://script.google.com/macros/s/" + accessKey + "/exec", form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("�f�[�^���M�����I");
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
