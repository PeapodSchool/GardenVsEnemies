using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StarsCounter : MonoBehaviour
{

    [SerializeField] int starsAmount = 500;
    [SerializeField] TextMeshProUGUI starsText;

    public void AddStars(int amount)
    {
        starsAmount += amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = starsAmount.ToString();
    }

    public void SpendStars(int amount)
    {
        if (starsAmount >= amount)
        {
            starsAmount -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return starsAmount >= amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

}
