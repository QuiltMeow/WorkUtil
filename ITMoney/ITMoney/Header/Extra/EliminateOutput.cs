using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public class EliminateOutput : Eliminate
    {
        [Name("財產編號")]
        public string propertyId
        {
            get;
            set;
        }

        [Name("保管人")]
        public string keeper
        {
            get;
            set;
        }

        public EliminateOutput()
        {
        }

        public EliminateOutput(Eliminate copy) : base(copy)
        {
        }
    }
}