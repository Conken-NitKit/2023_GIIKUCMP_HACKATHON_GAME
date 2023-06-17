using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    
    private const string TextKey = "TEXT";
    
    void Start()
    {
        _textMeshPro = PhotonNetwork.InstantiateRoomObject("TextBoard", new Vector3(0f, 2f, 0f), Quaternion.identity).GetComponent<TextMeshPro>();
        _textMeshPro.text = GetText();
        Debug.Log(GetText());
    }
    
    private string GetText() 
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties[TextKey] is string text) ? text : "";
    }
}
