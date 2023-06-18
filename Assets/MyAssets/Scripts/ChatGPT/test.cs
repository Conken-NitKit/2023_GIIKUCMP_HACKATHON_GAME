using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AAA.OpenAI;


public class test : MonoBehaviour
{
    private ChatGPTConnection _chatGptConnection;
    void Start()
    {
        _chatGptConnection = new ChatGPTConnection();
        _chatGptConnection.RequestAsync("破滅の時が訪れた。");
        //Debug.Log(_chatGptConnection._messageList[0]);
    }

}
