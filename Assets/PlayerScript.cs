using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV;
    public Text NickNameText;

    void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) { 
    
    }

}
