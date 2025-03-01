using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("��������")]
    [SerializeField] ulong cookies = 0;
    [Space]

    [Header("���������")]
    [SerializeField] uint chocolate = 0;
    [SerializeField] uint orange = 0;
    [Space]

    [Header("����")]
    [SerializeField] ulong chocolatePrice = 1000;
    [SerializeField] ulong orangePrice = 20000;
    [Space]

    [Header("��������� - ��������")]
    [SerializeField] uint granny = 1;
    [SerializeField] uint bakery = 0;
    [Space]

    [Header("���� - ��������")]
    [SerializeField] ulong grannyPrice = 100;
    [SerializeField] ulong bakeryPrice = 5000;
    [Space]

    [Header("��������� ��������")]
    [SerializeField] TextMeshProUGUI cookieCounterText;
    [SerializeField] TextMeshProUGUI infoText;

    [Header("��������� �������� - ���������")]
    [SerializeField] TextMeshProUGUI chocolateInfo;
    [SerializeField] TextMeshProUGUI orangeInfo;
    [SerializeField] TextMeshProUGUI grannyInfo;
    [SerializeField] TextMeshProUGUI bakeryInfo;

    void Start()
    {
        StartCoroutine(AutoClick());
        infoText.text = "";
    }

    void Update()
    {
        cookieCounterText.text = $"{cookies}";
        ShowInfo();
    }

    void ShowInfo()
    {
        chocolateInfo.text = $"����������\n{chocolate} lvl\n+{chocolate} ���\n����:\n{chocolatePrice}";
        orangeInfo.text = $"������������\n{orange} lvl\n+{orange*2} ���\n����:\n{orangePrice}";
        grannyInfo.text = $"�������\n{granny} lvl\n+{granny*2} ���\n����:\n{grannyPrice}";
        bakeryInfo.text = $"�������\n{bakery} lvl\n+{bakery*5} ���\n����:\n{bakeryPrice}";
    }

    public void ProcessClick()
    {
        cookies += chocolate + orange * 2;
    }

    public void BuyChocolate()
    {
        if (cookies >= chocolatePrice)
        {
            cookies -= chocolatePrice;
            chocolatePrice = (ulong)(chocolatePrice * 1.25f);
            chocolate++;
            infoText.text = $"�����������! �� ��������� ���������� ����. �������: {chocolate}";
        }
        else
        {
            infoText.text = $"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {chocolatePrice - cookies}";
        }
    }

    public void BuyOrange()
    {
        if (cookies >= orangePrice)
        {
            cookies -= orangePrice;
            orangePrice = (ulong)(orangePrice * 1.25f);
            orange++;
            infoText.text = $"�����������! �� ��������� ������������ ����. �������: {orange}";
        }
        else
        {
            infoText.text = $"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {orangePrice - cookies}";
        }
    }
    
    IEnumerator AutoClick()
    {
        while (true)
        {
            cookies += granny*2 + bakery * 5;
            yield return new WaitForSeconds(1f);
        }
    }

    public void BuyGranny()
    {
        if (cookies >= grannyPrice)
        {
            cookies -= grannyPrice;
            grannyPrice = (ulong)(grannyPrice * 1.25f);
            granny++;
            infoText.text = $"�����������! �� ������ �������. ���������� �������: {granny}";
        }
        else
        {
            infoText.text = $"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {grannyPrice - cookies}";
        }
    }

    public void BuyBakery()
    {
        if (cookies >= bakeryPrice)
        {
            cookies -= bakeryPrice;
            bakeryPrice = (ulong)(bakeryPrice * 1.25f);
            bakery++;
            infoText.text = $"�����������! �� ������ �������. ���������� ��������: {bakery}";
        }
        else
        {
            infoText.text = $"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {bakeryPrice - cookies}";
        }
    }




}
