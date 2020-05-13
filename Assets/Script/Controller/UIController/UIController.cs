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


    [SerializeField]
    private Button[] skillslot;
    float cooltime;
    Image slot1,slot2,slot3;
   

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

    void UI_SkillSlot()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)&&player.skillbook[0].is_Available)
        {
            ButtonOnClick(0);
            StartCoroutine(CoolTime(slot1, player.skillbook[0].CoolDown));
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && player.skillbook[1].is_Available)
        {
            ButtonOnClick(1);
            StartCoroutine(CoolTime(slot2, player.skillbook[1].CoolDown));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && player.skillbook[2].is_Available)
        {
            ButtonOnClick(2);
            StartCoroutine(CoolTime(slot3, player.skillbook[2].CoolDown));
        }
    }
    
    private void ButtonOnClick(int btn)
    {
        skillslot[btn].onClick.Invoke();
    }
    IEnumerator CoolTime(Image btn,float cool)
    {
        cooltime = cool;
        while(cool>0.0f)
        {
            cooltime -= Time.deltaTime;
            btn.fillAmount = 1-(cooltime/cool);
            if (cooltime <= 0)
            {
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }



    void Start()
    {

        slot1 = skillslot[0].image;
        //slot2 = skillslot[1].image;
        //slot3 = skillslot[2].image;

        slot1.sprite = player.skillbook[0].Icon;
        //slot2.sprite = player.skillbook[1].Icon;
        //slot3.sprite = player.skillbook[2].Icon;
    }
    void Update()
    {
        UI_Target();
        UI_Status();
        UI_SkillSlot();

    }
}
