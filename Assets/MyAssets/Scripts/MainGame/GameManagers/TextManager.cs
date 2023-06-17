using Photon.Pun;
using TMPro;
using UnityEngine;
using ExitGames.Client.Photon;
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

        private const string TextBoardTag = "TextBoard";

        private TextMeshPro _textBoard;

        [SerializeField]
        private MainGameManager _mainGameManager;

        public void InitTextBoard()
        {
            Debug.Log("InitTextBoard");
            if (_mainGameManager == null) _mainGameManager = GetComponent<MainGameManager>();
            _textBoard = GameObject.FindWithTag(TextBoardTag).GetComponent<TextMeshPro>();
            _hashtable[TextKey] = "";
            PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);

            _mainGameManager.ChooseCardText.Subscribe(_ =>
            {
                if (!_mainGameManager.ChooseCardText.Value)
                {
                    UpDatePreviousText();
                }
            });
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
