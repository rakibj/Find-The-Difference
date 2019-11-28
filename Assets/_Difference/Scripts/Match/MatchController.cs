using System;
using _Difference.Scripts.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Difference.Scripts.Match
{
    public class MatchController : MonoBehaviour
    {
        private Button m_matchButton;

        private void Awake()
        {
            m_matchButton = GetComponentInChildren<Button>();
        }

        public void OnClick_Match()
        {
            m_matchButton.enabled = false;
            FindTheDifferenceEvents.MatchEvent.Invoke();
        }
    }
}
