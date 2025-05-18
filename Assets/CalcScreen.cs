using System;
using UnityEngine;
using UnityEngine.UI;

public class CalcScreen : MonoBehaviour
{
    public Text xVal, rVal, yVal;
    ResultantVector vec;   

    private void Awake() {
        vec = FindObjectOfType<ResultantVector>();
    }
    void Update()
    {
        xVal.text = "vetor x = (" + Math.Round(vec.ca,2).ToString() + ", 0)";
        yVal.text = "vetor y = (0," + Math.Round(vec.co, 2).ToString() + ")";
        //rVal.text = "módulo r = " + Math.Round(Math.Sqrt(vec.ca*vec.ca + vec.co*vec.co),2).ToString();
        rVal.text = "vetor r = (" + Math.Round(vec.ca,2).ToString() +"," 
        + Math.Round(vec.co, 2).ToString() + ")";
    }
}
