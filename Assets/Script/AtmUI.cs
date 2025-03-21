using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmUI : PopupBank
{
    public Button depositUIButton;
    public Button withdrawUIButton;

    public void Start()
    {
        depositUIButton.onClick.AddListener(OnClickDepositUI);
        withdrawUIButton.onClick.AddListener(OnClickWithdrawUI);
    }
}
