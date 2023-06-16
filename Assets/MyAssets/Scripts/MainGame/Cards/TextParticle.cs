using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class TextParticle : MonoBehaviour,ISendable
    {
        [SerializeField]
        private TextMeshPro _particleText;
        
        public string ReceiveText()
        {
            return _particleText.text;
        }
    }
}
