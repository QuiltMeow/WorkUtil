namespace ITMoney
{
    public class Nonexpendable : PropertyBase
    {
        public int nowValue // 現值金額 =  原始價值
        {
            get
            {
                return originValue;
            }
        }

        public string useUser; // 使用人
    }
}