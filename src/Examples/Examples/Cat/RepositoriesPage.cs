using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Cat
{
	public class RepositoriesPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line8()
		{
			// tag::6fa570aac5033e3b25d3071a6c9ea3dc[]
			var response0 = new SearchResponse<object>();
			// end::6fa570aac5033e3b25d3071a6c9ea3dc[]

			response0.MatchesExample(@"GET /_cat/repositories?v");
		}
	}
}