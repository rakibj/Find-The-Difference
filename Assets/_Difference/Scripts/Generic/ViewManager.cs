using System;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Difference.Scripts.Generic
{
    public class ViewManager : MonoBehaviour
    {
        private TimerClass m_timerClass;
        [SerializeField] private Text timerText;
        [SerializeField] private Text matchesText;
        
        [Header("Win UI")]
        [SerializeField] private UIView winView;
        [Header("Lost UI")]
        [SerializeField] private UIView lostView;
        [SerializeField] private Text lostStatusText;
        [Header("Lost Again UI")]
        [SerializeField] private UIView lostAgainView;
        [SerializeField] private Text lostAgainStatusText;
        [Header("Others")] 
        [SerializeField] private UIView loadingView;

        private void OnEnable()
        {
            FindTheDifferenceEvents.TimerStartEvent.AddListener(Init);
            FindTheDifferenceEvents.MatchAmountEvent.AddListener(UpdateMatches);
            FindTheDifferenceEvents.WinEvent.AddListener(OnWin);
            FindTheDifferenceEvents.LostEvent.AddListener(OnLost);
            FindTheDifferenceEvents.LostAgainEvent.AddListener(OnLostAgain);
        }

        private void Init(TimerClass timerClass)
        {
            m_timerClass = timerClass;
        }

        private void Update()
        {
            timerText.text = Mathf.CeilToInt(m_timerClass.CurrentTime).ToString();
        }

        private void UpdateMatches(MatchData matchData)
        {
            matchesText.text = matchData.currentMatches + "/" + matchData.totalMatches;
        }

        private void OnWin(MatchData data)
        {
            winView.Show();
        }
        private void OnLost(MatchData data)
        {
            lostView.Show();
            lostStatusText.text = Lean.Localization.LeanLocalization.GetTranslationText("EndTimeUp1")
                + data.currentMatches
                + Lean.Localization.LeanLocalization.GetTranslationText("EndTimeUp2")
                + data.totalMatches
                + Lean.Localization.LeanLocalization.GetTranslationText("EndTimeUp3");
        }
        private void OnLostAgain(MatchData data)
        {
            lostAgainView.Show();
            lostAgainStatusText.text = Lean.Localization.LeanLocalization.GetTranslationText("EndTimeUpAgain1")
                                       + data.currentMatches
                                       + Lean.Localization.LeanLocalization.GetTranslationText("EndTimeUpAgain2");
        }

        public void ShowLoading()
        {
            loadingView.Show();
        }
        
    }
}
