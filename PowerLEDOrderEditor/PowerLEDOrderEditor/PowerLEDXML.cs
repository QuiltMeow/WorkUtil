using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PowerLEDOrderEditor
{
    public class PowerLEDXML
    {
        public string fileName
        {
            get;
            private set;
        }

        public IList<Screen> screenList
        {
            get;
            private set;
        }

        public XDocument xml
        {
            get;
            private set;
        }

        public class Screen
        {
            public string name
            {
                get;
                set;
            }

            public IList<XElement> program
            {
                get;
                private set;
            }

            public Screen()
            {
                program = new List<XElement>();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("螢幕名稱：").AppendLine(name);
                sb.AppendLine("節目列表：");
                for (int i = 0; i < program.Count; ++i)
                {
                    sb.AppendLine($"{i + 1}：{program[i]}");
                }
                return sb.ToString();
            }
        }

        public void load(string fileName)
        {
            this.fileName = fileName;
            xml = XDocument.Load(fileName);
            parse();
        }

        private void parse()
        {
            screenList = new List<Screen>();
            foreach (XElement element in xml.Descendants("screen"))
            {
                Screen screen = new Screen()
                {
                    name = element.Attribute("name").Value
                };

                foreach (XElement program in element.Descendants("program"))
                {
                    screen.program.Add(program);
                }
                screenList.Add(screen);
            }
        }

        public XElement getElementByScreenName(string name)
        {
            foreach (XElement element in xml.Descendants("screen"))
            {
                if (element.Attribute("name").Value == name)
                {
                    return element;
                }
            }
            throw new ArgumentException($"找不到節點 : {name}");
        }
    }
}