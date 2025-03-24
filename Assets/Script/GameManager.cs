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
        //    //userList.users.Add(userData); // 리스트에 추가
        //    //SaveAllUsers(userList);

        //}
        //else
        //{
        //    userData = userList.users[0]; // 없으면 UI가 null 참조될 수 있음
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

    //    Debug.Log("데이터 저장, Balance = " + userData.Balance + " Cash = " + userData.Cash);
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
        //    return new UserDataList(); // 빈 리스트 반환
        //}
        if (PlayerPrefs.HasKey("AllUsers"))
        {
            string json = PlayerPrefs.GetString("AllUsers");

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("AllUsers 저장값이 비어 있습니다.");
                return new UserDataList();
            }

            UserDataList list = JsonUtility.FromJson<UserDataList>(json);

            if (list == null)
            {
                Debug.LogError("JSON 파싱 실패: UserDataList가 null입니다.");
                return new UserDataList(); // 방어적으로 새 객체 반환
            }

            if (list.users == null)
                list.users = new List<UserData>();

            return list;
        }
        else
        {
            return new UserDataList(); // 최초 실행 시 빈 리스트
        }
    }


}
