using UniRx;

namespace MyAssets.Scripts.Title
{
    public class MatchData : IMatchData {
        private StringReactiveProperty _playerName;
        public IReadOnlyReactiveProperty<string> PlayerName { get; set; }
        private IntReactiveProperty _roomNum = new IntReactiveProperty ();
        public IReadOnlyReactiveProperty<int> RoomNum { get; set; }

        public MatchData(string playerName)
        {
            _playerName = new StringReactiveProperty(playerName);
        }
    }
}
