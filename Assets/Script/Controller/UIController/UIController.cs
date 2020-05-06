using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : Controller
{

    public Player player;
    public GameObject Target;
    public Image T_ICON;
    public Image T_HP;
    public Image T_MP;

    public Image Player_status;
    public Image HP;
    public Image MP;

    void UI_Target()
    {
        if (player.target!=null)
        {
            
            Target.SetActive(true);
            T_ICON.sprite = player.target.icon;

            T_HP.fillAmount= player.target.status.HP / player.target.status.Max_HP;
            T_MP.fillAmount = player.target.status.MP / player.target.status.Max_MP;

            Text t_hp = T_HP.GetComponentInChildren<Text>();
            Text t_mp = T_MP.GetComponentInChildren<Text>();
            t_hp.text = string.Format("HP {0}/{1}", player.target.status.HP, player.target.status.Max_HP);
            t_mp.text = string.Format("MP {0}/{1}", player.target.status.MP, player.target.status.Max_MP);
           
        }
        else
        {
            Target.SetActive(false);
        }
    }
    void UI_Status()
    {

        Player_status.sprite = player.icon;
        Text hp= HP.GetComponentInChildren<Text>(); 
        Text mp = MP.GetComponentInChildren<Text>();
        
        HP.fillAmount = player.status.HP / player.status.Max_HP;
        hp.text = string.Format("HP {0}/{1}", player.status.HP,player.status.Max_HP);
        MP.fillAmount = player.status.MP / player.status.Max_MP;
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
