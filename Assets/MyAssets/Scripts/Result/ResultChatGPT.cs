using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AAA.OpenAI;
using Photon.Pun;
using TMPro;

public class ResultChatGPT : MonoBehaviour
{
    private const string TextKey = "TEXT";
    
    private ChatGPTConnection _chatGptConnection;

    [SerializeField]
    private TextMeshPro _textMeshPro;
    
    IEnumerator Start()
    {
        _chatGptConnection = new ChatGPTConnection();
        _chatGptConnection.RequestAsync(GetText());
        yield return new WaitForSeconds(5);
        //_textMeshPro.text = $"結果は...{_chatGptConnection._messageList[0]}";
    }
    
    private string GetText() 
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties[TextKey] is string text) ? text : "";
    }
}
