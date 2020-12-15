using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn() {
        switch (this.gameObject.name) {
            case "EnterRBtn":
                SceneManager.LoadScene("EnterRoom");
                break;
            case "MakeRBtn":
                SceneManager.LoadScene("MakeRoom");
                break;
            case "BackHomeBtn":
                SceneManager.LoadScene("Home");
                break;
        }
    }
}
