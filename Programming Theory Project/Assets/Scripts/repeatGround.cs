using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
//********                     Creator: Oscar Castronuño                       Date: 03-15-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class repeatGround : MonoBehaviour
{
    public GameObject QuestionPref1;
    public GameObject QuestionPref2;
    [SerializeField] private float speed = 10;
    private Vector3 startPos;
    private float repeatHeight;
    private Vector3 QuestionPref2Pos = new Vector3(0, 0, 150);
    private int outOfBoundsZ = -200;

    // Start is called before the first frame update
    void Start()
    {
        repeatHeight = (GetComponent<BoxCollider>().size.z / 4)* transform.localScale.z;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround(); 
        MoveQuestions();
    }

    private void MoveGround()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < startPos.z - repeatHeight)
        {
            transform.position = startPos;
        }
    }

    private void MoveQuestions()
    {
        QuestionPref1.transform.Translate(Vector3.back * Time.deltaTime * speed);
        QuestionPref2.transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (QuestionPref1.transform.position.z < outOfBoundsZ)
        {
            resetQuestion(0);
        }

        if (QuestionPref2.transform.position.z < outOfBoundsZ)
        {
            resetQuestion(1);
        }
    }

    public void resetQuestion(int questionActive)
    {   // int questionActive: 0 - questoinPref1, 1 - QuestionPref2
        if (questionActive == 0)
        {
            QuestionPref1.transform.position = QuestionPref2Pos;
            // ojo obtener el script del objeto y resetar la pregnta
        }
        else
        {
            QuestionPref2.transform.position = QuestionPref2Pos;
            // ojo obtener el script del objeto y resetar la pregnta
        }
    }

}
