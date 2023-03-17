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
//********                     Creator: Oscar Castronuño                       Date: 03-17-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtLives;
    [SerializeField] private int enemyPower = 1;
    [SerializeField] private int speed = 33;

    private Rigidbody enemyRb;
    private GameObject playerTarget;
    private GameObject targetFormation;
    private GameObject targetMinion = null;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerTarget = GameObject.Find("Player");
        targetFormation = playerTarget.transform.GetChild(1).gameObject;

        UpdateTxtLives();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetMinion != null)
        {
            CalcMovement();
        }
        else
        {   // find new target
            FindTarget();
        }
    }

    void FixedUpdate()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        enemyRb.MovePosition(enemyRb.position + movement * speed * Time.deltaTime);
    }

    private void CalcMovement()
    {
        if (transform.position.x - targetMinion.transform.position.x > 2)
            movement.x = -1;
        else if (transform.position.x - targetMinion.transform.position.x < -2)
            movement.x = 1;
        else
            movement.x = 0;

        if (transform.position.z - targetMinion.transform.position.z > 2)
            movement.z = -1;
        else if (transform.position.z - targetMinion.transform.position.z < -2)
            movement.z = 1;
        else
            movement.z = 0;

        movement.y = transform.position.y;
    }

    private void FindTarget()
    {
        int randomChild = Random.Range(0, playerTarget.GetComponent<PlayerBehaviour>().GetLivesPlayer());
        targetMinion = targetFormation.transform.GetChild(randomChild).gameObject;
    }

    private void UpdateTxtLives()
    {
        txtLives.text = "" + enemyPower;
    }

}
