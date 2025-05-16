using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (showStartCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            startCanvas.SetActive(show);
            if (show)
            {
                SetLevelsAvailability();
            }
            showStartCanvas = show;
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

        private void SetLevelsAvailability()
        {
            GameObject.Find("Level1Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess1;
            GameObject.Find("Level2Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess2;
            GameObject.Find("Level3Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess3;
            GameObject.Find("Level4Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess4;
            GameObject.Find("Level5Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess5;
            GameObject.Find("Level6Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess6;
            GameObject.Find("Level7Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess7;
            GameObject.Find("Level8Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess8;
            GameObject.Find("Level9Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess9;
            GameObject.Find("Level10Button").GetComponent<Button>().interactable = GamePreferences.LevelAccess10;
        }
    }
}
