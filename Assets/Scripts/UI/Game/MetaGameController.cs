using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the menu.
        /// </summary>
        public GameObject uiCanvas;
        public Button pauseButton;

        private readonly int totalSceneCount = 10;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        private bool showMainCanvas = false;

        private void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        private void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            uiCanvas.SetActive(show);
            pauseButton.interactable = !show;
            showMainCanvas = show;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
        }

        public void StartLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        public void NextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == totalSceneCount)
            {
                StartLevel(1);
            }
            else
            {
                StartLevel(currentSceneIndex + 1);
            }
        }
    }
}
