using System.Collections.Generic;

namespace URLChecker
{
    public class LinkPage
    {
        public string parent
        {
            get;
            private set;
        }

        public IList<LinkStatus> linkData
        {
            get;
            private set;
        }

        public LinkPage(string parent)
        {
            this.parent = parent;
            linkData = new List<LinkStatus>();
        }
    }

    public class LinkStatus : LinkResult
    {
        public string name
        {
            get;
            private set;
        }

        public LinkStatus(string name, string link) : base(link)
        {
            this.name = name;
        }
    }

    public class LinkResult
    {
        public string link
        {
            get;
            protected set;
        }

        public int code
        {
            get;
            set;
        }

        public LinkResult(string link)
        {
            this.link = link;
            code = Constant.UNDEFINED;
        }
    }
}