﻿using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<GameObject> levels;

    [HideInInspector] public int currentLevel;

    private float levelNumber;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SetLevelPlayerPrefs();
        CallLevel();
    }

    private void Update()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void SetLevelPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }
        else
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
    }

    public void CallLevel()
    {
        if (currentLevel > levels.Count)
        {
            currentLevel = 2;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            levels[PlayerPrefs.GetInt("CurrentLevel") - 1].SetActive(true);
        }
        else
        {
            levels[PlayerPrefs.GetInt("CurrentLevel") - 1].SetActive(true);
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}