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
            // Z powodu braku du�ej ilo�ci czasu postanowi�em jedynie opisa� rozwi�zanie. 
            // Tworz� list� przycisk�w oraz zmienn� idx
            // Po kliknieciu strza�ki zmieniam warto�� idx maksymalnie do wielko�ci listy przycisk�w
            // Przycisk o danym indeksie w li�cie staje si� w�wczas aktywny i po naci�ni�ciu "entera" w��czam metode
            // OnClick();
            // Najlepiej jest zrobi� now� klas� i wykonywa� j� zar�wno w "UIMenuController" oraz "UIButtonGame" i w inicjalizacji
            // Pobierac wszystkie dost�pne przyciski i dodawac do listy
            // Dodatkowo zauwazylem ze gdy wlaczone jest samo menu to raczej nie powinien byc widoczny pasek z "quit" na samym dole
            // powinien byc widoczny dopiero w rozgrywce


        }

        private void QuitButton_OnClick()
        { 
            System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); // w ten sposob mog� odpali� aplikacj� ponownie 
            // a nastepnie wy��czy� wcze�niejszy proces to samo powinno znalezc sie w akcji przycisku powrotu do menu
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