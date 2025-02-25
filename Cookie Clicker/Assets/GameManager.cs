using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Печеньки")]
    [SerializeField] ulong cookies = 0;
    [Space]

    [Header("Улучшения")]
    [SerializeField] uint granny = 1;
    [SerializeField] uint bakery = 0;
    [Space]

    [Header("Цены")]
    [SerializeField] ulong grannyPrice = 100;
    [SerializeField] ulong bakeryPrice = 5000;
    [Space]

    [Header("Улучшения - автоклик")]
    [SerializeField] uint chocolate = 0;
    [SerializeField] uint orange = 0;
    [Space]

    [Header("Цены - автоклик")]
    [SerializeField] ulong chocolatePrice = 1000;
    [SerializeField] ulong orangePrice = 20000;


    void Start()
    {
        StartCoroutine(AutoClick());
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            BuyChocolate();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            BuyOrange();
        }
    }

    void ProcessClick()
    {
        cookies += granny + bakery * 2;
    }

    void BuyGranny()
    {
        if (cookies >= grannyPrice)
        {
            cookies -= grannyPrice;
            grannyPrice = (ulong)(grannyPrice * 1.25f);
            granny++;
            print($"Поздравляем! Вы купили бабушку. Количество бабушек: {granny}");
        }
        else
        {
            print($"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {grannyPrice - cookies}");
        }
    }

    void BuyBakery()
    {
        if (cookies >= bakeryPrice)
        {
            cookies -= bakeryPrice;
            bakeryPrice = (ulong)(bakeryPrice * 1.25f);
            bakery++;
            print($"Поздравляем! Вы купили пекарню. Количество пекарень: {bakery}");
        }
        else
        {
            print($"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {bakeryPrice - cookies}");
        }
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            cookies += chocolate + orange * 3;
            print(cookies);
            yield return new WaitForSeconds(1f);
        }
    }

    void BuyChocolate()
    {
        if (cookies >= chocolatePrice)
        {
            cookies -= chocolatePrice;
            chocolatePrice = (ulong)(chocolatePrice * 1.25f);
            chocolate++;
            print($"Поздравляем! Вы прокачали шоколадный вкус. Уровень: {chocolate}");
        }
        else
        {
            print($"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {chocolatePrice - cookies}");
        }
    }

    void BuyOrange()
    {
        if (cookies >= orangePrice)
        {
            cookies -= orangePrice;
            orangePrice = (ulong)(orangePrice * 1.25f);
            orange++;
            print($"Поздравляем! Вы прокачали апельсиновый вкус. Уровень: {orange}");
        }
        else
        {
            print($"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {orangePrice - cookies}");
        }
    }
}
