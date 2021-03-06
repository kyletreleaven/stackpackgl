using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace stackpackgl.report
{
	public interface IBox3
	{
		float Xmin {get;}
		float Xmax {get;}
		float Ymin {get;}
		float Ymax {get;}
		float Zmin {get;}
		float Zmax { get; }

	}

	public struct Box3 : IBox3
	{
		public float Xmin {get;set;}
		public float Xmax {get;set;}
		public float Ymin {get;set;}
		public float Ymax {get;set;}
		public float Zmin {get;set;}
		public float Zmax {get;set;}
	}

	public static class StackPackToThreeJs
	{
		public static string ToThreeJs(this IEnumerable<IBox3> boxes)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("stackpackgl.report.template-standalone.html");
            StreamReader reader = new StreamReader(stream);

			string jsonString;

			var boxData = boxes.Select (box => new float [] { box.Xmin, box.Xmax, box.Ymin, box.Ymax, box.Zmin, box.Zmax });
			jsonString = JsonConvert.SerializeObject(boxData);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(reader.ReadToEnd());

            var dataNode = htmlDocument.GetElementbyId ("boxdata");

			dataNode.InnerHtml = jsonString;

			return htmlDocument.DocumentNode.OuterHtml;
		}
	}
}
