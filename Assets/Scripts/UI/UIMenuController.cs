using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

//using System.Collections.Generic;

namespace TKOU.SimAI.UI
{
    /// <summary>
    /// Menu controller.
    /// </summary>
    public class UIMenuController : MonoBehaviour
    {
        #region Variables

        public delegate void ButtonAction();

        [SerializeField]
        private GameController gameController;

        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button quitButton;

        [SerializeField]
        private GameObject mainMenuObject;

       // [SerializeField] List<Button> menuButtons = new List<Button>();
      //  private int idx = 0;

        [SerializeField]
        [Tooltip("Set to TRUE to automatically start the game on play. Useful for testing.")]
        private bool autostart = false;

        #endregion Variables

        #region Unity methods

        private void Awake()
        {
           // menuButtons.Add(playButton);
          //  menuButtons.Add(quitButton);

            
            playButton.onClick.AddListener(PlayButton_OnClick);
            quitButton.onClick.AddListener(QuitButton_OnClick);
            
            gameController.OnGameRun += GameController_OnGameRun;
            gameController.OnGameEnd += GameController_OnGameEnd;
            
        }

        private void Start()
        {
            if (autostart)
            {
                gameController.RunGame();
            }

            /*
            menuButtons[0].image = GameObject.Find("UI-Button-Play").GetComponent<Image>();
            menuButtons[0].image.color = Color.yellow;
            playButton.onClick.AddListener(PlayButton_OnClick);

            menuButtons[1].image = GameObject.Find("UI-Button-Quit").GetComponent<Image>();
            menuButtons[1].image.color = Color.yellow;
            playButton.onClick.AddListener(PlayButton_OnClick);
            */

        }

        #endregion Unity methods

        #region Private methods

        #region Event callbacks

        private void Update()
        {
            // Z powodu braku du¿ej iloœci czasu postanowi³em jedynie opisaæ rozwi¹zanie. 
            // Tworzê listê przycisków oraz zmienn¹ idx
            // Po kliknieciu strza³ki zmieniam wartoœæ idx maksymalnie do wielkoœci listy przycisków
            // Przycisk o danym indeksie w liœcie staje siê wówczas aktywny i po naciœniêciu "entera" w³¹czam metode
            // OnClick();
            // Najlepiej jest zrobiæ now¹ klasê i wykonywaæ j¹ zarówno w "UIMenuController" oraz "UIButtonGame" i w inicjalizacji
            // Pobierac wszystkie dostêpne przyciski i dodawac do listy
            // Dodatkowo zauwazylem ze gdy wlaczone jest samo menu to raczej nie powinien byc widoczny pasek z "quit" na samym dole
            // powinien byc widoczny dopiero w rozgrywce


        }

        private void QuitButton_OnClick()
        { 
            System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); // w ten sposob mogê odpaliæ aplikacjê ponownie 
            // a nastepnie wy³¹czyæ wczeœniejszy proces to samo powinno znalezc sie w akcji przycisku powrotu do menu
            Application.Quit();

        }

        private void PlayButton_OnClick()
        {
            gameController.RunGame();
        }

        private void GameController_OnGameRun()
        {
            UpdateVisibility();
        }

        private void GameController_OnGameEnd()
        {
            UpdateVisibility();
        }

        #endregion Event callbacks

        private void UpdateVisibility()
        {
            mainMenuObject.SetActive(!gameController.IsGameRunning);
        }

        #endregion Private methods
    }


}