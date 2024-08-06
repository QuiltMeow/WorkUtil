using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public class Nonexpendable : RealBase
    {
        [Name("現值金額")]
        public string nowValue
        {
            get;
            set;
        }
    }
}