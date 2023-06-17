using UnityEngine;

namespace Assets.MyAssets.Scripts.MainGame.Items.ItemImple
{
    public class ChangeText : ItemBase
    {
        public override void ActivateEffect()
        {
            _textManager.ResetPreviousText();
        }
    }
}
