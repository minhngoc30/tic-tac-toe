using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieu_khien_nut : MonoBehaviour
{
    public void play_de()
    {
        Application.LoadLevel("1chon_level");
    }
    public void play_kho()
    {
        Application.LoadLevel("2chon_level");
    }
    public void play1()
    {
        Application.LoadLevel("Play1");
    }  
    public void play2()
    {
        Application.LoadLevel("Play2");
    }    
    public void setting()
    {
        Application.LoadLevel("setting");
    }    
    public void menu1()
    {
        Application.LoadLevel("1menu");
    }    
    public void menu2()
    {
        Application.LoadLevel("2menu");
    }    
}
