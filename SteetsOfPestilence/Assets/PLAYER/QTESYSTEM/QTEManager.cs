using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EnemyAI;
using PlayerController;
using Management;


namespace QTESystem
{
    #region Public Enums
    //comment
    public enum ActionState
    {
        running,
        success,
        fail,
        complete
    }

    //comment
    public enum QTEInput
    {
        NorthFace,
        EastFace,
        SouthFace,
        WestFace,
        LeftShoulder,
        LeftTrigger,
        RightShoulder,
        RightTrigger
    }

    #endregion

    public class QTEManager : MonoBehaviour
    {
        //******************** Variables *******************//
        #region Variables
        //*** Manager ***//
        GameManager m_manager;
        bool m_paused = false;

        //*** QTE DATA ***//
        #region QTE Data
        
        private InputActionMap m_actionMap;
        
        public QTEInputs InputActions;        
        
        public QTEEncounterData EncounterData;
        
        public List<QTEStreamData> ActiveStreamData;
        
        public List<QTEStreamData> WaitingStreams;
       
        public QTEStreamData ActiveStream;
        
        public QTEAction ActiveAction;

        public QTECombatAnimation CombatAnimation;
        
        [Tooltip("QTE Display")]
        public QTEDisplay QteDisplay;

        public List<QTEInput> ActiveDisplayList;        
        [SerializeField] private float m_canvasFadeDuration;

        
        #endregion

        //*** Poise Bar ***//
        #region Poise Bar
        public PoiseBarController PoiseBar;        

        

        //Poise variables
        public int ChangeInPoiseValue;
        public int AvailableSuccessPoints;
        public int CurrentSuccessPoints;
        [SerializeField]
        private int m_defaultPoiseChangeValue = 2;
        private float m_poiseChangeValue;

        #endregion

        //Combat Variables
        public int StreamPosition;
        private bool m_isBossFight = false;
        private bool m_bossPhaseOneComplete = false;

        //*** Timers ***//
        #region Timers
        public float Timer;        
        public float BeginningOfStreamTimeLimit;
        public float BetweenActionTimeLimit;
        public float ActionTimeLimit;
        [SerializeField]
        private SlowMotionManager m_slowMoManager;
        #endregion

        //*** Enum Variables ***//
        #region Enum Variables
        public ActionState ActionState;        
        public PlayerStance CurrentPlayerStance;        

        #endregion

        //*** Player & Enemy ***//
        #region Player & Enemy 
        public EnemyController Enemy;
        private PlayerManager Player;

        #endregion

        #endregion
        //******************** QTE Runner States **********************//        
        public QTEStates CurrentState;

        public EncounterStart EncounterStart = new EncounterStart();
        public StreamStart StreamStart = new StreamStart();
        public ActionActive ActionActive = new ActionActive();
        public BetweenActions BetweenActions = new BetweenActions();
        public CombatAnimation CombatAnim = new CombatAnimation();

        //******************** Enums **********************//
        #region Enums

        //comment
        public enum PlayerStance
        {
            NeutralStance,
            OffensiveStance,
            DefensiveStance
        }

        //comment
        private enum EncounterState
        {
            beginningOfEncounter,
            beginningOfStream,
            actionActive,
            betweenActions,            
            betweenStreams,            
            endOfEncounter            
        }

        #endregion

        //******************** Methods ********************//
        #region Methods

        
        #region Awake, Enable, Disable

        private void Awake()
        {
            
            ActiveDisplayList = new List<QTEInput>();
            CombatAnimation = GetComponentInChildren<QTECombatAnimation>();
            m_slowMoManager = GetComponentInChildren<SlowMotionManager>();
            Player = GetComponentInParent<PlayerManager>();
            m_manager = FindFirstObjectByType<GameManager>();
        }
        
        private void OnEnable()
        {
            InputActions = new QTEInputs();
            InputActions.Enable();
            m_actionMap = InputActions.Inputs;
            m_actionMap.actionTriggered += onActionInput;
        }

