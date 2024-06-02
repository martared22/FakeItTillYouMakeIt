using System;
using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class IoQuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public LogicGates logicGates;
    public ActivationSwitch activatableSwitch;

    public int questionNum;

    public bool activationSwitch;
    public bool bloquedSwitch;
    public bool lights = false;
    public bool screen = false;
    public bool projector = false;
    public bool not1 = false;
    public bool not2 = false;
    public bool not3 = false;

    // Start is called before the first frame update
    void Start()
    {
        logicGates = FindObjectOfType<LogicGates>();
        activatableSwitch = FindObjectOfType<ActivationSwitch>();
        questionNum = 0;
        ShowNextQuestion();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetActiveSwitch();
    }

    bool GetActiveSwitch() {
        activationSwitch = activatableSwitch.activatedSwitch;
        return activationSwitch;
    }

    void ShowNextQuestion () {
        questionNum++;
        GetQuestion(questionNum, false, false, false);
    }

    void GetQuestion(int questNum, bool not1, bool not2, bool not3) {
        System.Random random = new System.Random();

        switch (questNum) {
            case 1:
                bloquedSwitch = random.Next(2) == 1;

                //questionText.text = "1";

                if(activationSwitch) {
                    lights = not1 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                    screen =  not2 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                    projector =  not3 ? !logicGates.AndGate(activationSwitch, bloquedSwitch) : logicGates.AndGate(activationSwitch, bloquedSwitch);
                    //ShowNextQuestion();
                }
                
                
                break;
            case 2:
                bloquedSwitch = random.Next(2) == 1;

                questionText.text = "2";
                lights = not1 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);
                screen =  not2 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);
                projector =  not3 ? !logicGates.NandGate(activationSwitch, bloquedSwitch) : logicGates.NandGate(activationSwitch, bloquedSwitch);

                ShowNextQuestion();
                break;
            case 3:
                bloquedSwitch = random.Next(2) == 1;

                questionText.text = "3";
                lights = not1 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);
                screen =  not2 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);
                projector =  not3 ? !logicGates.OrGate(activationSwitch, bloquedSwitch) : logicGates.OrGate(activationSwitch, bloquedSwitch);

                ShowNextQuestion();
                break;
            case 4:
                bloquedSwitch = random.Next(2) == 1;

                questionText.text = "4";
                lights = not1 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);
                screen =  not2 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);
                projector =  not3 ? !logicGates.NorGate(activationSwitch, bloquedSwitch) : logicGates.NorGate(activationSwitch, bloquedSwitch);

                ShowNextQuestion();
                break;
            case 5:
                bloquedSwitch = random.Next(2) == 1;

                questionText.text = "5";
                lights = not1 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);
                screen =  not2 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);
                projector =  not3 ? !logicGates.XorGate(activationSwitch, bloquedSwitch) : logicGates.XorGate(activationSwitch, bloquedSwitch);

                ShowNextQuestion();
                break;
            default:
                bloquedSwitch = random.Next(2) == 1;

                questionText.text = "Out of Bounds";
                lights = false;
                screen = false;
                projector = false;
                break;
        }
    }
}
