namespace MeterTest.Source.Freeze
{
    public class FreezeReadMsg
    {
        public string ToolStripStatusLabel;
        public int ProgressBar;
        // public FreezeData freezeData;

        public FreezeReadMsg()
        {
            // freezeData = new FreezeData();
        }

        public FreezeReadMsg(string t, int p)
        {
            ToolStripStatusLabel = t;
            ProgressBar = p;
            // freezeData = new FreezeData();
        }

        public FreezeReadMsg(string toolStripStatusLabel, int progressBar, FreezeData freezeData) : this(toolStripStatusLabel, progressBar)
        {
            // this.freezeData = freezeData;
        }
    }
}