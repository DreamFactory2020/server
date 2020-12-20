using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameBtn : MonoBehaviour
{
    private Button thisBtn;

    void Start()
    {
        thisBtn = GetComponent<Button>();
    }

    private void TurnBtnOnAndOff(bool isOn)
    {
        thisBtn.interactable = isOn;
    }
}
