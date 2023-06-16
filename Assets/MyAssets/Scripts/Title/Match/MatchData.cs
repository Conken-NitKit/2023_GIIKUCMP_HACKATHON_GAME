using UniRx;
using UnityEngine;

namespace MyAssets.Scripts.Title
{
    public class MatchData : IMatchData {
        private StringReactiveProperty _playerName;
        [field: SerializeField] public IReadOnlyReactiveProperty<string> PlayerName { get; set; }
        private IntReactiveProperty _roomNum = new IntReactiveProperty ();
        [field: SerializeField] public IReadOnlyReactiveProperty<int> RoomNum { get; set; }
    }
}
