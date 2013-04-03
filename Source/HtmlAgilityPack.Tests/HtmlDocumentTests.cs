using System;
using System.IO;
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

        [Test]
        public void Test_SaveXML_Does_Not_Add_Quotes_To_Attribute_Without_Quotes_When_Loading()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href>yo</a></body></html>");

            var html = doc.Save();

            Assert.AreEqual("<html><head></head><body><a href>yo</a></body></html>", html);
        }

        [Test]
        public void Test_SaveXML_Does_Not_Add_Value_To_Attribute_Without_Value_When_Loading()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=\"\">yo</a></body></html>");

            var html = doc.Save();

            Assert.AreEqual("<html><head></head><body><a href=\"\">yo</a></body></html>", html);
        }

        [Test]
        public void Test_SaveXML_Does_Not_Add_Quote_To_Attribute_Loading_And_Attribute_Is_Not_Empty()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=foo>yo</a></body></html>");

            var html = doc.Save();

            Assert.AreEqual("<html><head></head><body><a href=foo>yo</a></body></html>", html);
        }

        [Test]
        public void Test_SaveXML_Does_Change_Quotes_On_Attributes()
        {
            var doc = new HtmlDocument("<html><head></head><body><a href=\"foo\">yo</a></body></html>");
            Assert.AreEqual("<html><head></head><body><a href=\"foo\">yo</a></body></html>", doc.Save());

            doc = new HtmlDocument("<html><head></head><body><a href='foo'>yo</a></body></html>");
            Assert.AreEqual("<html><head></head><body><a href='foo'>yo</a></body></html>", doc.Save());
        }

        [Test]
        public void Test_Constructing_Document()
        {
            var doc = new HtmlDocument();
            var a = doc.CreateElement("a");
            a.SetAttributeValue("href", "foo");
            a.InnerHtml = "foo";

            doc.DocumentNode.AppendChild(a);

            var html = doc.Save();
            Console.WriteLine(html);
        }
    }
}