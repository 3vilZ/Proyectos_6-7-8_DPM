using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class GestionTextos : MonoBehaviour
{
    
    public GameObject goPanelNormal;
    public GameObject goPanelInteractive;
    public Button Button1;
    public Button Button2;
    public Button currentButton;
    public Text TextNormal;
    public Text TextInteractive;
    public Text TextButton1;
    public Text TextButton2;
    public float TiemposTexto = 3;

    //Martiiiin
    string[] strConversation1 = new string[] { TextResources.One_1, TextResources.One_2, TextResources.One_3, "NULL"};
    string[] strConversation2 = new string[] { TextResources.Two_1, TextResources.Two_2, TextResources.Two_3, "NULL" };
    string[] strConversation3 = new string[] { TextResources.Three_1, TextResources.Three_2, TextResources.Three_3, "NULL" };
    string[] strConversation4 = new string[] { TextResources.Four_1, "NULL" };

    string[] strInteraction1 = new string[] { TextResources.Int1_Title, TextResources.Int1_Ans1, TextResources.Int1_Ans2, "NULL" };

    //Martiiiin
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int number4 = 0;

    //Martiiiin
    public bool bTrigger1 = false;
    public bool bTrigger2 = false;
    public bool bTrigger3 = false;
    public bool bTrigger4 = false;
    public bool bTrigger5 = false;
    public bool bTrigger6 = false;
    public bool bTrigger7 = false;
    public bool bTrigger8 = false;
    public bool bTrigger9 = false;
    public bool bTrigger10 = false;
    public bool bTrigger11 = false;
    public bool bTrigger12 = false;
    public bool bTrigger13= false;
    public bool bTrigger14 = false;
    public bool bTrigger15 = false;



    bool bTalking;
    public bool bWillSelect;
    bool bSelecting;
    float fTimer;

    bool bButtonControl = true;
    

    void Start()
    {
        fTimer = TiemposTexto;
    }

    void Update()
    {
        Timer();
        Selections();
        Triggers();
        
        

        if (bTalking)
        {
            goPanelInteractive.SetActive(false);
            goPanelNormal.SetActive(true);
        }
        else if (bSelecting)
        {
            goPanelNormal.SetActive(false);
            goPanelInteractive.SetActive(true);
        }
        else
        {
            goPanelNormal.SetActive(false);
            goPanelInteractive.SetActive(false);
        }
    }

    private void Timer()
    {
        if (bTalking)
        {
            fTimer -= Time.deltaTime;

            if (fTimer <= 0)
            {
                //Martiiiin
                if (bTrigger1)
                {
                    number1++;
                }
                if (bTrigger2)
                {
                    number2++;
                }
                if (bTrigger3)
                {
                    number3++;
                }
                if (bTrigger4)
                {
                    number4++;
                }

                fTimer = TiemposTexto;
            }
        }
    }

    private void Selections()
    {
        if(bSelecting)
        {
            TextInteractive.text = strInteraction1[0];
            TextButton1.text = strInteraction1[1];
            TextButton2.text = strInteraction1[2];

            if(bButtonControl)
            {
                currentButton = Button1;
                currentButton.Select();
                bButtonControl = false;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (currentButton == Button1)
                {
                    currentButton = Button2;
                    currentButton.Select();
                    //EventSystem.current.SetSelectedGameObject(Button2.gameObject);
                }
                else
                {
                    currentButton = Button1;
                    currentButton.Select();
                    //EventSystem.current.SetSelectedGameObject(Button1.gameObject);
                }
            }
            currentButton.onClick.AddListener(ClickClick);
        }
    }

    private void ClickClick()
    {
        Debug.Log("wawawawawawawawa");
    }

    private void Triggers()
    {
        //Martiiiin
        if (bTrigger1)
        {
            bTalking = true;

            TextNormal.text = strConversation1[number1];

            if((number1 + 1) >= strConversation1.Length)
            {
                
                fTimer = TiemposTexto;
                bTalking = false;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger1 = false;
            }
        }
        if (bTrigger2)
        {
            bTalking = true;

            TextNormal.text = strConversation2[number2];

            if ((number2 + 1) >= strConversation2.Length)
            {
                
                fTimer = TiemposTexto;
                bTalking = false;
                bTrigger2 = false;
            }
        }
        if (bTrigger3)
        {
            bTalking = true;

            TextNormal.text = strConversation3[number3];

            if ((number3 + 1) >= strConversation3.Length)
            {

                fTimer = TiemposTexto;
                bTalking = false;
                bTrigger3 = false;
            }
        }
        if (bTrigger4)
        {
            bTalking = true;

            TextNormal.text = strConversation4[number4];

            if ((number4 + 1) >= strConversation4.Length)
            {

                fTimer = TiemposTexto;
                bTalking = false;
                bTrigger4 = false;
            }
        }
    }

    /*
    private void TextosMartin()
    {
        //CONVERSACION1
        strConversation1[0] = "0";
        strConversation1[1] = "1";
        strConversation1[2] = "2";

        //CONVERSACION2
        strConversation2[0] = "0";
        strConversation2[1] = "1";
        strConversation2[2] = "2";
    }
    */
}
