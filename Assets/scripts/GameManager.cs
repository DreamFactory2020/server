using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    Color[] ColorSet = {
        new Color(255,0,0),
        new Color(255,127,0),
        new Color(248,225,0),
        new Color(0,248,0),
        new Color(0,246,199),
        new Color(0,111,248),
        new Color(101,0,247),
        new Color(255,0,236)
    };

    public Button GameStartBtn;
    public GameObject StartWall1;
    public GameObject StartWall2;
    public GameObject StartWall3;
    public GameObject StartWall4;
    public Text StartText;
    public Text NumOfPlayersText;
    public static GameManager instance{
        get{
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }
            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }
    private static GameManager m_instance;

    public List<PlayerScript> Players = new List<PlayerScript>();
    public PlayerScript MyPlayer;

    public GameObject playerPrefab; // 생성할 플레이어 캐릭터 프리팹
    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-2500, 550, 0f), Quaternion.identity, 0).GetComponent<PlayerScript>();
        GameStartBtn.interactable = false;
    }

    // 주기적으로 자동 실행되는, 동기화 메서드
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 오브젝트라면 쓰기 부분이 실행됨
        if (stream.IsWriting)
        {
        }
        else
        {
        }
    }

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NumOfPlayersText.text = PhotonNetwork.CurrentRoom.PlayerCount + "/8";
        if (PhotonNetwork.CurrentRoom.PlayerCount == 8)
            GameStartBtn.interactable = true;
    }

    public void GameStart() {
        StartWall1.SetActive(false);
        StartWall2.SetActive(false);
        StartWall3.SetActive(false);
        StartWall4.SetActive(false);
        StartText.gameObject.SetActive(true);
        Destroy(StartText, 2);
    }

    public void InitGame() {
        SetPlayerColor();
        SetNote();
    }

    void SetPlayerColor() { //플레이어 컬러 랜덤 배정
        Color[] tempColor = ColorSet;
        ShuffleArray(tempColor);
        for (int index = 0; index < Players.Count; index++) {
            Players[index].SetColor(tempColor[index]);
        }
    }

    public static void ShuffleArray<Color>(Color[] array)
    {
        int random1;
        int random2;

        Color tmp;

        for (int index = 0; index < array.Length; ++index)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;
        }
    }

    void SetNote()  // 쪽지 내용 초기화, 위치 초기화
    {
        
    }

    [ContextMenu("정보")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
        }
    }
}
