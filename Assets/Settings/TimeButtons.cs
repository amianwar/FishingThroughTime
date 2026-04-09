using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeButtons : MonoBehaviour
{
    public Button cenozoic;
    public Button mesozoic;
    public Button paleozoic;
    public GameObject currentPage;
    public GameObject prevPage;
    private GameObject m_cenozoic;
    private GameObject m_mesozoic;
    private GameObject m_paleozoic;


    
    void Start()
    {
        m_cenozoic = GameObject.Find("CenozoicFish");
        m_mesozoic = GameObject.Find("MesozoicFish");
        m_paleozoic = GameObject.Find("PaleozoicFish");

        m_mesozoic.SetActive(false);
        m_paleozoic.SetActive(false);
        currentPage = m_cenozoic;
        prevPage = m_cenozoic;

        cenozoic.onClick.AddListener(CenozoicButton);
        mesozoic.onClick.AddListener(MesozoicButton);
        paleozoic.onClick.AddListener(PaleozoicButton);
    }

    void CenozoicButton()
    {
        currentPage = m_cenozoic;
        if (currentPage != prevPage)
        {
            prevPage.SetActive(false);
        }
        currentPage.SetActive(true);
        prevPage = m_cenozoic;
    }

    void MesozoicButton()
    {
        currentPage = m_mesozoic;
        if (currentPage != prevPage)
        {
            prevPage.SetActive(false);
        }
        currentPage.SetActive(true);
        prevPage = m_mesozoic;
    }

    void PaleozoicButton()
    {
        currentPage = m_paleozoic;
        if (currentPage != prevPage)
        {
            prevPage.SetActive(false);
        }
        currentPage.SetActive(true);
        prevPage = m_paleozoic;
    }

}
