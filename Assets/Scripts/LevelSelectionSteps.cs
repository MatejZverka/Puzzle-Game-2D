using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelectionSteps : MonoBehaviour
{
    public GameObject levelSteps01;
    public GameObject levelSteps02;
    public GameObject levelSteps03;
    public GameObject levelSteps04;
    public GameObject levelSteps05;
    public GameObject levelSteps06;
    public GameObject levelSteps07;
    public GameObject levelSteps08;
    public GameObject levelSteps09;
    public GameObject levelSteps10;
    public GameObject levelSteps11;
    public GameObject levelSteps12;
    public GameObject levelSteps13;
    public GameObject levelSteps14;
    public GameObject levelSteps15;

    public void Start()
    {
        ShowLevel01Steps();
        ShowLevel02Steps();
        ShowLevel03Steps();
        ShowLevel04Steps();
        ShowLevel05Steps();
        ShowLevel06Steps();
        ShowLevel07Steps();
        ShowLevel08Steps();
        ShowLevel09Steps();
        ShowLevel10Steps();
        ShowLevel11Steps();
        ShowLevel12Steps();
        ShowLevel13Steps();
        ShowLevel14Steps();
        ShowLevel15Steps();
    }

    public void ShowLevel01Steps()
    {
        TextMeshProUGUI level01 = levelSteps01.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 01");

        if (steps == 0) { levelSteps01.SetActive(false); }
        else
        {
            levelSteps01.SetActive(true);
            if (steps < 10) { level01.text = "0" + steps; }
            else { level01.text = "" + steps; }
        }
    }

    public void ShowLevel02Steps()
    {
        TextMeshProUGUI level02 = levelSteps02.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 02");

        if (steps == 0) { levelSteps02.SetActive(false); }
        else 
        { 
            levelSteps02.SetActive(true);
            if (steps < 10) { level02.text = "0" + steps; }
            else { level02.text = "" + steps; }
        }
    }

    public void ShowLevel03Steps()
    {
        TextMeshProUGUI level03 = levelSteps03.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 03");

        if (steps == 0) { levelSteps03.SetActive(false); }
        else 
        { 
            levelSteps03.SetActive(true);
            if (steps < 10) { level03.text = "0" + steps; }
            else { level03.text = "" + steps; }
        }
    }

    public void ShowLevel04Steps()
    {
        TextMeshProUGUI level04 = levelSteps04.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 04");

        if (steps == 0) { levelSteps04.SetActive(false); }
        else
        {
            levelSteps04.SetActive(true);
            if (steps < 10) { level04.text = "0" + steps; }
            else { level04.text = "" + steps; }
        }
    }

    public void ShowLevel05Steps()
    {
        TextMeshProUGUI level05 = levelSteps05.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 05");

        if (steps == 0) { levelSteps05.SetActive(false); }
        else
        {
            levelSteps05.SetActive(true);
            if (steps < 10) { level05.text = "0" + steps; }
            else { level05.text = "" + steps; }
        }
    }

    public void ShowLevel06Steps()
    {
        TextMeshProUGUI level06 = levelSteps06.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 06");

        if (steps == 0) { levelSteps06.SetActive(false); }
        else
        {
            levelSteps06.SetActive(true);
            if (steps < 10) { level06.text = "0" + steps; }
            else { level06.text = "" + steps; }
        }
    }

    public void ShowLevel07Steps()
    {
        TextMeshProUGUI level07 = levelSteps07.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 07");

        if (steps == 0) { levelSteps07.SetActive(false); }
        else
        {
            levelSteps07.SetActive(true);
            if (steps < 10) { level07.text = "0" + steps; }
            else { level07.text = "" + steps; }
        }
    }

    public void ShowLevel08Steps()
    {
        TextMeshProUGUI level08 = levelSteps08.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 08");

        if (steps == 0) { levelSteps08.SetActive(false); }
        else
        {
            levelSteps08.SetActive(true);
            if (steps < 10) { level08.text = "0" + steps; }
            else { level08.text = "" + steps; }
        }
    }

    public void ShowLevel09Steps()
    {
        TextMeshProUGUI level09 = levelSteps09.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 09");

        if (steps == 0) { levelSteps09.SetActive(false); }
        else
        {
            levelSteps09.SetActive(true);
            if (steps < 10) { level09.text = "0" + steps; }
            else { level09.text = "" + steps; }
        }
    }

    public void ShowLevel10Steps()
    {
        TextMeshProUGUI level10 = levelSteps10.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 10");

        if (steps == 0) { levelSteps10.SetActive(false); }
        else
        {
            levelSteps10.SetActive(true);
            if (steps < 10) { level10.text = "0" + steps; }
            else { level10.text = "" + steps; }
        }
    }

    public void ShowLevel11Steps()
    {
        TextMeshProUGUI level11 = levelSteps11.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 11");

        if (steps == 0) { levelSteps11.SetActive(false); }
        else
        {
            levelSteps11.SetActive(true);
            if (steps < 10) { level11.text = "0" + steps; }
            else { level11.text = "" + steps; }
        }
    }

    public void ShowLevel12Steps()
    {
        TextMeshProUGUI level12 = levelSteps12.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 12");

        if (steps == 0) { levelSteps12.SetActive(false); }
        else
        {
            levelSteps12.SetActive(true);
            if (steps < 10) { level12.text = "0" + steps; }
            else { level12.text = "" + steps; }
        }
    }

    public void ShowLevel13Steps()
    {
        TextMeshProUGUI level13 = levelSteps13.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 13");

        if (steps == 0) { levelSteps13.SetActive(false); }
        else
        {
            levelSteps13.SetActive(true);
            if (steps < 10) { level13.text = "0" + steps; }
            else { level13.text = "" + steps; }
        }
    }

    public void ShowLevel14Steps()
    {
        TextMeshProUGUI level14 = levelSteps14.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 14");

        if (steps == 0) { levelSteps14.SetActive(false); }
        else
        {
            levelSteps14.SetActive(true);
            if (steps < 10) { level14.text = "0" + steps; }
            else { level14.text = "" + steps; }
        }
    }

    public void ShowLevel15Steps()
    {
        TextMeshProUGUI level15 = levelSteps15.GetComponentInChildren<TextMeshProUGUI>();
        int steps = PlayerPrefs.GetInt("Level 15");

        if (steps == 0) { levelSteps15.SetActive(false); }
        else
        {
            levelSteps15.SetActive(true);
            if (steps < 10) { level15.text = "0" + steps; }
            else { level15.text = "" + steps; }
        }
    }
}
