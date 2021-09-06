using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] float time = 80f;
    [SerializeField] float speed = 1f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }

        time -= Time.deltaTime * speed;
        string minutes = ((int)time / 60).ToString("00"); // 150s / 60 = 2
        string seconds = ((int)time % 60).ToString("00"); // 150s % 60 = 30
        textMeshPro.text = minutes + ":" + seconds;
        if (time <= 0f)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
