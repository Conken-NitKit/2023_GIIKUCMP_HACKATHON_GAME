using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Networking;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardDB : MonoBehaviour
    {
        [SerializeField]
        string _sheetID;

        private List<string> cardDBTexts = new List<string>();

        void Start()
        {
            StartCoroutine(LoadGoogleSheet("FAIRY_TALE"));
        }

        public IEnumerator LoadGoogleSheet(string sheetName){
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

        public string[] DrawCards(int drawNum)
        {
            Debug.Log("hoge");
            string[] drawCards = new string[drawNum];
            for (int i = 0; i < drawNum; i++)
            {
                drawCards[i] = cardDBTexts[Random.Range(0, cardDBTexts.Count - 1)];
            }

            return drawCards;
        }
    }
}

