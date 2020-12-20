using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV;
    public SpriteRenderer SR;
    public Text NickNameText;

    GameManager GM;
    Color[] PlayerColors;

    void Start() {
        GM = GameManager.instance;
        GM.Players.Add(this);
    }

    void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public void SetColor(Color _color)
    {
        SR.color = _color;
    }

    void OnDestroy() {
        GM.Players.Remove(this);
    }
}
