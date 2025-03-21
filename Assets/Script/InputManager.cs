using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;

    public void InputMoney(int input)
    {
        gameManager.userData.Balance += input;
    }
}
