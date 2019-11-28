using System;
using _Difference.Scripts.Match;
using UnityEngine;

namespace _Difference.Scripts.Generic
{
    public class MatchManager : MonoBehaviour
    {
        private int m_correctMatches = 0;
        private int m_totalMatches = 0;

        private void Awake()
        {
            m_totalMatches = FindObjectsOfType<MatchController>().Length;
        }

        private void OnEnable()
        {
            FindTheDifferenceEvents.MatchEvent.AddListener(OnCorrectMatch);
            FindTheDifferenceEvents.TimerEnd.AddListener(PrepareGameEndData);
        }

        private void OnCorrectMatch()
        {
            m_correctMatches++;
            FindTheDifferenceEvents.MatchAmountEvent.Invoke(new MatchData(m_correctMatches, m_totalMatches));
            if(m_correctMatches >= m_totalMatches)
                FindTheDifferenceEvents.WinEvent.Invoke(new MatchData(m_correctMatches, m_totalMatches));
        }

        private void PrepareGameEndData(int lostTimes)
        {
            if(lostTimes < 2)
                FindTheDifferenceEvents.LostEvent.Invoke(new MatchData(m_correctMatches, m_totalMatches));
            else
                FindTheDifferenceEvents.LostAgainEvent.Invoke(new MatchData(m_correctMatches, m_totalMatches));
        }
    }
}