        private void OnDisable()
        {
            m_actionMap.actionTriggered -= onActionInput;
            InputActions.Disable();            
        }

        #endregion

        #region Update
        void Update()
        {
            //check for pause functionality
            if (m_manager.m_gameState == GameState.Paused && !m_paused)
            {
                m_paused = true;
                QteDisplay.Pause();
                InputActions.Disable();
            }
            if(m_manager.m_gameState !=GameState.Paused && m_paused)
            {
                m_paused = false;
                QteDisplay.Resume();
                InputActions.Enable();
            }
            if (!m_paused)
            {
                Timer += Time.unscaledDeltaTime;
            }            
            CurrentState.StateUpdate(Timer);
        }
        #endregion
        
        #region LoadingEncounterData
        /// <summary>
        /// Load Encounter Data from Enemy
        /// </summary>
        /// <param name="_encounterData"></param>
        /// <param name="_enemy"></param>
        public void LoadEncounter(QTEEncounterData _encounterData, EnemyController _enemy)
        {
            //make sure active stream has been cleared
            if (ActiveStream)
            {
                ActiveStream = null;
            }            
            //load data from enemy encounter data and start encounter            
            EncounterData = _encounterData;            
            Enemy = _enemy;
            EnterStance(PlayerStance.NeutralStance);
            QteDisplay.ActivatePoiseBar();            
            LoadUI(_enemy.m_EType);
            //check if boss fight
            if(_enemy.m_EType == EnemyType.Boss)
            {
                m_isBossFight = true;
            }
            //Load Stream Data
            ActiveStreamData = EncounterData.NeutralStreamData;            
            WaitingStreams = new List<QTEStreamData>();
            for (int i = 0; i < EncounterData.NeutralStreamData.Count; i++)
            {
                WaitingStreams.Add(Instantiate(ActiveStreamData[i]));
            }
            SelectStream();
            SetQTEAnimators();
            //reset all poise data
            PoiseBar.gameObject.SetActive(true);
            PoiseBar.ResetPoise();
            m_poiseChangeValue = m_defaultPoiseChangeValue;
            Timer = 0;
            //Set Encounter State and begin Encounter
            CurrentState = EncounterStart;
            CurrentState.EnterState(this);
            
        }
        /// <summary>
        /// Load second phase of boss encounter
        /// </summary>
        public void LoadBossEncounterTwo()
        {
            m_bossPhaseOneComplete = true;
            
            EncounterData = Enemy.transform.parent.GetComponentInChildren<BossSecondPhaseData>().SecondPhaseData;
            ActiveStreamData = EncounterData.NeutralStreamData;
            ActiveStream = null;
            WaitingStreams = new List<QTEStreamData>();
            for (int i = 0; i < EncounterData.NeutralStreamData.Count; i++)
            {
                WaitingStreams.Add(Instantiate(ActiveStreamData[i]));
            }
            SelectStream();
            //reset poise bar           
            PoiseBar.ResetPoise();
            m_poiseChangeValue = m_defaultPoiseChangeValue;
        }
        /// <summary>
        /// Randomly select stream from available streams
        /// </summary>
        public void SelectStream()
        {
            if(WaitingStreams.Count == 0)
            {
                ActiveStream = Instantiate(ActiveStream);
            }
            else
            {
                ActiveStream = Instantiate(SelectRandomStream());
            }            
        }
        /// <summary>
        /// Get list of all QTE Inputs from the active stream
        /// </summary>
        /// <returns></returns>
        public List<QTEInput> GetStreamActionInputs()
        {
            List<QTEInput> actions = new List<QTEInput>();
            for (int i = 0; i < ActiveStream.Actions.Count; i++)
            {
                for (int j = 0; j < ActiveStream.Actions[i].InputList.Count; j++)
                {
                    actions.Add(ActiveStream.Actions[i].InputList[j]);
                }
            }
            return actions;
        }
        /// <summary>
        /// Find Animators from Player and Enemy in current QTE encounter
        /// </summary>
        public void SetQTEAnimators()
        {
            Animator player = Player.GetComponentInChildren<Animator>();
            Animator enemy = Enemy.transform.parent.GetComponentInChildren<Animator>();            
            CombatAnimation.SetQTEAnimations(player, enemy);
        }
        /// <summary>
        /// Select next animation to play
        /// </summary>
        public void SelectQTECombatAnimations()
        {
            CombatAnimation.SelectAnimation(PoiseBar._poise);
        }
        /// <summary>
        /// Load QTE UI based on current enemy type
        /// </summary>
        /// <param name="_enemyType"></param>
        public void LoadUI(EnemyType _enemyType)
        {
            QteDisplay.LoadUI(_enemyType, m_canvasFadeDuration);            
        }
        /// <summary>
        /// Delete all remaining cues, streams, detach enemy from encounter and disable QTE Manager
        /// </summary>
        public void EndOfEncounter()
        {
            if(QteDisplay.FinishingCues.Count > 0)
            {
                StartCoroutine(DeleteCues());
            }
            if (m_isBossFight)
            {
                m_isBossFight = false;
                m_bossPhaseOneComplete = false;
            }
            WaitingStreams.Clear();
            Enemy.EndCombat();           
                       
            this.enabled = false;           
        }
        /// <summary>
        /// Deactivate QTE UI Panels and Reactivate Player Controls
        /// </summary>
        public void ReactivatePlayer()
        {
            QteDisplay.DeactivatePoiseBar();
            QteDisplay.DeactivatePanels();
            Player.SetPlayerActive(true);            
        }

