using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UserData userData;

    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;

    private bool IsSave;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    

      
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadUserData();
    }
        
    public void Start()
    {
        if(PlayerPrefs.HasKey("UserName")==false)
        userData = new UserData("LeeJaeHyu" , 50000, 100000);
        UpdateUI();
        
    }

    public void UpdateUI()
    {
        if (userNameText != null)
        {
            userNameText.text = userData.UserName;
        }

        if (balanceText != null)
        {
            balanceText.text = string.Format("{0:N0}", userData.Balance);
        }

        if(cashText != null)
        {
            cashText.text = string.Format("{0:N0}", userData.Cash);
        }
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("UserName",userData.UserName);
        PlayerPrefs.SetInt("Balance",userData.Balance);
        PlayerPrefs.SetInt("Cash",userData.Cash);
        PlayerPrefs.Save();

        Debug.Log("데이터 저장, Balance = " + userData.Balance + " Cash = " + userData.Cash);
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("Balance"))
        {
            string UserName = PlayerPrefs.GetString("UserName");
            int Balance = PlayerPrefs.GetInt("Balance");
            int Cash = PlayerPrefs.GetInt("Cash");

            userData = new UserData(UserName, Balance, Cash);

            
        }
        
        
    }
     
}
