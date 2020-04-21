using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : Controller
{

    public Player player;
    public Image image;
    public Image Hp;
    public Image Mp;

    void UI_Target()
    {
        Text text = image.GetComponentInChildren<Text>();
        if (player.target!=null)
        {
            
            image.gameObject.SetActive(true);
            text.text = player.target.StrName+" "+player.target.HP.ToString();
        }
        else
        {
            image.gameObject.SetActive(false);
        }
    }
    void UI_Status()
    {
        Text hp= Hp.GetComponentInChildren<Text>(); 
        Text mp = Mp.GetComponentInChildren<Text>();      

        Hp.fillAmount = player.HP / player.Max_HP;
        hp.text = string.Format("HP {0}/{1}", player.HP,player.Max_HP);
        Mp.fillAmount = player.MP / player.Max_MP;
        mp.text = string.Format("MP {0}/{1}", player.MP,player.Max_MP);

    }


    void Start()
    {

    }
    void Update()
    {
        UI_Target();
        UI_Status();

    }
}
