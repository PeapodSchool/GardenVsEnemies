using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] int starCost = 100;
    [SerializeField] int starsToEarn = 2;

    public int GetStarCost() { return starCost; }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarsCounter>().AddStars(starsToEarn);
    }
}
