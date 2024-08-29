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
    public TextMeshProUGUI triesText;
    public LogicGates logicGates;
    public ActivationSwitch activatableSwitch;

    public int questionNum;
    public int possibleAnswers = 5;
    public int points;

    public bool activationSwitch;
    public bool bloquedSwitch = false;
    public bool lights = false;
    public bool screen = false;
    public bool projector = false;
    public bool lightsPsw = false;
    public bool screenPsw = false;
    public bool projectorPsw = false;
    public bool not1 = false;
    public bool not2 = false;
    public bool not3 = false;

    public Image uiImage;
    public Sprite[] sprites;
    public Image imagePoints;
    public Sprite[] spritePoints;

    private bool isProcessingAnswer = false;

    private UIDragDrop[] notObjects;

    GameManager gameManager;

    void Start()
    {
        logicGates = FindObjectOfType<LogicGates>();
        activatableSwitch = FindObjectOfType<ActivationSwitch>();
        notObjects = FindObjectsOfType<UIDragDrop>();

        questionNum = 1;
        ShowNextQuestion();

        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        activationSwitch = activatableSwitch.activatedSwitch;
        if (activationSwitch)
        {
            StartCoroutine(ProcessAnswer());
        }
        triesText.text = "Tries Left: " + possibleAnswers;
        gameManager.ioPoints = points;
        imagePoints.sprite = spritePoints[points];
    }

    IEnumerator ProcessAnswer()
    {
        if (isProcessingAnswer)
        {
            yield break;
        }

        isProcessingAnswer = true;
        GetQuestionLogic();
        GetPassword();
        if (CompareAnswers())
        {
            points++;
        }
        else
        {
            possibleAnswers--;
            if(possibleAnswers == 0)
            {
                PlayerPrefs.SetInt("LevelVisited_" + "IO", 1);
                PlayerPrefs.SetInt("failed", true ? 1 : 0);
                PlayerPrefs.Save();
                SceneManager.LoadScene("PopupScene");
            }
        }
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
            uiImage.sprite = sprites[questionNum];
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
                questionText.text = "Turn the lights on please, so we can start the class.";
                break;
            case 2:
                questionText.text = "Now turn on the Screen, but turn off everything else, so I can see your classmates.";
                break;
            case 3:
                questionText.text = "Now lets keep the PC and the Screen on, but the lights off.";
                break;
            case 4:
                questionText.text = "Turn on my PC and the lights, but turn off screen, as I see no one is connected.";
                break;
            case 5:
                questionText.text = "Let's wrap it here, thanks for coming, turn everything off.";
                break;
        }
    }

    bool CompareAnswers()
    {
        if (lights == lightsPsw && screen == screenPsw && projector == projectorPsw)
        {
            Debug.Log("Correct answer!");
            return true;
        }
        else
        {
            Debug.Log("Incorrect answer!");
            return false;
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

    void GetPassword()
    {
        switch (questionNum)
        {
            case 1:
                lightsPsw = true;
                screenPsw = false;
                projectorPsw = false;
                break;
            case 2:
                lightsPsw = false;
                screenPsw = true;
                projectorPsw = false;
                break;
            case 3:
                lightsPsw = false;
                screenPsw = true;
                projectorPsw = true;
                break;
            case 4:
                lightsPsw = true;
                screenPsw = false;
                projectorPsw = true;
                break;
            case 5:
                lightsPsw = false;
                screenPsw = false;
                projectorPsw = false;
                break;
        }
    }
}
