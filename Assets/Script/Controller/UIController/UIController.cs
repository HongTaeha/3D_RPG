using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : Controller
{

    public Player player;
    public Image image;
    public Text text;

    void UI_Target()
    {

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


    void Start()
    {
        text = image.GetComponentInChildren<Text>();
    }

    void Update()
    {
        UI_Target();

    }
}
