using Photon.Pun;
using TMPro;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEditor;
using UniRx;

namespace Assets.MyAssets.Scripts.MainGame.GameManagers
{
    public class TextManager : MonoBehaviourPunCallbacks
    {
        private string _previousText;
        private ReactiveProperty<string> _currentText;
        public IReadOnlyReactiveProperty<string> CurrentText { get { return _currentText; } }
        
        private Hashtable _hashtable = new Hashtable();

        private const string TextKey = "TEXT";

        private TextMeshPro _textBoard;

        public void hoge()
        {
            if (PhotonNetwork.IsMasterClient) {
                _textBoard = PhotonNetwork.InstantiateRoomObject("TextBoard", new Vector3(0f,1f,0f), Quaternion.identity).GetComponent<TextMeshPro>();
            }
            else
            {
                _textBoard = GameObject.FindWithTag("TextBoard").GetComponent<TextMeshPro>();
            }
            Debug.Log($"TEXTBOARD{_textBoard}");
            _hashtable[TextKey] = "";
            PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);
        }
    
        private string GetText() 
        {
            return (PhotonNetwork.CurrentRoom.CustomProperties[TextKey] is string text) ? text : "";
        }

        public void AddText(string text)
        {
            _hashtable[TextKey] = _textBoard.text + text;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);
            _hashtable.Clear();
        }

        public void ResetPreviousText()
        {
            _hashtable[TextKey] = _previousText;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);
            _hashtable.Clear();
        }

        public void UpDatePreviousText()
        {
            _previousText = _textBoard.text;
            Debug.Log(_previousText);
        }
        
        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
            // 更新されたルームのカスタムプロパティのペアをコンソールに出力する
            foreach (var prop in propertiesThatChanged) {
                switch (prop.Key)
                {
                    case TextKey:
                        Debug.Log($"参考 : 「{(string)prop.Value}」");
                        _textBoard.text = (string)prop.Value;
                        break;
                }
            }
        }
    }
}
