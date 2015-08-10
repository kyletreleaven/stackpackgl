using System;
using stackpackgl.report;
using System.Collections.Generic;
using System.Linq;

namespace stackpackgl.client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int n = 10;
			float width = 20, gap = 5, totalWidth = n * width + (n - 1) * gap;

			IEnumerable<IBox3> boxes
				= Enumerable.Range(0,n)
					.SelectMany( i => 
				Enumerable.Range(0,n)
					.SelectMany( j =>
						Enumerable.Range(0,n)
						.Select( k => new {i=i,j=j,k=k} ) ) )
				.Select (s => new
					{
						x = -.5f * totalWidth + s.i * (width + gap),
						y = -.5f * totalWidth + s.j * (width + gap),
						z = -.5f * totalWidth + s.k * (width + gap)
					})
				.Select (s => (IBox3) new Box3 () {
				Xmin = s.x, Xmax = s.x + width,
				Ymin = s.y, Ymax = s.y + width,
				Zmin = s.z, Zmax = s.z + width
			});
			
			Console.WriteLine (boxes.ToThreeJs());

			//Console.ReadKey ();
		}
	}
}
