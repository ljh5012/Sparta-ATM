using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
        
    public GameObject atmUI;
    public GameObject depositUI;
    public GameObject withdrawUI;
    public GameObject warningUI;

    public GameManager gameManager;

    

    public void Start()
    {
        string UserName = GameManager.Instance.userData.UserName;
        int Balance = GameManager.Instance.userData.Balance;
        int Cash = GameManager.Instance.userData.Cash;

        
        OnClickAtmUI();
    }
    public void OnClickDepositUI()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(true);
        withdrawUI.SetActive(false);
    }

    public void OnClickWithdrawUI()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(false);
        withdrawUI.SetActive(true);
    }

    public void OnClickAtmUI()
    {
        atmUI.SetActive(true);
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
    }

    public void OnClickWarningOff()
    {
        warningUI.SetActive(false);
    }
}
