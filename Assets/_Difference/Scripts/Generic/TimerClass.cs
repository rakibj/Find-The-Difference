namespace _Difference.Scripts.Generic
{
    public class TimerClass
    {
        private float m_currentTime = 0;

        public float CurrentTime => m_currentTime;

        public float TotalTime => m_totalTime;

        private float m_totalTime = 0;

        public TimerClass(float totalTime)
        {
            m_totalTime = totalTime;
            m_currentTime = totalTime;
        }

        public float ReduceTimePerFrame(float deltaTime)
        {
            m_currentTime -= deltaTime;
            return m_currentTime;
        }
        
    }
}
