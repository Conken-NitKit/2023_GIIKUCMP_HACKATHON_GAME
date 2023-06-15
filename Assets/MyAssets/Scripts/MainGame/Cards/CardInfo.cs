using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardInfo : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _cardText;

        public string CardText
        {
            //ここで今カードが推せるか助詞のカードが推せるかの判定をする
            get
            {
                return _cardText.text;
            }
        }
    }
}
