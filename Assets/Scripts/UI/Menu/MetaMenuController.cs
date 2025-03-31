using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaMenuController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the menu.
        /// </summary>
        // public MainUIController mainMenu;
        public GameObject startCanvas;
        public GameObject creditsCanvas;
        public GameObject exitCanvas;

        /// <summary>
        /// A list of canvas objects which are used during gameplay (when the main ui is turned off)
        /// </summary>

        /// <summary>
        /// The game controller.
        /// </summary>

        bool showStartCanvas = false;
        bool showCreditsCanvas = false;
        bool showExitCanvas = false;

        void OnEnable()
        {
            // _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (this.showStartCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            // Debug.Log("show = " + show);
            if (show)
            {
                // Time.timeScale = 0;
                startCanvas.SetActive(true);
                // mainMenu.gameObject.SetActive(true);
            }
            else
            {
                // Time.timeScale = 1;
                startCanvas.SetActive(false);
                // mainMenu.gameObject.SetActive(false);
            }
            this.showStartCanvas = show;
        }

        public void ShowMenu()
        {
            ToggleMainMenu(true);
        }

        public void StartLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void ToggleCreditsMenu(bool show)
        {
            creditsCanvas.SetActive(show);
            showCreditsCanvas = show;
        }

        public void ToggleExitMenu(bool show)
        {
            exitCanvas.SetActive(show);
            showExitCanvas = show;
        }

        public void OnExitConfirm()
        {
            Application.Quit();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))  // Detect back button (Escape key)
            {
                if (showStartCanvas)
                {
                    ToggleMainMenu(show: !showStartCanvas);
                }
                else if (showCreditsCanvas)
                {
                    ToggleCreditsMenu(false);
                }
                else
                {
                    ToggleExitMenu(!showExitCanvas);
                }
            }
        }

    }
}
