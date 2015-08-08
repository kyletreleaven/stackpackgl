using System;
using stackpackgl.report;
using System.Collections.Generic;

namespace stackpackgl.client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (new HashSet<IBox2> ().ToThreeJs ());
		}
	}
}
