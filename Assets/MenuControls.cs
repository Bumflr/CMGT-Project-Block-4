using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameManager gm => FindObjectOfType<GameManager>();

    private GameObject firstButtonSelected;
    GameObject lastSelected;

    public void SetFirstButton(GameObject defaultButton)
    {
        firstButtonSelected = defaultButton;

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }

    
    public void OnClick_Resume()
    {
        //MenuManager.OpenMenu(Menu.PAUSE_SCREEN, MenuManager.CheckMenu());
        PauseController.Resume();
    }

    //You can only use MenuManager.OpenMenu() if you are already within a menu, if you don't it will fuck up, which I need to change but I'll do that LATER

    public void OnClick_Options()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, MenuManager.CheckMenu());
    }

    public void OnClick_Continue()
    {
        //gm.Restart();
    }


}
