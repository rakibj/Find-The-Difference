using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Difference.Scripts.Generic
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float allowedTime;
        private int numberOfLoss = 0;
        private TimerClass m_timerClass;
        private bool m_gameRunning = true;
        
        private void Start()
        {
            m_timerClass = new TimerClass(allowedTime);
            FindTheDifferenceEvents.TimerStartEvent.Invoke(m_timerClass);
        }

        private void Update()
        {
            if (!m_gameRunning)
                return;
            
            m_timerClass.ReduceTimePerFrame(Time.deltaTime);
            if (m_timerClass.CurrentTime <= 0)
            {
                m_gameRunning = false;
                StaticData.LostTimes++;
                FindTheDifferenceEvents.TimerEnd.Invoke(StaticData.LostTimes);
                if (StaticData.LostTimes >= 2)
                    StaticData.LostTimes = 0;
            }
        }

        public void OnClick_LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void OnClick_ReloadScene()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
