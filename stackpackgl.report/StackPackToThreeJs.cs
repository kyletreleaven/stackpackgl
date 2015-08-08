using System;
using System.Collections.Generic;

namespace stackpackgl.report
{
	public interface IBox2
	{
		float Xmin {get;}
		float Xmax {get;}
		float Ymin {get;}
		float Ymax {get;}
	}

	public struct Box2 : IBox2
	{
		public float Xmin {get;set;}
		public float Xmax {get;set;}
		public float Ymin {get;set;}
		public float Ymax {get;set;}
	}

	public static class StackPackToThreeJs
	{
		public static string ToThreeJs(this ICollection<IBox2> boxes)
		{
			return "Hello World!";
		}
	}
}

