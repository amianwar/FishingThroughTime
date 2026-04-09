using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WatchNavi : MonoBehaviour
{
    public Button teleporter;
    public Button leftClick;
    public Button rightClick;
    public Image prevWorld;
    public List<Sprite> worldImages;
    private int worldNum = 0;
    private int currentWorldNum;
    private int maxWorldsIndex;
    

    void Start()
    {
        currentWorldNum = SceneManager.GetActiveScene().buildIndex;
        maxWorldsIndex = SceneManager.sceneCountInBuildSettings-2;
        leftClick.onClick.AddListener(LeftButton);
        rightClick.onClick.AddListener(delegate {RightButton(maxWorldsIndex); });
        teleporter.onClick.AddListener(Teleport);
    }

    void LeftButton() 
    {
        if (worldNum != 0)
        {
            if (worldNum > 0)
            {
                worldNum--;
            }
            prevWorld.sprite = worldImages[worldNum];
        }
    }

    void RightButton(int maxWorlds)
    {
        if (worldNum != maxWorlds)
        {
            if (worldNum < maxWorlds)
            {
                worldNum++;
            }
            prevWorld.sprite = worldImages[worldNum];
        }
    }

    void Teleport()
    {
        if (worldNum != currentWorldNum)
        {
            SceneManager.LoadScene(worldNum);
        }   
    }
}