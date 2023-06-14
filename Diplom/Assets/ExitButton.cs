using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameObject ExitMenu;
    public void CallConfirmMenu() 
    {
        ExitMenu.SetActive(true);
    }  
}
