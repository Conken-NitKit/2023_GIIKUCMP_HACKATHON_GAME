using Photon.Pun;
using TMPro;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEditor;

public class TextGene : MonoBehaviourPunCallbacks
{
    [SerializeField] 
    private TextMeshPro hoge;
    
    private Hashtable _hashtable = new Hashtable();

    private const string TextKey = "TEXT";

    private void Start()
    {
        _hashtable[TextKey] = "";
        PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);
    }
    
    private string GetText() 
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties[TextKey] is string text) ? text : "";
    }

    public void AddText(string text)
    {
        _hashtable[TextKey] += text;
        PhotonNetwork.CurrentRoom.SetCustomProperties(_hashtable);
        _hashtable.Clear();
    }
    
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
        // 更新されたルームのカスタムプロパティのペアをコンソールに出力する
        foreach (var prop in propertiesThatChanged) {
            switch (prop.Key)
            {
                case TextKey:
                    Debug.Log($"参考 : 「{(string)prop.Value}」");
                    hoge.text += (string)prop.Value;
                    break;
            }
        }
    }

}
