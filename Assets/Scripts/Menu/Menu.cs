using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _url = "https://yandex.ru/games/developer?name=NikolayTapchenko";

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void UrlOpen()
    {
        Application.ExternalEval("window.open(\"" + _url + "\")");
    }
}