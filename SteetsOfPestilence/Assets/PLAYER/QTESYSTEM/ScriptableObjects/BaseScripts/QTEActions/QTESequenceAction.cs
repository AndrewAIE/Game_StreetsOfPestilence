using UnityEngine;
using UnityEngine.InputSystem;

namespace QTESystem
{
    [CreateAssetMenu(fileName = "NewSequenceAction", menuName = "Quick Time Event/New Quick Time Action/SequenceAction")]
    public class QTESequenceAction : QTEAction
    {        
        private float[] m_actionTimeLimits;
        private int m_activeTimeSlot;
        private bool[] m_activeBools;                
        private bool m_allStartBoolsActivated = false;        
        private bool m_actionComplete = false;
        [SerializeField]
        private float[] m_displayLeadInTime;
        [SerializeField]
        private float[] m_timeBetweenInputs;        
        private float m_inputTransferBuffer = 0.2f;
        
        protected override void onStart()
        {
            //create timers and bools for each input of the sequence
            m_actionTimeLimits = new float[InputList.Count];
            m_activeBools = new bool[InputList.Count];   

            for (int i = 0; i < m_actionTimeLimits.Length; i++)
            {                
                m_actionTimeLimits[i] = m_timeLimit + (i * GetTimeBetweenInputs(i)) + GetDisplayLeadInTime(i);
                m_activeBools[i] = false;                
            }
            //m_actionTimeLimits[0] += m_displayLeadInTime;
            m_maxTime = m_actionTimeLimits[m_actionTimeLimits.Length - 1] + (m_successBuffer / 2);
            m_activeTimeSlot = 0;    
        }

        protected override ActionState onUpdate()
        {            
            if(!m_allStartBoolsActivated)
            {
                //Turn on bools as it reaches the appropriate time
                for (int i = 0; i < m_activeBools.Length; i++)
                {                    
                    if (m_activeBools[i] == false && m_timer >= m_actionTimeLimits[i] - GetDisplayLeadInTime(i))
                    {
                        //activate cue ring
                        m_qteDisplay.ActivateCue(i, Color.white);
                        m_qteDisplay.AnimateCue(GetDisplayLeadInTime(i), i, InputList[i]);
                        m_activeBools[i] = true;
                        //stop iterating through loops if all bools are activated
                        if (i == m_activeBools.Length - 1)
                        {
                            m_allStartBoolsActivated = true;
                            break;
                        }
                    }
                }
            }            

            if (m_state == ActionState.running)
            {               
                if(m_timer >= m_actionTimeLimits[m_activeTimeSlot] + (m_successBuffer / 2f) + m_inputTransferBuffer)
                {                    
                    m_activeTimeSlot++;
                    m_actionComplete = false;
                    m_qteDisplay.ResetAllActiveIconColours();
                }
            }
            if (m_timer >= m_actionTimeLimits[m_activeTimeSlot] + (m_successBuffer / 2f) && !m_actionComplete)
            {
                m_qteDisplay.MissedInput(InputList[m_activeTimeSlot], m_activeTimeSlot);
                m_qteDisplay.DeactivateCue(m_activeTimeSlot);
                m_actionComplete = true;
            }
            //return success when sequence has finished
            if (m_timer >= m_maxTime)
            {
                m_state = ActionState.success;
                m_timeUp = true;
            }
            return m_state;
        }        

        public override void CheckInput(InputAction.CallbackContext _context)
        {            
            if (m_state != ActionState.running || m_actionComplete)
            {
                return;   
            }            
            if (checkSuccessWindow() && _context.action == m_readyInputs[m_activeTimeSlot])
            {
                m_qteDisplay.SuccessfulInput(InputList[m_activeTimeSlot], m_activeTimeSlot);                                                            
                CorrectInputs++;
                m_actionComplete = true;
                return;
            }
            if (m_activeBools[m_activeTimeSlot])
            {                
                m_actionComplete = true;
                m_qteDisplay.MissedInput(InputList[m_activeTimeSlot], m_activeTimeSlot);
                m_qteDisplay.IncorrectInput(_context.action.name);
                m_qteDisplay.DeactivateCue(m_activeTimeSlot);                                             
            }           
        }

        protected override bool checkSuccessWindow()
        {
            if (m_timer >= m_actionTimeLimits[m_activeTimeSlot] - (m_successBuffer / 1.5f) && m_timer <= m_actionTimeLimits[m_activeTimeSlot] + (m_successBuffer / 2f))
            {
                return true;
            }
            return false;
        }

        public override void OnRelease(InputAction.CallbackContext _context)
        {
            
        }
        private float GetTimeBetweenInputs(int _index)
        {
            if(m_timeBetweenInputs.Length > 1)
            {
                return m_timeBetweenInputs[_index];
            }
            else
            {
                return m_timeBetweenInputs[0];
            }
        }
        private float GetDisplayLeadInTime(int i)
        {
            if (m_displayLeadInTime.Length > 1)
            {
                return m_displayLeadInTime[i];
            }
            else
            {
                return m_displayLeadInTime[0];
            }
        }

        public override void CreateInputRings()
        {
            foreach(QTEInput input in InputList)
            {
                m_qteDisplay.CreateInputPrompt(input);
            }    

        }
    }
}

