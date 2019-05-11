using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {
    public Button SingleBtn;


    public void SingleGame()
    {
        SceneManager.LoadScene("ChapterSelector");
    }

}
