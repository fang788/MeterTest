using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class ReadWriteDataId : DataId
    {
        public ReadWriteDataId()
        {
        }
        public ReadWriteDataId(Project project)
        {
            this.Project = project;
        }

        public Project Project{get; set;}
    }
}