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
            Text T_Name = image.GetComponentInChildren<Text>();

            image.gameObject.SetActive(true);


            T_Name.text=player.target.status.StrName;
            T_Hp.fillAmount = player.target.status.HP / player.target.status.Max_HP;
            t_hp.text = string.Format("HP {0}/{1}", player.target.status.HP, player.target.status.Max_HP);
            T_Mp.fillAmount = player.target.status.MP / player.target.status.Max_MP;
            t_mp.text = string.Format("MP {0}/{1}", player.target.status.MP, player.target.status.Max_MP);
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
        

        Hp.fillAmount = player.status.HP / player.status.Max_HP;
        hp.text = string.Format("HP {0}/{1}", player.status.HP,player.status.Max_HP);
        Mp.fillAmount = player.status.MP / player.status.Max_MP;
        mp.text = string.Format("MP {0}/{1}", player.status.MP,player.status.Max_MP);             

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
