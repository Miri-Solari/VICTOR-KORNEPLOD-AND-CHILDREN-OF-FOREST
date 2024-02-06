using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _firstPage;
    [SerializeField] GameObject _secondPage;
    [SerializeField] GameObject _thirdPage;

    public void ClickFromPause()
    {
        _menu.SetActive(false);
        _firstPage.SetActive(true);
    }

    public void FirstPage()
    {
        _firstPage.SetActive(true);
        _secondPage.SetActive(false);
        _thirdPage.SetActive(false);
    }

    public void SecondPage() 
    {
        _firstPage.SetActive(false);
        _secondPage.SetActive(true);
        _thirdPage.SetActive(false);
    }

    public void ThirdPage()
    {
        _firstPage.SetActive(false);
        _secondPage.SetActive(false);
        _thirdPage.SetActive(true);
    }

    public void Close()
    {
        _firstPage.SetActive(false);
        _secondPage.SetActive(false);
        _thirdPage.SetActive(false);
        _menu.SetActive(true);
    }

}
