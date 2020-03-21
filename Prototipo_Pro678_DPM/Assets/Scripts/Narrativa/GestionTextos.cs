using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class GestionTextos : MonoBehaviour
{
    public GameObject goPanel;
    public Text txtText;
    public float TiemposTexto = 3;

    //Martiiiin
    string[] strConversation1 = new string[] {TextResources.One_1, TextResources.One_2, TextResources.One_3, "NULL"};
    string[] strConversation2 = new string[] { TextResources.Two_1, TextResources.Two_2, TextResources.Two_3, "NULL" };
    string[] strConversation3 = new string[] { TextResources.Three_1, TextResources.Three_2, TextResources.Three_3, "NULL" };
    string[] strConversation4 = new string[] { TextResources.Four_1, TextResources.Four_2, TextResources.Four_3, "NULL" };

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

    bool bTalking;
    float fTimer;

    

    void Start()
    {
        fTimer = TiemposTexto;
    }

    void Update()
    {
        Timer();
        Triggers();
        
        

        if (bTalking)
        {
            goPanel.SetActive(true);
        }
        else
        {
            goPanel.SetActive(false);
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

    private void Triggers()
    {
        //Martiiiin
        if (bTrigger1)
        {
            bTalking = true;

            txtText.text = strConversation1[number1];

            if((number1 + 1) >= strConversation1.Length)
            {
                
                fTimer = TiemposTexto;
                bTalking = false;
                bTrigger1 = false;
            }
        }
        if (bTrigger2)
        {
            bTalking = true;

            txtText.text = strConversation2[number2];

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

            txtText.text = strConversation3[number3];

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

            txtText.text = strConversation4[number4];

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
