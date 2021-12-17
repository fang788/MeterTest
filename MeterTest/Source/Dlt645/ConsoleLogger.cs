using MeterTest.Source.WindowsForm;

namespace MeterTest.Source.Dlt645
{
    public class ConsoleLogger
    {
        private readonly FormLogger m_logger;

        public ConsoleLogger(FormLogger logger)
        {
            m_logger = logger;
        }

        public void Log(string message)
        {
            if((m_logger != null) && (m_logger.Visible))
            {
                m_logger.ThreadProcSafePost(message);
            }
            else
            {
                ;
            }
        }
    }
}