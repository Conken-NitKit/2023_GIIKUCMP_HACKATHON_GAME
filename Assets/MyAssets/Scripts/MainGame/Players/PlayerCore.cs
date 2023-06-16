using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Scripts.MainGame.Cards;
using Assets.MyAssets.Scripts.MainGame.GameManagers;
using Assets.MyAssets.Scripts.MainGame.Items;
using Photon.Pun;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Assets.MyAssets.Scripts.MainGame.Players
{
    public class PlayerCore : MonoBehaviour
    {
        private PlayerParameter _parameter;

        private ReactiveDictionary<ItemType, bool> _useItems = new ReactiveDictionary<ItemType, bool>();
        public IObservable<DictionaryReplaceEvent<ItemType, bool>> ReplaceObservable => _useItems.ObserveReplace();
        
        private ReactiveProperty<bool> _click = new BoolReactiveProperty();
        public IReadOnlyReactiveProperty<bool> ClickMouse { get {return _click; } }

        [SerializeField]
        private TextManager _textManager;

        void Start()
        {
            _parameter.IsHappyTeam = PhotonNetwork.IsMasterClient;
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetMouseButtonUp(0))
                .DistinctUntilChanged()
                .Subscribe(x => _click.Value = x);

            ClickMouse.Subscribe(_ =>
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //Rayの長さ
                float maxDistance = 10;
                var hits = Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
                foreach (var hit in hits)
                {
                    Debug.Log(hit.transform.name);
                    var itemBase = hit.transform.GetComponent<ItemBase>();
                    if (itemBase != null)
                    {
                        itemBase.ActivateEffect();
                        ChangeItemBool(itemBase.ItemType, false);
                    }
                    _textManager.AddText(hit.transform.GetComponent<ISendable>()?.ReceiveText());
                }
            });
        }
        
        void ChangeItemBool(ItemType key, bool value)
        {
            _useItems[key] = value;
        }
    }
}
