using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    public class HtmlDocumentTests
    {
        [Test]
        public void Test_LoadHtml()
        {
            var doc = new HtmlDocument("<html></html>");

            Assert.AreEqual(1, doc.DocumentNode.ChildNodes.Count);
            Assert.AreEqual("html", doc.DocumentNode.FirstChild.Name);
        }

        [Test]
        public void Test_SelectNodes_Returns_Empty_List_When_No_Nodes_Found()
        {
            var doc = new HtmlDocument("<html><head></head><body><p>yo</p></body></html>");

            var nodes = doc.DocumentNode.SelectNodes("//em");

            Assert.IsEmpty(nodes);
        }

        [Test]
        public void Test_HasAttribute()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=\"http://flo.se\">yo</a></body></html>");
            
            var link = doc.DocumentNode.SelectSingleNode("//a");
            
            Assert.IsTrue(link.HasAttribute("href"));
        }

        [Test]
        public void Test_Attribute_ToString_Returns_Value()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=\"http://flo.se\">yo</a></body></html>");

            var link = doc.DocumentNode.SelectSingleNode("//a");

            Assert.AreEqual("http://flo.se", link.Attributes["href"].ToString());
        }

        [Test]
        public void Test_Attribute_ToString_Returns_Empty_String_When_Value_Is_Empty()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=\"\">yo</a></body></html>");
            
            var link = doc.DocumentNode.SelectSingleNode("//a");

            Assert.AreEqual(string.Empty, link.Attributes["href"].ToString());
        }

        [Test]
        public void Test_Attribute_ToString_Returns_Empty_String_When_Value_Is_Not_Defined()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href>yo</a></body></html>");

            var link = doc.DocumentNode.SelectSingleNode("//a");

            Assert.AreEqual(string.Empty, link.Attributes["href"].ToString());
        }
    }
}