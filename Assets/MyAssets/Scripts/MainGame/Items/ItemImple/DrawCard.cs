namespace Assets.MyAssets.Scripts.MainGame.Items.ItemImple
{
    public class DrawCard : ItemBase
    {
        public override void ActivateEffect()
        {
            _cardDisPlay.ReDrawAllCard();
        }
    }
}
