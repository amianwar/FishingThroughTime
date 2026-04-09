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
    private int worldNum = 1;
    private int currentWorldNum;
    private int maxWorldsIndex;
    

    void Start()
    {
        currentWorldNum = SceneManager.GetActiveScene().buildIndex;
        maxWorldsIndex = SceneManager.sceneCountInBuildSettings-1;
        leftClick.onClick.AddListener(LeftButton);
        rightClick.onClick.AddListener(delegate {RightButton(maxWorldsIndex); });
        teleporter.onClick.AddListener(Teleport);
    }

    void LeftButton() 
    {
        if (worldNum != 1)
        {
            if (worldNum > 1)
            {
                worldNum--;
            }
            prevWorld.sprite = worldImages[worldNum-1];
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
            prevWorld.sprite = worldImages[worldNum-1];
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