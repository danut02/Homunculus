using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class xpText : MonoBehaviour
{
    public TMP_Text xpTextContent;

    public void Update()
    {
        xpTextContent.text = $"{Player.Instance.getXp()}";
    }
}
