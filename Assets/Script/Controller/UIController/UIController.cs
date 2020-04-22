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
    public Image T_Hp;
    public Image T_Mp;

    void UI_Target()
    {
        Text text = image.GetComponentInChildren<Text>();
        if (player.target!=null)
        {
            Text t_hp = T_Hp.GetComponentInChildren<Text>();
            Text t_mp = T_Mp.GetComponentInChildren<Text>();


            image.gameObject.SetActive(true);
            
            T_Hp.fillAmount = player.target.HP / player.target.Max_HP;
            t_hp.text = string.Format("HP {0}/{1}", player.target.HP, player.target.Max_HP);
            T_Mp.fillAmount = player.target.MP / player.target.Max_MP;
            t_mp.text = string.Format("MP {0}/{1}", player.target.MP, player.target.Max_MP);
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
