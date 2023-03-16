using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//**************************************************************************************************************************************************************//
//********                                                                                                                                              ********//
//********              #####  ##     #####  #####   ####    ####   ####    ##   #####    #####    ###   ######  #####                                  ********//
//********              ##     ##     ##     ##     ##   #    ##   ##  ##   ##  ##       ##       ## ##    ##    ##                                     ********//
//********              #####  ##     #####  #####  #####     ##   ##   ##  ##  ##  ##   ##      #######   ##    #####                                  ********//
//********                 ##  ##     ##     ##     ##        ##   ##    ## ##  ##   ##  ##      ##   ##   ##       ##                                  ********//
//********              #####  #####  #####  #####  ##       ####  ##      ###   #####    #####  ##   ##   ##    #####                                  ********//
//********                                                                                                                                              ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//********                     Creator: Oscar Castronuño                       Date: 03-16-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class QuestionPref : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionTxt;
    [SerializeField] private TextMeshProUGUI numATxt;
    [SerializeField] private TextMeshProUGUI numBTxt;
    private bool isNumA;                                    // isNumA = true (A correct), isNumA = false (B correct)
    private float result;
    private int nivel;                                      // ojo cambiar por la persistente

    void Start()
    {
        
    }

    public void CreateQuestion()
    {
        int firstNum;
        int secondtNum;
        int multiNumber = 1;

        //ojo getlevl
        // nivel = getlvl;
        while (nivel > 4)
        {   // 0: +, 1: -, 2: *, 3:/, 4: all
            if (nivel > 10)
            {
                nivel = nivel - 10;
                multiNumber = multiNumber + 20;
            }
            else
                nivel = nivel - 5;
        }

        if (nivel == 4)
            nivel = Random.Range(0, 4);

        firstNum = Random.Range(-100, 101) * multiNumber;
        secondtNum = Random.Range(-100, 101) * multiNumber;

        switch (nivel)
        {
            case 0:
                questionTxt.text = firstNum + " + " + secondtNum + " = ?";
                result = firstNum + secondtNum;
                break;
            case 1:
                questionTxt.text = firstNum + " - " + secondtNum + " = ?";
                result = firstNum - secondtNum;
                break;
            case 2:
                questionTxt.text = firstNum + " x " + secondtNum + " = ?";
                result = firstNum * secondtNum;
                break;
            case 3:
                questionTxt.text = firstNum + " / " + secondtNum + " = ?";
                result = firstNum / secondtNum;
                break;
        }

    }

    public void GetAnswerQ(string answer)
    {
        Debug.Log("Me ha tocado " + answer);
    }

}
