using System;
using System.Collections;
using System.Collections.Generic;
using TKOU.SimAI;
using TKOU.SimAI.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EcomonyManager : MonoBehaviour
{
    [Header("Zmienne")]
    private float cash; //nie potrzeby float skoro w klasie "Income" i  tak zmieniamy to na INT
    public Text cashText;
    private Income income;
   // [SerializeField] private Income outcome; //[SerializaField] ju� jest private
    [SerializeField]
    private bool isCalc, canCalc; 
    public int IntCash; // nie u�ywane Zmienna z duzej litery?
    private List<Income> incomes;
    private PlayerController plCtr;



    private void Awake()
    {
        IntCash = 200;
        cashText.text = IntCash.ToString() + "$";

        income = (Income)GetComponent(typeof(Income)); // nie potrzebujemy bra� tego komponentu. z klasy Income usun��bym ":MonoBehiviour" i tworzy� nowe obiekty przez konstruktor chcac dodac przychod "
        // przyda�oby si� r�wnie� z list� zrobi� "incomes = new List<Income>();
        //cashText.text = income.Cash.ToString(); //Wartosc tekstu to same przychody?
        plCtr = FindObjectOfType<PlayerController>(); // W ten spos�b raczej odniose si� do GameObjectu
        
    }

    // Start is called before the first frame update 
    /*
    IEnumerator Start()
    {
        Debug.Log("Start");
        //StartCoroutine(LateStart()); // W ten spos�b si� "zap�tlamy" i co sekunde wykonuje si� debug.log
        yield return 0;
    }*/

    // Update is called once per frame
    public void Update()
    {
        if (!isCalc) return; // Domy�lna warto�� "!isCalc" to false a nigdzie nie jest zmieniana wi�c instrukcje poni�ej nie bed� wykonywane
        cashText.text = income.Cash.ToString();
        if (income.Cash > 100)
        {
            cashText.color = Color.black; // Ustawienie koloru tekstu na czarny
        }
        else
        {
            cashText.color = new Color(1, 1, 1); // TUTAJ R�WNIE�! Ustawienie koloru tekstu na czarny
        }
        InvokeRepeating("DoCalculations", 1, 1); // Bezu�teczne 

        HowToWin();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged") // "Untagged" to nazwa w�asna, �eby poprawnie to dzia�a�o nale�y da� "gameObject.tag == null'
        {
            collision.gameObject.SetActive(false); //setActive caly czas nie niszczy obiektu raczej u�y�bym Destroy(gameOBject)
        }
    }

    public void AddIncome(int aVal, int bVal, int cVal, float f, bool fast) // nie do konca pasuje mi nazwa. To raczej Outcome
    {
        if (fast)
        {
            cash -= aVal + bVal + cVal; // W ten spos�b od "cash" odejmujemy tylko "aVal" dodaj�c reszt� (�rednio sensowne)
        }
        else
        {
            cash -= ((aVal * f) + (bVal * f) + (cVal * f) * f / 3); //Nie rozumiem tej logiki dzia�ania
        }
        incomes.Add(new Income(cash)); //przychody raczej zawsze bed� minusowe
    }

    private void HowToWin()
    {
        if (cash > 500)
        {
            Debug.Log("you won");
        }
    }

    public void AddOutcome(int aVal)
    {

            cash -= aVal;
        incomes.Add(new Income(cash)); //w ten spos�b mog� dodawa� wydatki do konta gracza
    }



    void DoCalculations()
    {
        // tutaj powinny by� obliczenia ktore za kazdym razem dodamy cos do listy "przychod�w" odejmuj� to od naszego konta
        // a nastepnie wyswietlana animacja reprezentujaca to
    }
    /*
    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1); //Po sekundzie ponownie odpalamy "Start". Niesko�czona p�tla.
        StartCoroutine(Start());
    }*/

    public void OnDisable()
    {
        foreach (var i in incomes)
        {
            incomes.Remove(i); // zamiast czyscic kazdy skladnik listy przez foreach mozna to zast�pic incomes.clear();
        }

        incomes = null; // jesli u�yjemy .Clear(); to lista jest juz pusta wiec bez sensu to troche
    }
}
