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

    UserDataList userList;

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

        userList = LoadAllUsers();
        UpdateUI();
    }
        
    public void Start()
    {
        //if (PlayerPrefs.HasKey("UserName") == false)
        //{
        //    userData = new UserData("LeeJaeHyu", 50000, 100000, "ID", 1111);
        //    //userList.users.Add(userData); // ����Ʈ�� �߰�
        //    //SaveAllUsers(userList);

        //}
        //else
        //{
        //    userData = userList.users[0]; // ������ UI�� null ������ �� ����
        //}
        UserDataList list = LoadAllUsers();

        if (list.users.Count == 0)
        {
            userData = new UserData("LeeJaeHyu", 50000, 100000, "ID", 1111);
            list.users.Add(userData);
            SaveAllUsers(list);
        }
        UpdateUI();
        
    }

    public void UpdateUI()
    {
        if (userData == null) return;

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

    //public void SaveUserData()
    //{
    //    PlayerPrefs.SetString("UserName", userData.UserName);
    //    PlayerPrefs.SetInt("Balance", userData.Balance);
    //    PlayerPrefs.SetInt("Cash", userData.Cash);
    //    PlayerPrefs.SetString("UserId", userData.UserId);
    //    PlayerPrefs.SetInt("Password", userData.Password);
    //    PlayerPrefs.Save();

    //    Debug.Log("������ ����, Balance = " + userData.Balance + " Cash = " + userData.Cash);
    //}

    //public void LoadUserData()
    //{
    //    if (PlayerPrefs.HasKey("Balance"))
    //    {
    //        string UserName = PlayerPrefs.GetString("UserName");
    //        int Balance = PlayerPrefs.GetInt("Balance");
    //        int Cash = PlayerPrefs.GetInt("Cash");
    //        string UserId = PlayerPrefs.GetString("UserId");
    //        int Password = PlayerPrefs.GetInt("Password");

    //        userData = new UserData(UserName, Balance, Cash, UserId, Password);


    //    }


    //}

    public void SaveAllUsers(UserDataList userList)
    {
        string json = JsonUtility.ToJson(userList);
        PlayerPrefs.SetString("AllUsers", json);
        PlayerPrefs.Save();
    }

    public UserDataList LoadAllUsers()
    {
        //if (PlayerPrefs.HasKey("AllUsers"))
        //{
        //    string json = PlayerPrefs.GetString("AllUsers");
        //    UserDataList list = JsonUtility.FromJson<UserDataList>(json);

        //    if (list.users == null)
        //        list.users = new List<UserData>();

        //    return list;
        //}
        //else
        //{
        //    return new UserDataList(); // �� ����Ʈ ��ȯ
        //}
        if (PlayerPrefs.HasKey("AllUsers"))
        {
            string json = PlayerPrefs.GetString("AllUsers");

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("AllUsers ���尪�� ��� �ֽ��ϴ�.");
                return new UserDataList();
            }

            UserDataList list = JsonUtility.FromJson<UserDataList>(json);

            if (list == null)
            {
                Debug.LogError("JSON �Ľ� ����: UserDataList�� null�Դϴ�.");
                return new UserDataList(); // ��������� �� ��ü ��ȯ
            }

            if (list.users == null)
                list.users = new List<UserData>();

            return list;
        }
        else
        {
            return new UserDataList(); // ���� ���� �� �� ����Ʈ
        }
    }


}
