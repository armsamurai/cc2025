using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ulong cookies = 0;

    [SerializeField] uint granny = 1;
    [SerializeField] ulong grannyPrice = 100;

    [SerializeField] uint bakery = 0;
    [SerializeField] ulong bakeryPrice = 5000;

    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProcessClick();
            print($"{cookies}");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            BuyGranny();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BuyBakery();
        }

    }

    void ProcessClick()
    {
        cookies += granny + bakery*2;
    }

    void BuyGranny()
    {
        if (cookies >= grannyPrice)
        {
            cookies -= grannyPrice;
            grannyPrice = (ulong)(grannyPrice * 1.25f);
            granny++;
            print($"�����������! �� ������ �������. ���������� �������: {granny}");
        }
        else
        {
            print($"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {grannyPrice - cookies}");
        }
    }

    void BuyBakery()
    {
        if (cookies >= bakeryPrice)
        {
            cookies -= bakeryPrice;
            bakeryPrice = (ulong)(bakeryPrice * 1.25f);
            bakery++;
            print($"�����������! �� ������ �������. ���������� ��������: {bakery}");
        }
        else
        {
            print($"� ���������, ��� �� ������� ������� ��� �������. �������� ���: {bakeryPrice - cookies}");
        }
    }
}
