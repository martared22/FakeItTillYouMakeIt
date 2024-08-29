using System;
using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IoQuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public LogicGates logicGates;
    public ActivationSwitch activatableSwitch;

    public int questionNum;

    public bool activationSwitch;
    public bool bloquedSwitch = true;
    public bool lights = false;
    public bool screen = false;
    public bool projector = false;
    public bool not1 = false;
    public bool not2 = false;
    public bool not3 = false;

    private bool isProcessingAnswer = false;

    private UIDragDrop[] notObjects;

    void Start()
    {
        logicGates = FindObjectOfType<LogicGates>();
        activatableSwitch = FindObjectOfType<ActivationSwitch>();
        notObjects = FindObjectsOfType<UIDragDrop>();

        questionNum = 1;
        ShowNextQuestion();
    }

    void Update()
    {
        activationSwitch = activatableSwitch.activatedSwitch;
        if (activationSwitch)
        {
            StartCoroutine(ProcessAnswer());
        }
        
    }

    IEnumerator ProcessAnswer()
    {
        if (isProcessingAnswer)
        {
            yield break;
        }

        isProcessingAnswer = true;
        GetQuestionLogic();
        yield return new WaitForSeconds(2f);
        ResetToFalse();
        if (questionNum == 5)
        {
            Debug.Log("Quiz completed!");
            PlayerPrefs.SetInt("LevelVisited_" + "IO", 1);
            PlayerPrefs.SetInt("completed", true ? 1 : 0);
            PlayerPrefs.Save();

            SceneManager.LoadScene("PopupScene");
        }
        else
        {
            questionNum++;
            ShowNextQuestion();
        }

        isProcessingAnswer = false;
        ResetNotObjects();
    }

    void ShowNextQuestion()
    {
        switch (questionNum)
        {
            case 1:
                questionText.text = "AND";
                break;
            case 2:
                questionText.text = "NAND";
                break;
            case 3:
                questionText.text = "OR";
                break;
            case 4:
                questionText.text = "NOR";
                break;
            case 5:
                questionText.text = "XOR";
                break;
        }
    }

    void GetQuestionLogic() {
        switch (questionNum)
        {
            case 1:
                
                lights = not1 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                screen = not2 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                projector = not3 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                break;
            case 2:
                
                lights = not1 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);
                screen = not2 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);
                projector = not3 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);
                break;
            case 3:

                lights = not1 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);
                screen = not2 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);
                projector = not3 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);
                break;
            case 4:

                lights = not1 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);
                screen = not2 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);
                projector = not3 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);
                break;
            case 5:

                lights = not1 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);
                screen = not2 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);
                projector = not3 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);
                break;
        }
    }

    void ResetToFalse()
    {
        activatableSwitch.activatedSwitch = false;
        activationSwitch = false;
        lights = false;
        screen = false;
        projector = false;
        not1 = false;
        not2 = false;
        not3 = false;
    }
    void ResetNotObjects()
    {
        foreach (var notObject in notObjects)
        {
            notObject.ResetPosition();
        }
    }

}
