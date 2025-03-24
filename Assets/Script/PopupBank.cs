using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
        
    public GameObject atmUI;
    public GameObject depositUI;
    public GameObject withdrawUI;
    public GameObject warningUI;
    public GameObject loginUI;
    public GameObject popupUI;
    public GameObject signupUI;

    public GameManager gameManager;

    public Button loginBtn;
    public Button signupBtn;
    public Button cancelBtn;
    public Button signup2Btn;

    public TMP_InputField IdInputField;
    public TMP_InputField signupIdInputField;
    public TMP_InputField PwInputField;
    public TMP_InputField signupPwInputField;
    public TMP_InputField signupPw2InputField;
    public TMP_InputField nameInputField;

    bool isID;
    bool isPW;

    



    public void Start()
    {
        
            string UserName = GameManager.Instance.userData.UserName;
            int Balance = GameManager.Instance.userData.Balance;
            int Cash = GameManager.Instance.userData.Cash;
            string UserId = GameManager.Instance.userData.UserId;
            int Password = GameManager.Instance.userData.Password;
        

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

    public void PopupLogin()
    {
        popupUI.SetActive(true);
        loginUI.SetActive(false);
        GameManager.Instance.UpdateUI();
    }

    public void OnLoginButtonClicked()
    {
        string inputId = IdInputField.text;
        string inputPwText = PwInputField.text;
        int inputPw;

        if (!int.TryParse(inputPwText, out inputPw))
        {
            Debug.Log("비밀번호는 숫자로 입력해야 합니다.");
            return;
        }

        UserDataList userList = GameManager.Instance.LoadAllUsers();

        if (userList == null || userList.users == null)
        {
            Debug.LogError("유저 목록이 존재하지 않습니다.");
            return;
        }

        foreach (UserData user in userList.users)
        {
            if (user.UserId == inputId && user.Password == inputPw)
            {
                GameManager.Instance.userData = user;
                Debug.Log("로그인 성공!");
                PopupLogin();
                return;
            }
        }

        Debug.Log("로그인 실패: ID 또는 비밀번호가 틀렸습니다.");

        //string inputId = IdInputField.text;
        //string inputPwtext = PwInputField.text;
        //int inputPw;
        //string correctId = GameManager.Instance.userData.UserId;
        //int correctPw = GameManager.Instance.userData.Password;

        //if (int.TryParse(inputPwtext, out inputPw))
        //{
        //    //UserDataList userList = GameManager.Instance.LoadAllUsers();

        //    //foreach (UserData user in userList.users)
        //    //{
        //    //    if (user.UserId == inputId && user.Password == inputPw)
        //    //    {
        //    //        GameManager.Instance.userData = user; // 현재 유저 설정
        //    //        Debug.Log("로그인 성공!");
        //    //        PopupLogin();
        //    //        return;
        //    //    }
        //    //}
        //    UserData userdata = GameManager.Instance.userData;

        //    if (inputId == correctId && inputPw == correctPw)
        //    {
        //        isID = true;
        //        isPW = true;
        //        Debug.Log("로그인 성공");
        //        PopupLogin(); // 로그인 성공 시 팝업 열기
        //    }
        //    else
        //    {
        //        isID = false;
        //        isPW = false;
        //        Debug.Log("로그인 실패: ID 불일치");
        //    }
        //}
    }


    public void OnclickSiguUp()
    {
        loginUI.SetActive(false);
        signupUI.SetActive(true);
        
    }

    public void OnclickSignUpOff()
    {
        loginUI.SetActive(true);
        signupUI.SetActive(false);
    }

    public void SignUp()
    {
        string signupId = signupIdInputField.text;
        string name = nameInputField.text;
        int signupPw;
        string signupPwText = signupPwInputField.text;
        int signupPw2;
        string signupPw2Text = signupPw2InputField.text;

        if (int.TryParse(signupPwText, out signupPw) && int.TryParse(signupPw2Text, out signupPw2))
        {
            if(signupPw != signupPw2)
            {
                Debug.Log("비밀번호가 일치하지 않습니다.");
                return;
            }


            

            // 새 사용자 추가
            //UserData newUser = new UserData(name, 50000, 100000, signupId, signupPw);
            UserData newUser = new UserData(name, 50000, 100000, signupId, signupPw);
            // 유저 리스트 로드
            UserDataList userList = GameManager.Instance.LoadAllUsers();
            //  중복 ID 검사
            foreach (UserData user in userList.users)
            {
                if (user.UserId == signupId)
                {
                    Debug.Log("이미 존재하는 ID입니다.");
                    return; // 회원가입 막기
                }
            }
            userList.users.Add(newUser);

            // 저장
            GameManager.Instance.SaveAllUsers(userList);

            Debug.Log("회원가입 완료 및 UserData 적용됨");

            signupUI.SetActive(false);
            loginUI.SetActive(true);
            
            GameManager.Instance.UpdateUI();
            
        }

    }
}
