using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void OnClicked()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Result");
    }
}
