using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dieu_khien_game : MonoBehaviour
{
    public Text[] button_list;
    private string player;

    public GameObject gameOver;
    public Text gameOverText;
    public Image imgGameover;
    public Sprite imgX, immgO, imghoa;

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
            button_list[i].GetComponentInParent<x_o>().SetGameControler(this);
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
        ok();
        for(int i=1;i<=91;i++)
        {
            if (moveCount >= 64)
            {
                 GameOver("draw");
            }
            else
            {
                Change();
            }
        }
    }
     void ok()
    {
        for (int i = 1; i <= 91; i++)
        {
            if (((i <= 15) || ((21 <= i && i <= 25)) || (31 <= i && i <= 35) || (41 <= i && i <= 45) || (51 <= i && i <= 55) || (61 <= i && i <= 65) || (71 <= i && i <= 75) || (81 <= i && i <= 85))
            && button_list[i].text == player && button_list[i + 1].text == player && button_list[i + 2].text == player && button_list[i + 3].text == player
            && ((button_list[i - 1].text == player && button_list[i + 4].text == player) || (button_list[i - 1].text == "" && button_list[i + 4].text == "")
            || (button_list[i - 1].text == player && button_list[i + 4].text == "") || (button_list[i - 1].text == "" && button_list[i + 4].text == player)))
            {
                GameOver(player);
                Debug.Log("ok1");
            }
            else if ((11 <= i && i <= 58) && button_list[i].text == player && button_list[i + 10].text == player && button_list[i + 20].text == player && button_list[i + 30].text == player
                && ((button_list[i - 10].text == player && button_list[i + 40].text == player) || (button_list[i - 10].text == "" && button_list[i + 40].text == "")
                || (button_list[i - 10].text == player && button_list[i + 40].text == "") || (button_list[i - 10].text == "" && button_list[i + 40].text == player)))
            {
                GameOver(player);
            }
            else if (((14 <= i && i <= 18) || (24 <= i && i <= 28) || (34 <= i && i <= 38) || (44 <= i && i <= 48) || (54 <= i && i <= 58))
            && button_list[i].text == player && button_list[i + 9].text == player && button_list[i + 18].text == player && button_list[i + 27].text == player
            && ((button_list[i - 9].text == player && button_list[i + 36].text == player) || (button_list[i - 9].text == "" && button_list[i + 36].text == "")
            || (button_list[i - 9].text == "" && button_list[i + 36].text == player) || (button_list[i - 9].text == player && button_list[i + 36].text == "")))
            {
                GameOver(player);
            }
            else if (((11 <= i && i <= 15) || (21 <= i && i <= 25) || (31 <= i && i <= 35) || (41 <= i && i <= 45) || (51 <= i && i <= 55))
            && button_list[i].text == player && button_list[i + 11].text == player && button_list[i + 22].text == player && button_list[i + 33].text == player
            && ((button_list[i - 11].text == player && button_list[i + 44].text == player) || (button_list[i - 11].text == "" && button_list[i + 44].text == "")
            || (button_list[i - 11].text == "" && button_list[i + 44].text == player) || (button_list[i - 11].text == player && button_list[i + 44].text == "")))
            {
                GameOver(player);
            }
        }
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
    void SetGameOver(string value)
    {
        gameOver.SetActive(true);
        gameOverText.text = value;
        if(value=="XThang!") imgGameover.sprite = imgX;
        if (value == "OThang!") imgGameover.sprite = immgO;
        if (value == "Hoa !") imgGameover.sprite = imghoa;

    }
    public void RestartGame()
    {
        Application.LoadLevel("Play2");
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
