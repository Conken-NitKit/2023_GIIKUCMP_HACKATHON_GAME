using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardInfo : MonoBehaviour , ISendable
    {
        [SerializeField]
        private TextMeshPro _cardText;

        public int CardNum;

        public string ReceiveText()
        {
            return _cardText.text;
        }
    }
}
