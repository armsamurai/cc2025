using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Печеньки")]
    [SerializeField] ulong cookies = 0;
    [Space]

    [Header("Улучшения")]
    [SerializeField] uint chocolate = 0;
    [SerializeField] uint orange = 0;
    [Space]

    [Header("Цены")]
    [SerializeField] ulong chocolatePrice = 1000;
    [SerializeField] ulong orangePrice = 20000;
    [Space]

    [Header("Улучшения - автоклик")]
    [SerializeField] uint granny = 1;
    [SerializeField] uint bakery = 0;
    [Space]

    [Header("Цены - автоклик")]
    [SerializeField] ulong grannyPrice = 100;
    [SerializeField] ulong bakeryPrice = 5000;
    [Space]

    [Header("Текстовые элементы")]
    [SerializeField] TextMeshProUGUI cookieCounterText;
    [SerializeField] TextMeshProUGUI infoText;

    [Header("Текстовые элементы - улучшения")]
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
        chocolateInfo.text = $"Шоколадный\n{chocolate} lvl\n+{chocolate} пЗк\nЦена:\n{chocolatePrice}";
        orangeInfo.text = $"Апельсиновый\n{orange} lvl\n+{orange*2} пЗк\nЦена:\n{orangePrice}";
        grannyInfo.text = $"Бабушка\n{granny} lvl\n+{granny*2} пЗк\nЦена:\n{grannyPrice}";
        bakeryInfo.text = $"Пекарня\n{bakery} lvl\n+{bakery*5} пЗк\nЦена:\n{bakeryPrice}";
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
            infoText.text = $"Поздравляем! Вы прокачали шоколадный вкус. Уровень: {chocolate}";
        }
        else
        {
            infoText.text = $"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {chocolatePrice - cookies}";
        }
    }

    public void BuyOrange()
    {
        if (cookies >= orangePrice)
        {
            cookies -= orangePrice;
            orangePrice = (ulong)(orangePrice * 1.25f);
            orange++;
            infoText.text = $"Поздравляем! Вы прокачали апельсиновый вкус. Уровень: {orange}";
        }
        else
        {
            infoText.text = $"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {orangePrice - cookies}";
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
            infoText.text = $"Поздравляем! Вы купили бабушку. Количество бабушек: {granny}";
        }
        else
        {
            infoText.text = $"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {grannyPrice - cookies}";
        }
    }

    public void BuyBakery()
    {
        if (cookies >= bakeryPrice)
        {
            cookies -= bakeryPrice;
            bakeryPrice = (ulong)(bakeryPrice * 1.25f);
            bakery++;
            infoText.text = $"Поздравляем! Вы купили пекарню. Количество пекарень: {bakery}";
        }
        else
        {
            infoText.text = $"К сожалению, Вам не хватает печенек для покупки. Накопите еще: {bakeryPrice - cookies}";
        }
    }




}
