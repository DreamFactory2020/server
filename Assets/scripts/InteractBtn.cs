using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractBtn : MonoBehaviour
{
    private Button thisBtn;

    void Start()
    {
        Interact_Disposal.PlayerGetClosed += TurnBtnOnAndOff;
        thisBtn = GetComponent<Button>();
    }

    private void TurnBtnOnAndOff(bool isOn) {
        thisBtn.interactable = isOn;
    }

    private void OnDestroy() {
        Interact_Disposal.PlayerGetClosed -= TurnBtnOnAndOff;
    }
}
