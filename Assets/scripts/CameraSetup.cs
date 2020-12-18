using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) {
            CinemachineVirtualCamera FollowCam = FindObjectOfType<CinemachineVirtualCamera>();
            FollowCam.Follow = transform;
            FollowCam.LookAt = transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
