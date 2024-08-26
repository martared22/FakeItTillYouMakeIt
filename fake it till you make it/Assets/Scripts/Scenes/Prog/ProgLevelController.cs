using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class ProgLevelController : MonoBehaviour
{
    public int tempPoints = 1;
    public TextMeshProUGUI errorText;
    public TimerProg timer;
    public int timePoints;

    public bool isFree = false;

    void Start()
    {
        timer = FindObjectOfType<TimerProg>();
        errorText.text = "";
    }

    void Update()
    {
        GetTimerPoints();

        //GameManager.progPoints = tempPoints + timePoints;
    }

    public void GetFails()
    {
        StartCoroutine(ShowErrorMessage());
        if (tempPoints > 0)
        {
            tempPoints--;
        }
    }

    public void GetTimerPoints()
    {
        int timeLeftInSeconds = timer.SetPoints();

        if (timeLeftInSeconds >= 120)
        {
            timePoints = 1;
        }
        else
        {
            timePoints = 0;
        }
    }

    public void IsMallocFree()
    {
        if (isFree)
        {
            //GameManager.progPoints = tempPoints + timePoints + 3;
        }
    }

    private IEnumerator ShowErrorMessage()
    {
        errorText.text = "Incorrect key!";
        yield return new WaitForSeconds(1f);
        errorText.text = "";
    }
}
