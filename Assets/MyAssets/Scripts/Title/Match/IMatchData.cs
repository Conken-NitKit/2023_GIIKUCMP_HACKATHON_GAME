using UniRx;

namespace MyAssets.Scripts.Title
{
    public interface IMatchData {
        IReadOnlyReactiveProperty<string> PlayerName { get; set; }
        IReadOnlyReactiveProperty<int> RoomNum { get; set; }
    }
}
