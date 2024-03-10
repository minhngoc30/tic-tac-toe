using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class x_o_level1 : MonoBehaviour
{
    public Button button;
    public Text X_O;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite UISprite;
    public Image X_O_img;

    private dieu_khien_game_lvl1 dieu_khien;

    // Start is called before the first frame update
    private void Start()
    {
        X_O_img= GetComponent<Image>();
    }
    public void SetSpace()
    {
        X_O.text = dieu_khien.GetPlayer();
        if(X_O.text=="X")
        {
            X_O_img.sprite = newSprite1;
            X_O_img.color=new Color(255, 255, 255, 255);
        }
        else if (X_O.text == "O")
        {
            X_O_img.sprite = newSprite2;
            X_O_img.color = new Color(255, 255, 255, 255);
        }
        else
        {
            X_O_img.sprite =UISprite;
            X_O_img.color = new Color(255, 255, 255, 130);
        }
        button.interactable = false;
        dieu_khien.EndTurn();
    }
   
    public void SetGameControler(dieu_khien_game_lvl1 controller)
    {
        dieu_khien = controller;
    } 
}
