using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerCallbacksSample : MonoBehaviourPunCallbacks
{
    // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log($"{newPlayer.NickName}({newPlayer.ActorNumber})が参加しました");
    }

    // 他プレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log($"{otherPlayer.NickName}({otherPlayer.ActorNumber})が退出しました");
    }
}