using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    class XpathTests
    {
        [Test]
        public void TestHrefAttributeSelection()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(
                "<html><body><div><p><a href=\"http://somewhereoutthere.com\">adfasf </a></p></div><p><a href=\"asdfadsf asdfasdf\">asdfa</a></p><body></html>");
            var nodes = doc.DocumentNode.SelectNodes("//@href");
            Assert.AreEqual(2, nodes.Count);
            Assert.AreEqual(nodes.OfType<HtmlAttribute>().Count(), nodes.Count);
        }

        [Test]
        public void TestHrefNodeSelection()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(
                "<html><body><div><p><a href=\"http://somewhereoutthere.com\">adfasf </a></p></div><p><a href=\"asdfadsf asdfasdf\">asdfa</a></p></body></html>");
            var nodes = doc.DocumentNode.SelectNodes("//*[@href]");
            Assert.AreEqual(2, nodes.Count);
            Assert.AreEqual(nodes.OfType<HtmlNode>().Count(), nodes.Count);
        }
        [Test]
        public void SelectAllChildNodesOfElement()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(
                "<html><body><div><p><a href=\"http://somewhereoutthere.com\">adfasf </a></p></div><p><a href=\"asdfadsf asdfasdf\">asdfa</a></p></body></html>");
            var nodes = doc.DocumentNode.SelectNodes("html/body/*");
            Assert.AreEqual(2, nodes.Count);
            Assert.AreEqual(nodes.OfType<HtmlNode>().Count(), nodes.Count);
        }

        [Test]
        public void TestHrefAttributeValueSelection()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(
                "<html><body><div><p><a href=\"http://somewhereoutthere.com\">adfasf </a></p></div><p><a href=\"asdfadsf asdfasdf\">asdfa</a></p><body></html>");
            var nodes = doc.DocumentNode.SelectNodes("//*[@href='http://somewhereoutthere.com']");
            Assert.AreEqual(1, nodes.Count);
            Assert.AreEqual(nodes.OfType<HtmlNode>().Count(), nodes.Count);
        }
    }
}