        #endregion
        
        #region Stream Data

        /// <summary>
        /// Enter Different Combat Stance and select appropriate stream data
        /// </summary>
        /// <param name="_stance"></param>
        public void EnterStance(PlayerStance _stance)
        {
            CurrentPlayerStance = _stance;
            switch (CurrentPlayerStance)
            {
                case PlayerStance.NeutralStance:
                    ActiveStreamData = EncounterData.NeutralStreamData;
                    break;
                case PlayerStance.OffensiveStance:
                    ActiveStreamData = EncounterData.OffensiveStreamData;
                    break;
                case PlayerStance.DefensiveStance:
                    ActiveStreamData = EncounterData.DefensiveStreamData;
                    break;
                default:
                    break;
            }            
        }        

        /// <summary>
        /// Select Random Stream from available streams
        /// </summary>
        /// <returns></returns>
        public QTEStreamData SelectRandomStream()
        {
            //Clear tweens from previous stream
            QteDisplay.ClearTweens();
            //Select random stream from unselected streams
            int selector = Random.Range(0, WaitingStreams.Count);
            QTEStreamData selectedStream = Instantiate(WaitingStreams[selector]);
            WaitingStreams.RemoveAt(selector);
            if(ActiveStream)
            {
                WaitingStreams.Add(ActiveStream);
            }
            return selectedStream;
        }
        /// <summary>
        /// TUrn on input cues for current action
        /// </summary>
        public void ActivateInputCues()
        {
            foreach (QTEStreamData streamData in ActiveStreamData)
            {
                for(int i = 0; i < streamData.Actions.Count; i++)
                {
                    
                    streamData.Actions[i].CreateInputRings();
                }
            }
        }
        //Instantiate Action and set to active action
        public QTEAction CreateAction()
        {
            return ActiveAction = Instantiate(ActiveStream.Actions[StreamPosition]);
        }
        //Destroy Active Action
        public void DestroyAction()
        {
            Destroy(ActiveAction);
        }

        #endregion
        
        #region Combat and Poise Bar

