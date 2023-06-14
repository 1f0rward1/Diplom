using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuController : MonoBehaviour
{
    public void Resume() 
    {
        this.gameObject.SetActive(false);
    }
    public void ConfirmExit()
    {
        Application.Quit();
    }
}
