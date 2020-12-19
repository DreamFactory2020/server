using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    public Text ConnectText;
    public InputField Name;
    public InputField RoomName;
    public Button SearchRBtn;
    public Button BackHomeBtn;


    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;    //게임버전
        PhotonNetwork.ConnectUsingSettings();   //마스터서버 접속 시도
        SearchRBtn.interactable = false;
        ConnectText.text = "마스터 서버 접속 중...";

        Name.characterLimit = 6;
        Name.onValueChanged.AddListener(
            (word) => Name.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", ""));
    }

    public override void OnConnectedToMaster()//마스터서버 접속 성공시 자동 실행
    {
        SearchRBtn.interactable = true;
        ConnectText.text = "온라인";
    }

    public override void OnDisconnected(DisconnectCause cause)//마스터서버 접속 실패시 자동 실행
    {
        SearchRBtn.interactable = false;
        ConnectText.text = "오프라인. 재접속 시도...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect() { //룸 접속 시도
        SearchRBtn.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            if (RoomName.text == string.Empty || Name.text == string.Empty)
            {
                ConnectText.text = "이름을 입력해주세요.";
                SearchRBtn.interactable = true;
            }
            else
            {
                ConnectText.text = "룸에 접속 중...";
                PhotonNetwork.JoinRoom(RoomName.text);//
            }
        }   
        else {
            ConnectText.text = "오프라인 마스터 서버 재접속 중...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void Create() {  //방 생성
        SearchRBtn.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            if (RoomName.text == string.Empty || Name.text == string.Empty)
            {
                ConnectText.text = "이름을 입력해주세요.";
                SearchRBtn.interactable = true;
            }
            else
            {
                ConnectText.text = "룸에 접속 중...";
                PhotonNetwork.CreateRoom(RoomName.text, new RoomOptions { MaxPlayers = 8 });
            }
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message) //룸 참가 실패시 자동 실행
    {
        ConnectText.text = "방 없음";
        SearchRBtn.interactable = true;
    }

    public override void OnJoinedRoom() //룸 참가 성공 시 자동 실행
    {
        ConnectText.text = "방참가 성공";
        PhotonNetwork.LocalPlayer.NickName = Name.text;
        PhotonNetwork.LoadLevel("Game");    //모든 참가자가 Game씬을 로드한다.
    }
    public void Disconnect()    //메인창으로 돌아가기
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }
}