        /// <summary>
        /// Check current poise value is and select next phase based on poise amount
        /// </summary>
        public void PoiseValueCheck()
        {
            float successRate = (float)CurrentSuccessPoints/(float)AvailableSuccessPoints;            
            int poiseChange;
            m_poiseChangeValue += 0.3f;
            
            switch(successRate)
            {
                case 0:
                    poiseChange = (int)-m_poiseChangeValue * 2;                    
                    break;
                case < 0.5f:
                    poiseChange = (int)-m_poiseChangeValue;                    
                    break;
                case 0.5f:
                    poiseChange = 0;                    
                    break;
                case 1:
                    poiseChange = (int)m_poiseChangeValue * 2;                    
                    break;
                case > 0.5f:
                    poiseChange = (int)m_poiseChangeValue;                   
                    break;
                default:
                    poiseChange = 0;                    
                    break;
            }
                   
            
            //adjust poise value based of successes and falures in stream 
            PoiseBar.SetPoise(poiseChange);
            if (PoiseBar._poise >= PoiseBar._maxPoise)
            {
                //load second phase of boss fight if necessary    
                if (m_isBossFight && !m_bossPhaseOneComplete)
                {
                    LoadBossEncounterTwo();                    
                    return;
                }
                playerWin();
            }
            if (PoiseBar._poise <= PoiseBar._minPoise)
            {
                playerLoss();
            }            
        }
        
        /// <summary>
        /// Player has won encounter
        /// </summary>
        private void playerWin()
        {           
            CombatAnimation.PlayAnimation("PlayerWin");            
            EndOfEncounter();            
        }

        /// <summary>
        /// Player has lost encounter
        /// </summary>
        private void playerLoss()
        {            
            Enemy.DisableEnemy();
            EndOfEncounter();
            CombatAnimation.PlayAnimation("EnemyWin");
            
        }       
        /// <summary>
        /// "true" slow down time, "false" restore to full speed
        /// </summary>
        /// <param name="_activate"></param>
        public void SlowTime(bool _activate)
        {
            if(_activate)
            {                
                m_slowMoManager.TimeSlowDown();
                return;
            }
            m_slowMoManager.TimeSpeedUp();
        }
        /// <summary>
        /// Set Endstate to true to trigger next qte
        /// </summary>
        public void ResetAnimationState()
        {
            CombatAnimation.EndState = true;
            CombatAnimation.ResetTriggers();            
        }   
        /// <summary>
        /// Fade in QTE UI
        /// </summary>
        public void FadeInUI()
        {
            StartCoroutine(QteDisplay.FadeInUI(m_canvasFadeDuration));
        }
        /// <summary>
        /// Fade Out QTE UI
        /// </summary>
        public void FadeOutUI()
        {
            QteDisplay.FadeOutUI(m_canvasFadeDuration);
        }
        /// <summary>
        /// Instantly win combat for debugging and testing purposes
        /// </summary>
        public void InstantWin()
        {
            playerWin();
            Enemy.KillEnemy();
            Time.timeScale = 1;
        }
        #endregion

        
        #region Inputs
        /// <summary>
        /// Takes in Input data and checks it against the Active Action
        /// </summary>
        /// <param name="_context"></param>
        private void onActionInput(InputAction.CallbackContext _context)
        {
            if(_context.performed)
            {
                QteDisplay.Input(_context.action.name);
                if (ActionState == ActionState.running)
                {
                    ActiveAction?.CheckInput(_context);
                }
            }
            if(_context.canceled)
            {
                QteDisplay.ResetAllActiveIconColours();
                ActiveAction?.OnRelease(_context);
            }                    
        }
        /// <summary>
        /// Reset stream index, timer and UI data from Stream Data
        /// </summary>
        public void ResetStreamData()
        {
            StreamPosition = 0;
            Timer = 0;            
            ActiveDisplayList.Clear();
            StartCoroutine(DeleteCues());
            
        }        
        /// <summary>
        /// Remove and destroy all cues from the waiting cues list
        /// </summary>
        /// <returns></returns>
        private IEnumerator DeleteCues()
        {
            yield return new WaitForSecondsRealtime(0.35f);            
            int count = QteDisplay.FinishingCues.Count;
            
            for (int i = 0; i < count; i++)
            {                
                GameObject holder = QteDisplay.FinishingCues[0];
                QteDisplay.FinishingCues.Remove(holder);
                Destroy(holder);
                
            }
        }
        #endregion

        #endregion
    }
}

