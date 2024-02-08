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
        _firstPage.SetActive(true);
        _menu.SetActive(false);
    }

    public void FirstPage()
    {
        _firstPage.SetActive(true);
        _secondPage.SetActive(false);
        _thirdPage.SetActive(false);
    }

    public void SecondPage() 
    {
        _secondPage.SetActive(true);
        _firstPage.SetActive(false);
        _thirdPage.SetActive(false);
    }

    public void ThirdPage()
    {
        _thirdPage.SetActive(true);
        _firstPage.SetActive(false);
        _secondPage.SetActive(false);
    }

    public void Close()
    {
        _menu.SetActive(true);
        _firstPage.SetActive(false);
        _secondPage.SetActive(false);
        _thirdPage.SetActive(false);
    }

}
