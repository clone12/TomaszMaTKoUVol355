using System;
using System.Collections;
using System.Collections.Generic;
using TKOU.SimAI;
using TKOU.SimAI.Player;
using TMPro;
using UnityEngine;

public class EcomonyManager : MonoBehaviour
{
    [Header("Zmienne")]
    private float cash; //nie potrzeby float skoro w klasie "Income" i  tak zmieniamy to na INT
    public TMP_Text cashText;
    private Income income;
    [SerializeField] private Income outcome; //[SerializaField] ju¿ jest private
    [SerializeField]
    private bool isCalc, canCalc; 
    public int IntCash; // nie u¿ywane
    private List<Income> incomes;
    private PlayerController plCtr;



    private void Awake()
    {
        income = (Income)GetComponent(typeof(Income)); // nie potrzebujemy braæ tego komponentu. z klasy Income usun¹³bym ":MonoBehiviour" i tworzy³ nowe obiekty przez konstruktor chcac dodac przychod "
        // przyda³oby siê równie¿ z list¹ zrobiæ "incomes = new List<Income>();
        cashText.text = income.Cash.ToString(); // 
        plCtr = FindObjectOfType<PlayerController>(); // W ten sposób raczej odniose siê do GameObjectu
    }

    // Start is called before the first frame update 
    IEnumerator Start()
    {
        Debug.Log("Start");
        StartCoroutine(LateStart()); // W ten sposób siê "zapêtlamy" i co sekunde wykonuje siê debug.log
        yield return 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!isCalc) return; // Domyœlna wartoœæ "!isCalc" to false a nigdzie nie jest zmieniana wiêc instrukcje poni¿ej nie bed¹ wykonywane
        cashText.text = income.Cash.ToString();
        if (income.Cash > 100)
        {
            cashText.color = Color.black; // Ustawienie koloru tekstu na czarny
        }
        else
        {
            cashText.color = new Color(1, 1, 1); // TUTAJ RÓWNIE¯! Ustawienie koloru tekstu na czarny
        }
        InvokeRepeating("DoCalculations", 1, 1); // Bezu¿teczne 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged") // "Untagged" to nazwa w³asna, ¿eby poprawnie to dzia³a³o nale¿y daæ "gameObject.tag == null'
        {
            collision.gameObject.SetActive(false); //setActive caly czas nie niszczy obiektu raczej u¿y³bym Destroy(gameOBject)
        }
    }

    public void AddIncome(int aVal, int bVal, int cVal, float f, bool fast) // nie do konca pasuje mi nazwa. To raczej Outcome
    {
        if (fast)
        {
            cash -= aVal + bVal + cVal; // W ten sposób od "cash" odejmujemy tylko "aVal" dodaj¹c resztê (œrednio sensowne)
        }
        else
        {
            cash -= ((aVal * f) + (bVal * f) + (cVal * f) * f / 3); //Nie rozumiem tej logiki dzia³ania
        }
        incomes.Add(new Income(cash)); //przychody raczej zawsze bed¹ minusowe
    }

    void DoCalculations()
    {

    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1); //Po sekundzie ponownie odpalamy "Start". Nieskoñczona pêtla.
        StartCoroutine(Start());
    }

    public void OnDisable()
    {
        foreach (var i in incomes)
        {
            incomes.Remove(i); // zamiast czyscic kazdy skladnik listy przez foreach mozna to zast¹pic incomes.clear();
        }

        incomes = null; // jesli u¿yjemy .Clear(); to lista jest juz pusta wiec bez sensu to troche
    }
}
