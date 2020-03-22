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
    string[] strConversation2 = new string[] { TextResources.Two_1, TextResources.Two_2, "NULL" };
    string[] strConversation3 = new string[] { TextResources.Three_1, TextResources.Three_2, TextResources.Three_3, "NULL" };
    string[] strConversation4 = new string[] { TextResources.Four_1, "NULL" };
    string[] strConversation5 = new string[] { TextResources.Five_1, TextResources.Five_2, "NULL" };
    string[] strConversation6 = new string[] { TextResources.Six_1, "NULL" };
    string[] strConversation7 = new string[] { TextResources.Seven_1, TextResources.Seven_2, TextResources.Seven_3, "NULL" };
    string[] strConversation8 = new string[] { TextResources.Eight_1,  "NULL" };
    string[] strConversation9 = new string[] { TextResources.Nine_1, TextResources.Nine_2, TextResources.Nine_3, "NULL" };
    string[] strConversation10 = new string[] { TextResources.Ten_1,  "NULL" };
    string[] strConversation11 = new string[] { TextResources.Eleven_1, TextResources.Eleven_2, TextResources.Eleven_3, TextResources.Eleven_4, TextResources.Eleven_5, TextResources.Eleven_6, TextResources.Eleven_7, "NULL" };
    string[] strConversation12 = new string[] { TextResources.Twelve_3, TextResources.Twelve_2, TextResources.Twelve_3, "NULL" };
    string[] strConversation13 = new string[] { TextResources.Thirteen_1, TextResources.Thirteen_2, TextResources.Thirteen_3, "NULL" };
    string[] strConversation14 = new string[] { TextResources.Fourteen_1, TextResources.Fourteen_2, TextResources.Fourteen_3, "NULL" };
    string[] strConversation15 = new string[] { TextResources.Fiveteen_1, TextResources.Fiveteen_2, TextResources.Fiveteen_3, "NULL" };

    string[] strInteraction1 = new string[] { TextResources.Int1_Title, TextResources.Int1_Ans1, TextResources.Int1_Ans2, "NULL" };

    //Martiiiin
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int number4 = 0;
    int number5 = 0;
    int number6 = 0;
    int number7 = 0;
    int number8 = 0;
    int number9 = 0;
    int number10 = 0;
    int number11 = 0;
    int number12 = 0;
    int number13 = 0;
    int number14 = 0;
    int number15 = 0;
    

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
                if (bTrigger5)
                {
                    number5++;
                }
                if (bTrigger6)
                {
                    number6++;
                }
                if (bTrigger7)
                {
                    number7++;
                }
                if (bTrigger8)
                {
                    number8++;
                }
                if (bTrigger9)
                {
                    number9++;
                }
                if (bTrigger10)
                {
                    number10++;
                }
                if (bTrigger11)
                {
                    number11++;
                }
                if (bTrigger12)
                {
                    number12++;
                }
                if (bTrigger13)
                {
                    number13++;
                }
                if (bTrigger14)
                {
                    number14++;
                }
                if (bTrigger15)
                {
                    number15++;
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                bTrigger11 = true;
                bSelecting = false;
            }
        }
    }

    private void ClickClick()
    {
        Debug.Log("wawawawawawawawa");
        bSelecting = false;
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
                bTalking = false;
                fTimer = TiemposTexto;

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
                bTalking = false;
                fTimer = TiemposTexto;
                

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }
                bTrigger2 = false;
            }
        }
        if (bTrigger3)
        {
            bTalking = true;

            TextNormal.text = strConversation3[number3];

            if ((number3 + 1) >= strConversation3.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;
                

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }
                bTrigger3 = false;
            }
        }
        if (bTrigger4)
        {
            bTalking = true;

            TextNormal.text = strConversation4[number4];

            if ((number4 + 1) >= strConversation4.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;
                

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }
                bTrigger4 = false;
            }
        }
        if (bTrigger5)
        {
            bTalking = true;

            TextNormal.text = strConversation5[number5];

            if ((number5 + 1) >= strConversation5.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger5 = false;
            }
        }
        if (bTrigger6)
        {
            bTalking = true;

            TextNormal.text = strConversation6[number6];

            if ((number6 + 1) >= strConversation6.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger6 = false;
            }
        }
        if (bTrigger7)
        {
            bTalking = true;

            TextNormal.text = strConversation7[number7];

            if ((number7 + 1) >= strConversation7.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger7 = false;
            }
        }
        if (bTrigger8)
        {
            bTalking = true;

            TextNormal.text = strConversation8[number8];

            if ((number8 + 1) >= strConversation8.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger8 = false;
            }
        }
        if (bTrigger9)
        {
            bTalking = true;

            TextNormal.text = strConversation9[number9];

            if ((number9 + 1) >= strConversation9.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger9 = false;
            }
        }
        if (bTrigger10)
        {
            bTalking = true;

            TextNormal.text = strConversation10[number10];

            if ((number10 + 1) >= strConversation10.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger10 = false;
            }
        }
        if (bTrigger11)
        {
            bTalking = true;

            TextNormal.text = strConversation11[number11];

            if ((number11 + 1) >= strConversation11.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger11 = false;
            }
        }
        if (bTrigger12)
        {
            bTalking = true;

            TextNormal.text = strConversation12[number12];

            if ((number12 + 1) >= strConversation12.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger12 = false;
            }
        }
        if (bTrigger13)
        {
            bTalking = true;

            TextNormal.text = strConversation13[number13];

            if ((number13 + 1) >= strConversation13.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger13 = false;
            }
        }
        if (bTrigger14)
        {
            bTalking = true;

            TextNormal.text = strConversation6[number14];

            if ((number14 + 1) >= strConversation14.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger14 = false;
            }
        }
        if (bTrigger15)
        {
            bTalking = true;

            TextNormal.text = strConversation15[number15];

            if ((number15 + 1) >= strConversation15.Length)
            {
                bTalking = false;
                fTimer = TiemposTexto;

                if (bWillSelect)
                {
                    bSelecting = true;
                    bWillSelect = false;
                }

                bTrigger15 = false;
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
