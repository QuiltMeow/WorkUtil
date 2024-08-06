using CsvHelper.Configuration;

namespace GroupListHandler
{
    public sealed class GroupMap : ClassMap<GroupData>
    {
        public GroupMap()
        {
            string[] header = GroupData.getHeaderArray();
            Map(map => map.id).Name(header[0]);
            Map(map => map.type).Name(header[1]);
            Map(map => map.name).Name(header[2]);
            Map(map => map.address).Name(header[3]);
            Map(map => map.phone).Name(header[4]);
            Map(map => map.leader).Name(header[5]);
        }
    }
}