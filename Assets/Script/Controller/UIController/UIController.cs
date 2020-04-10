using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : Controller
{

    public Player player;
    public Text text;

    public Image image;

    void UI_Target()
    {

        if (player.target!=null)
        {
            //text.text = player.target.StrName;
        }
        else
        {
            image.gameObject.SetActive(false);
        }
    }


    void Start()
    {

        text = image.GetComponent<Text>();
    }

    void Update()
    {
        UI_Target();

    }
}
