using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{ 
    public Image pointsAlg;
    public Image pointsCalc;
    public Image pointsElectro;
    public Image pointsIO;
    public Image pointsDiU;
    public Image pointsPiC;
    public Image pointsBiE;
    public Image pointsProg;

    public TextMeshProUGUI showPoints;

    public Sprite[] pointsSprites;

    public GameManager gameManager;
    private int totalPoints;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        pointsAlg.sprite = pointsSprites[gameManager.algebraPoints];
        pointsCalc.sprite = pointsSprites[gameManager.calculPoints];
        pointsElectro.sprite = pointsSprites[gameManager.electroPoints];
        pointsIO.sprite = pointsSprites[gameManager.ioPoints];
        pointsDiU.sprite = pointsSprites[gameManager.diuPoints];
        pointsPiC.sprite = pointsSprites[gameManager.picPoints];
        pointsBiE.sprite = pointsSprites[Mathf.RoundToInt(gameManager.biePoints/2)];
        pointsProg.sprite = pointsSprites[gameManager.progPoints];

        totalPoints = gameManager.CalculateTotalPoints();
        showPoints.text = totalPoints.ToString();
    }
}
