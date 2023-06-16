using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardInfo : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _cardText;

        public int CardNum;

        public string CardText
        {
            //ここで今カードが推せるか助詞のカードが推せるかの判定をする
            get
            {
                _cardText.text = "";
                return _cardText.text;
            }
        }
    }
}
