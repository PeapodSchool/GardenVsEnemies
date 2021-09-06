using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] int baseLives = 5;
    [SerializeField] int damage = 1;
    [SerializeField] TextMeshProUGUI textMeshPro;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        textMeshPro.text = lives.ToString();
    }

    public void TakeLive()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCounditions();
        }
    }

    public int GetLives() { return lives; }
}
