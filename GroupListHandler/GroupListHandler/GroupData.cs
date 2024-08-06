using System.Reflection;

namespace GroupListHandler
{
    public class GroupData
    {
        public string id
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string phone
        {
            get;
            set;
        }

        public string leader
        {
            get;
            set;
        }

        public void cleanUp()
        {
            PropertyInfo[] propertyData = GetType().GetProperties();
            foreach (PropertyInfo property in propertyData)
            {
                string data = property.GetValue(this).ToString();
                string clean = data.removeAll(" ").removeAll("\r").removeAll("\n");
                property.SetValue(this, clean);
            }
        }

        public override int GetHashCode()
        {
            return (id, type, name, address, phone, leader).GetHashCode();
        }

        public bool equalData(GroupData right)
        {
            return type.Equals(right.type)
                && name.Equals(right.name)
                && address.Equals(right.address)
                && phone.Equals(right.phone)
                && leader.Equals(right.leader);
        }

        public override bool Equals(object right)
        {
            if (!(right is GroupData))
            {
                return false;
            }

            GroupData compare = right as GroupData;
            PropertyInfo[] propertyData = GetType().GetProperties();
            foreach (PropertyInfo property in propertyData)
            {
                string leftString = property.GetValue(this).ToString();
                string rightString = property.GetValue(compare).ToString();
                if (!leftString.Equals(rightString))
                {
                    return false;
                }
            }
            return true;
        }

        public static string[] getHeaderArray()
        {
            return new string[]
            {
                "#",
                "團體類別",
                "團體名稱",
                "會址",
                "聯絡電話",
                "理事長"
            };
        }

        public string[] getDataArray()
        {
            PropertyInfo[] propertyData = GetType().GetProperties();
            int length = propertyData.Length;
            string[] ret = new string[length];
            for (int i = 0; i < length; ++i)
            {
                string data = propertyData[i].GetValue(this).ToString();
                ret[i] = data;
            }
            return ret;
        }
    }
}