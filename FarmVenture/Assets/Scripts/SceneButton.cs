using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneButton : MonoBehaviour
{
    public string sceneName;
    public GameObject panel;
    public GameObject panel1;
    public void LoadScene()
    {
        // Belirtilen sahneyi yükle
        SceneManager.LoadScene(sceneName);
    }
    public void Settings()
    {
        panel.SetActive(false);
        panel1.SetActive(true);

    }
    public void QuitGame()
    {
        // Oyundan çýkýþ yap
        Application.Quit();
    }
}
