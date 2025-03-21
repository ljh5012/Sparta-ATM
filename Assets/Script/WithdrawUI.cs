using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WithdrawUI : PopupBank
{
    PopupBank popupBank;

    public Button backButton;
    public Button with1Btn;
    public Button with2Btn;
    public Button with3Btn;
    public Button withdraw;

    public TMP_InputField inputField;

    public void Start()
    {
        backButton.onClick.AddListener(OnClickAtmUI);
        //with1Btn.onClick.AddListener(OnClickWith1);
        //with2Btn.onClick.AddListener(OnClickWith2);
        //with3Btn.onClick.AddListener(OnClickWith3);
        //withdraw.onClick.AddListener(OnClickWithdraw);
    }

    //public void OnClickWith1()
    //{
    //    if (GameManager.Instance.userData.Balance >= 10000)
    //    {
    //        GameManager.Instance.userData.Balance -= 10000;
    //        GameManager.Instance.userData.Cash += 10000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}
    //public void OnClickWith2()
    //{
    //    if (GameManager.Instance.userData.Balance >= 30000)
    //    {
    //        GameManager.Instance.userData.Balance -= 30000;
    //        GameManager.Instance.userData.Cash += 30000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}
    //public void OnClickWith3()
    //{
    //    if (GameManager.Instance.userData.Balance >= 50000)
    //    {
    //        GameManager.Instance.userData.Balance -= 50000;
    //        GameManager.Instance.userData.Cash += 50000;
    //        GameManager.Instance.UpdateUI();
    //    }
    //}

    public void OnClickWithdraw()
    {
        int inputAmount;
        if (int.TryParse(inputField.text, out inputAmount))
        {
            Withdraw(inputAmount);
            Debug.Log("Ãâ±Ý");
        }

    }

    public void Withdraw(int amount)
    {
        if (GameManager.Instance.userData.Balance >= amount)
        {
            GameManager.Instance.userData.Balance -= amount;
            GameManager.Instance.userData.Cash += amount;
            GameManager.Instance.UpdateUI();
            GameManager.Instance.SaveUserData();
        }
        else
        {
            warningUI.SetActive(true);
        }
    }
}
