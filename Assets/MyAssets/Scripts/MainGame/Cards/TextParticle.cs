using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextParticle : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _particleText;
    
    public string Particle {
        get
        {
            //ここで今カードが推せるか助詞のカードが推せるかの判定をする
            if (true)
            {
                return _particleText.text;
            }
            
        } }
}
