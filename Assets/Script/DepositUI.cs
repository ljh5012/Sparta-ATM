using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepositUI : PopupBank
{
    PopupBank popupBank;

    public Button backButton;
    public Button depo1Btn;
    public Button depo2Btn;
    public Button depo3Btn;
    public Button deposit;

    public TMP_InputField inputField;

    public void Start()
    {
        backButton.onClick.AddListener(OnClickAtmUI);
        //depo1Btn.onClick.AddListener(()=>Deposit(10000));
        //depo2Btn.onClick.AddListener(OnClickDepo2);
        //depo3Btn.onClick.AddListener(OnClickDepo3);
        //deposit.onClick.AddListener(OnClickDeposit);
    }

    //public void OnClickDepo1()
    //{
    //    if (GameManager.Instance.userData.Cash >= 10000)
    //    {
    //        GameManager.Instance.userData.Balance += 10000;
    //        GameManager.Instance.userData.Cash -= 10000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}

    //public void OnClickDepo2()
    //{
    //    if (GameManager.Instance.userData.Cash >= 30000)
    //    {
    //        GameManager.Instance.userData.Balance += 30000;
    //        GameManager.Instance.userData.Cash -= 30000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}

    //public void OnClickDepo3()
    //{
    //    if (GameManager.Instance.userData.Cash >= 50000)
    //    {
    //        GameManager.Instance.userData.Balance += 50000;
    //        GameManager.Instance.userData.Cash -= 50000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}

    public void OnClickDeposit()
    {
        int inputAmount;
        if (int.TryParse(inputField.text, out inputAmount))
        {
            Deposit(inputAmount);
            Debug.Log("ют╠щ");
        }

    }
    public void Deposit(int amount)
    {
        if (GameManager.Instance.userData.Cash >= amount)
        {
            GameManager.Instance.userData.Balance += amount;
            GameManager.Instance.userData.Cash -= amount;
            GameManager.Instance.UpdateUI();
            GameManager.Instance.SaveUserData();
            
        }
        else
        {
            warningUI.SetActive(true);
        }
    }
    
}

    

    

