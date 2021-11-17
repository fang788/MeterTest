namespace MeterTest.Source.Freeze
{
    public class FreezeReadMsg
    {
        public string ToolStripStatusLabel;
        public int ProgressBar;
        public FreezeData freezeData;

        public FreezeReadMsg(string t, int p)
        {
            ToolStripStatusLabel = t;
            ProgressBar = p;
        }

        public FreezeReadMsg(string toolStripStatusLabel, int progressBar, FreezeData freezeData) : this(toolStripStatusLabel, progressBar)
        {
            this.freezeData = freezeData;
        }
    }
}