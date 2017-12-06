using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Sanoria
{
    class XML
    {
        public XML(ref Data data)
        {
            if(!File.Exists(xmlPath))
                doc = new XDocument(new XElement("ROOT"));
            else
                doc = XDocument.Load(xmlPath);

            loadXMLtoData(ref data);
        }

        string xmlPath = Environment.CurrentDirectory + "\\XMLData\\XMLDataFile.xml";

        ~XML()
        {
            doc.Save(xmlPath);
        }

        XDocument doc;

        public void loadDatatoXML(ref Data data) 
        {
            doc = new XDocument(new XElement("ROOT"));

            foreach (var element in data.map)
            {
                doc.Root.Add(new XElement("Attribute", new XElement("Name", data.map[element.Key].name), new XElement("Value", data.map[element.Key].value), new XElement("Comment", data.map[element.Key].comment), new XElement("Date", data.map[element.Key].date)));
            }
        }

        void loadXMLtoData(ref Data data)
        {
            var attributes = doc.Root.Elements();

            int i = 0;

            foreach(var attribute in attributes)
            {
                data.newStruct(i, attribute.Element("Name").Value, attribute.Element("Value").Value, attribute.Element("Comment").Value, attribute.Element("Date").Value);
                i++;
            }
        }
    }
}
