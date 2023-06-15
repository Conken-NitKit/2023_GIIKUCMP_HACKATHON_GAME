using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardInfo : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _cardText;
        
        public string CardText { get { return _cardText.text;  } }
    }
}
