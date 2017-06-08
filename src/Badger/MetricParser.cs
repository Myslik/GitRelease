using System.Linq;
using System.Xml.Linq;

namespace Badger
{
    public static class MetricParser
    {
        public static Metric ParseTests(string xunitReportPath)
        {
            var document = XDocument.Load(xunitReportPath);
            var collections = from collection in document.Descendants("collection")
                              select collection.Attribute("total").Value;

            int value = 0;
            foreach(var total in collections)
            {
                value += int.Parse(total);
            }

            return new Metric { Name = "tests", Value = value.ToString(), Color = value > 0 ? "green" : "red" };
        }
    }
}
