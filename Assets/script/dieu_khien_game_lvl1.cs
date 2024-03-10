using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieu_khien_game_lvl1 : MonoBehaviour
{
    public Text[] button_list;
    private string player;

    public GameObject gameOver;
    public Text gameOverText;

    private int moveCount;

    public GameObject restartButton;
    public GameObject X_or_O;

    public GameObject playerX;
    public GameObject playerO;
    public Button button_X;
    public Button button_y;

    private void Awake()
    {
        gameOver.SetActive(false);
        SetGame();
        moveCount = 0;
        restartButton.SetActive(false);
    }
    void SetGame()
    {
        for (int i = 0; i < button_list.Length; i++)
        {
            button_list[i].GetComponentInParent<x_o_level1>().SetGameControler(this);
        }
    }
    public void SetStart(string startingSide)
    {
        player = startingSide;
        if (player == "X")
        {
            playerX.SetActive(false);
            playerO.SetActive(true);
        }
        else
        {
            playerX.SetActive(true);
            playerO.SetActive(false);
        }
        StartGame();
    }
    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);
        X_or_O.SetActive(false);
    }
    public string GetPlayer()
    {
        return player;
    }
    public void EndTurn()
    {
        moveCount++;
        if (button_list[0].text == player && button_list[1].text == player && button_list[2].text == player)
        {
            GameOver(player);
        }
        else if (button_list[3].text == player && button_list[4].text == player && button_list[5].text == player)
        {
            GameOver(player);
        }
        else if (button_list[6].text == player && button_list[7].text == player && button_list[8].text == player)
        {
            GameOver(player);
        }
        else if (button_list[0].text == player && button_list[3].text == player && button_list[6].text == player)
        {
            GameOver(player);
        }
        else if (button_list[1].text == player && button_list[4].text == player && button_list[7].text == player)
        {
            GameOver(player);
        }
        else if (button_list[2].text == player && button_list[5].text == player && button_list[8].text == player)
        {
            GameOver(player);
        }
        else if (button_list[2].text == player && button_list[4].text == player && button_list[6].text == player)
        {
            GameOver(player);
        }
        else if (button_list[0].text == player && button_list[4].text == player && button_list[8].text == player)
        {
            GameOver(player);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            Change();
        }

    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOver("Hoa !");
        }
        else
        {
            SetGameOver(winningPlayer + "Thang!");
        }
        restartButton.SetActive(true);
    }
    void Change()
    {
        player = (player == "X") ? "O" : "X";

        if (player == "X")
        {
            playerX.SetActive(false);
            playerO.SetActive(true);
        }
        else
        {
            playerX.SetActive(true);
            playerO.SetActive(false);
        }
    }
    void SetGameOver(string value)
    {
        gameOver.SetActive(true);
        gameOverText.text = value;
    }
    public void RestartGame()
    {
        Application.LoadLevel("Play1");
        /*   moveCount = 0;
           gameOver.SetActive(false);
           restartButton.SetActive(false);
           SetPlayerButton(true);
           X_or_O.SetActive(true);

           for (int i=0;i<button_list.Length;i++)
           {
               button_list[i].text = "";
           }*/
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < button_list.Length; i++)
        {
            button_list[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
    void SetPlayerButton(bool toggle)
    {
        button_X.interactable = toggle;
        button_y.interactable = toggle;
    }
}
