using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public LinkedList<PlayerScript> Players;
    Dictionary<int, string[]> noteData;
    //노트 유형1: 유저 A는 빨간색과 2칸 떨어져있다.
    //노트 유형2: 유저 A는 빨간색이 아니다.
    //노트 유형3: 유저A와 유저F는 3칸 떨어져있다.

    void Start()
    {
        noteData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData() { 
        
    }

    void Update()
    {
        
    }
}
