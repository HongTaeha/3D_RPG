
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

    public Toggle T_Auto;
    public GameObject Inven;
    Inventory inven;
    public GameObject UI_Dead;
    public GameObject UI_Skillslot;
    [SerializeField]
    public class Slot
    {
        public Button bt;
        public Image bi { get { return bt.image; } set { bt.image = value; } }
        public int bnum;
        public string tag;
    }
    public List<Slot> lst = new List<Slot>();
    

    void Start()
    {
        Button[] bts = UI_Skillslot.GetComponentsInChildren<Button>();
        int i = 0;
        foreach(Button button in bts)
        {
            Slot tmp = new Slot();
            tmp.bt = button;
            tmp.bnum = i;
            lst.Add(tmp);
            i++;
        }
        if(player.skillbook.Count>0)
            for (int j=0;j<player.skillbook.Count;j++)
            {
                lst[j].bi.sprite = player.skillbook[j].Icon;
                player.skillbook[j].Slot = lst[j].bi;
                lst[j].tag = "Skill";
            }
        

        inven = Inven.GetComponentInChildren<Inventory>();
    }
    void Update()
    {
        UI_Target();
        UI_Status();
        UI_SkillSlot();
        Toggled();
        if (Input.GetKeyDown(KeyCode.I))
            if (Inven.activeSelf)
                Inven.SetActive(false);
            else
                Inven.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
            Equipment();
        if (Time.timeScale == 0)
        {
            UI_Dead.SetActive(true);
        }

    }
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
        for(int i=1;i<=lst.Count;i++)
        {
            if(Input.GetKeyDown(i.ToString()))
            {
                ButtonOnClick(i-1);
            }
        }
    }    
    void ButtonOnClick(int btn)
    {
        if (player.skillbook.Count > btn)
        {
            lst[btn].bt.onClick.Invoke();
        }
    }
    void Toggled()
    {
        if (T_Auto.isOn)
        {
            player.is_Automatic = true;
            T_Auto.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/trollnest_onbtn");
        }
        else
        {
            player.is_Automatic = false;
            T_Auto.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/trollnest_offbtn");
        }
    }
   
    void Equipment()
    {

    }

    public void cleanup()
    {
        player.inven.sortInven();
        inven.cleanup();
    }
    
    public void UseSlot(int num)
    {
        
    }
}
