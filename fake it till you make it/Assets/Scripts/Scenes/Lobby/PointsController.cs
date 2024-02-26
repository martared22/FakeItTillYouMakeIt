using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI algebraPoints;
    public TextMeshProUGUI progPoints;
    public TextMeshProUGUI ioPoints;
    public TextMeshProUGUI biePoints;
    public TextMeshProUGUI calculPoints;
    public TextMeshProUGUI electroPoints;
    public TextMeshProUGUI picPoints;
    public TextMeshProUGUI diuPoints;

    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        algebraPoints.text = gameManager.algebraPoints.ToString();
        biePoints.text = gameManager.biePoints.ToString();
        picPoints.text = gameManager.picPoints.ToString();
        progPoints.text = gameManager.progPoints.ToString();
        diuPoints.text = gameManager.diuPoints.ToString();
        ioPoints.text = gameManager.ioPoints.ToString();
        calculPoints.text = gameManager.calculPoints.ToString();
        electroPoints.text = gameManager.electroPoints.ToString();
    }
}
