using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class UserData
{
    public string UserName;
    public int Balance;
    public int Cash;
    public string UserId;
    public int Password;

    public UserData(string UserName, int Balance, int Cash, string UserId, int Password)
    {
        this.UserName = UserName;
        this.Balance = Balance;
        this.Cash = Cash;
        this.UserId = UserId;
        this.Password = Password;
    }

   
}
