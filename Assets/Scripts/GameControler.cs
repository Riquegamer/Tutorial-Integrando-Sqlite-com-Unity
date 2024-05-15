using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControler : MonoBehaviour
{

    public static int totalScore;

    public static GameControler instance;

    [SerializeField]
    private GameObject gameOver;

    public Text scoreText;

    public static SelecaoSkin playerSkin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
    }


    void Start()
    {
        if (scoreText != null) { GameControler.instance.UpdateScoreText(); }
    }


    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = totalScore.ToString();
        }
    }

    public void SkinMenu() 
    {
        //skinUI.SetActive(true);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        ResetScore();
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void skinChange(SelecaoSkin skin) 
    {
        playerSkin = skin;
    }

    public void ResetScore()
    {
        totalScore = 0;
        UpdateScoreText();
    }
}
