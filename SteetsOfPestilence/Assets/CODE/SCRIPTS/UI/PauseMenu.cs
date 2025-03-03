using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Management
{
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        /// name for the Main Menu Scene
        /// </summary>
        [SerializeField] private string m_MainMenuName = "MainMenu";
        private GameManager m_manager;
        private SlowMotionManager m_slomo;
        private float m_currentTimeScale;
        private void Start()
        {
            m_manager = GetComponentInParent<GameManager>();
            m_slomo = FindObjectOfType<SlowMotionManager>();
            EventSystem.current.SetSelectedGameObject(null);
            EnableChildren(false);
            Time.timeScale = 1;
            m_manager.SetGameState(GameState.Playing);
        }

        public void Pause()
        {
            bool pause = m_manager.m_gameState != GameState.Paused;
            Pause(pause);
        }
        public void Pause(bool pause)
        {
            if (pause)
            {
                EnableChildren(true);
                Button m_firstButton = GetComponentInChildren<Button>();
                EventSystem.current.SetSelectedGameObject(m_firstButton.gameObject);
                m_currentTimeScale = Time.timeScale;
                Time.timeScale = 0;
                m_manager.SetGameState(GameState.Paused);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                EventSystem.current.SetSelectedGameObject(null);
                EnableChildren(false);
                Time.timeScale = m_currentTimeScale;
                m_manager.SetGameState(GameState.Playing);
            }
        }

        private void DisableMenu()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EnableChildren(false);
            Time.timeScale = 1;
            m_manager.SetGameState(GameState.Playing);
        }

        private void EnableChildren(bool _enable)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(_enable);
            }
        }


        public void RestartLevel()
        {
            Pause(false);
            m_slomo.CancelTimeWarp();
            Time.timeScale = 1;
            SceneChanger.ResetScene();
        }

        public void GoToMainMenu()
        {
            Pause(false);
            m_slomo.CancelTimeWarp();
            Time.timeScale = 1;
            SceneChanger.ChangeScene(m_MainMenuName);
        }
        public void QuitGame()
        {
            SceneChanger.QuitGame();
        }

    }
}
