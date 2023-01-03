using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public Image winnerImg;
    public void GameOver(string winnerName, Sprite winnerSprite)        
    {
        winnerText.text = "Winner Is: "+winnerName;
        winnerImg.sprite = winnerSprite;
        Time.timeScale = 0.5f;
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        winnerText.text = "";
        winnerImg.sprite = null;
        SceneManager.LoadScene("Game");
    }
}
