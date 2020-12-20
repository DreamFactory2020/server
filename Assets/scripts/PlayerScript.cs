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
    public Animator AN;

    GameManager GM;
    Color[] PlayerColors;

    public float speed;
    private JoyStick joystick;

    void Start() {
        GM = GameManager.instance;
        GM.Players.Add(this);
    }

    void Awake()
    {
        joystick = GameObject.FindObjectOfType<JoyStick>();
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

    void FixedUpdate()
    {
        if (PV.IsMine) {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                AN.SetBool("walk", true);
                MoveControl();
            }
            else
            {
                AN.SetBool("walk", false);
            }
        }
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += upMovement;
        transform.position += rightMovement;
        if (joystick.Horizontal > 0)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
    }
}
