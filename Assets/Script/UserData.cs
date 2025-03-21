using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class UserData
{
    public string UserName;
    public int Balance;
    public int Cash;

    public UserData(string UserName, int Balance, int Cash)
    {
        this.UserName = UserName;
        this.Balance = Balance;
        this.Cash = Cash;
    }

   
}
