using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Mapping.Params
{
	public class FielddataPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line58()
		{
			// tag::ef9111c1648d7820925f12e07d1346c5[]
			var response0 = new SearchResponse<object>();
			// end::ef9111c1648d7820925f12e07d1346c5[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""mappings"": {
			    ""properties"": {
			      ""my_field"": { \<1>
			        ""type"": ""text"",
			        ""fields"": {
			          ""keyword"": { \<2>
			            ""type"": ""keyword""
			          }
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line86()
		{
			// tag::a7c15fe6b5779c84ce9a34bf4b2a7ab7[]
			var response0 = new SearchResponse<object>();
			// end::a7c15fe6b5779c84ce9a34bf4b2a7ab7[]

			response0.MatchesExample(@"PUT my_index/_mapping
			{
			  ""properties"": {
			    ""my_field"": { \<1>
			      ""type"":     ""text"",
			      ""fielddata"": true
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line120()
		{
			// tag::6a81d00f0d73bc5985e76b3cadab645e[]
			var response0 = new SearchResponse<object>();
			// end::6a81d00f0d73bc5985e76b3cadab645e[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""mappings"": {
			    ""properties"": {
			      ""tag"": {
			        ""type"": ""text"",
			        ""fielddata"": true,
			        ""fielddata_frequency_filter"": {
			          ""min"": 0.001,
			          ""max"": 0.1,
			          ""min_segment_size"": 500
			        }
			      }
			    }
			  }
			}");
		}
	}
}