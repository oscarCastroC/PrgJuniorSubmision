using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
//********                     Creator: Oscar Castronuño                       Date: 03-19-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class MenuControler : MonoBehaviour
{
    public GameObject p_Menu;
    public GameObject p_Settings;
    public GameObject p_Hall;

    public void SetMenuActive()
    {
        ActiveMenus(true, false, false);
    }

    public void SetSettingsActive()
    {
        ActiveMenus(false, true, false);
    }

    public void SetHallsActive()
    {
        ActiveMenus(false, false, true);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1); // game
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0); // Menu
    }

    private void ActiveMenus(bool menuB, bool settingsB, bool hallB)
    {
        p_Menu.gameObject.SetActive(menuB);
        p_Settings.gameObject.SetActive(settingsB);
        p_Hall.gameObject.SetActive(hallB);

        updateTextLanguage();
    }

    public void updateTextLanguage()
    {
        GameObject[] allTxt;
        allTxt = GameObject.FindGameObjectsWithTag("textTag");

        foreach (GameObject currentText in allTxt)
        {
            //Debug.Log("currentText: " + currentText.gameObject.name);
            currentText.GetComponent<txt_controler>().chosseLanguage();
        }
    }
}
