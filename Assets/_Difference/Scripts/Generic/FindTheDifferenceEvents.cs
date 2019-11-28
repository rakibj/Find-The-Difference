using UnityEngine;
using UnityEngine.Events;

namespace _Difference.Scripts.Generic
{
    public static class FindTheDifferenceEvents
    {
        public static readonly UnityEvent MatchEvent = new UnityEvent();
        public static readonly MatchDataEvent MatchAmountEvent = new MatchDataEvent();
        public static readonly MatchDataEvent WinEvent = new MatchDataEvent();
        public static readonly MatchDataEvent LostEvent = new MatchDataEvent();
        public static readonly MatchDataEvent LostAgainEvent = new MatchDataEvent();
        public static readonly IntEvent TimerEnd = new IntEvent();
        public static readonly TimerEvent TimerStartEvent = new TimerEvent();
    }
    
    public class MatchDataEvent: UnityEvent<MatchData>{}
    public class TimerEvent: UnityEvent<TimerClass>{}

    public class IntEvent: UnityEvent<int>{}
    public class MatchData
    {
        public int currentMatches;
        public int totalMatches;

        public MatchData(int currentMatches, int totalMatches)
        {
            this.currentMatches = currentMatches;
            this.totalMatches = totalMatches;
        }
    }

}
