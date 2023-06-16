using TMPro;
using UnityEngine;
using Assets.MyAssets.Scripts.MainGame.GameManagers;

public class MessageTest : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField hoge;

    private TextManager _manager;

    public void SendMassage()
    {
        if (_manager == null)
        {
            _manager = GameObject.FindWithTag("GameManager").GetComponent<TextManager>();
        }
        _manager.AddText(hoge.text);
        hoge.text = "";
    }
}
