using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField farmNameInputField;
    public int characterLimit = 10;
    public PlayerSo playerSo;
    public GameObject panel;
    public GameObject panel2;
    private void Start()
    {
        // Karakter s�n�r�n� ayarla
        farmNameInputField.characterLimit = characterLimit;
    }
    public void OnSubmitButtonClicked()
    {
        string playerName = nameInputField.text;
        string farmName = farmNameInputField.text;
        playerSo.playerName = playerName;
        playerSo.farmName= farmName;
        panel.SetActive(false);
        panel2.SetActive(true);
    }
    public void _Play() 
    {
        
    
    }
    public void QuitGame()
    {
        // Oyundan ��k�� yap
        Application.Quit();
    }
}
