using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Aggregations.Bucket
{
	public class SignificanttermsAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line68()
		{
			// tag::290b845e59368e8aa8d1a56d7379afd0[]
			var response0 = new SearchResponse<object>();
			// end::290b845e59368e8aa8d1a56d7379afd0[]

			response0.MatchesExample(@"GET /_search
			{
			    ""query"" : {
			        ""terms"" : {""force"" : [ ""British Transport Police"" ]}
			    },
			    ""aggregations"" : {
			        ""significant_crime_types"" : {
			            ""significant_terms"" : { ""field"" : ""crime_type"" }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line129()
		{
			// tag::b2af9784f8530a363ac6e9f95b39677d[]
			var response0 = new SearchResponse<object>();
			// end::b2af9784f8530a363ac6e9f95b39677d[]

			response0.MatchesExample(@"GET /_search
			{
			    ""aggregations"": {
			        ""forces"": {
			            ""terms"": {""field"": ""force""},
			            ""aggregations"": {
			                ""significant_crime_types"": {
			                    ""significant_terms"": {""field"": ""crime_type""}
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line207()
		{
			// tag::0868d8ac2fb5351e633184f897ee6866[]
			var response0 = new SearchResponse<object>();
			// end::0868d8ac2fb5351e633184f897ee6866[]

			response0.MatchesExample(@"GET /_search
			{
			    ""aggs"": {
			        ""hotspots"": {
			            ""geohash_grid"": {
			                ""field"": ""location"",
			                ""precision"": 5
			            },
			            ""aggs"": {
			                ""significant_crime_types"": {
			                    ""significant_terms"": {""field"": ""crime_type""}
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line468()
		{
			// tag::09d4a753140ee5a9ab9f4fc09047b588[]
			var response0 = new SearchResponse<object>();
			// end::09d4a753140ee5a9ab9f4fc09047b588[]

			response0.MatchesExample(@"GET /_search
			{
			    ""aggs"" : {
			        ""tags"" : {
			            ""significant_terms"" : {
			                ""field"" : ""tag"",
			                ""min_doc_count"": 10
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line511()
		{
			// tag::3fdaac87eb741a79f747633b5065323a[]
			var response0 = new SearchResponse<object>();
			// end::3fdaac87eb741a79f747633b5065323a[]

			response0.MatchesExample(@"GET /_search
			{
			    ""query"" : {
			        ""match"" : {
			            ""city"" : ""madrid""
			        }
			    },
			    ""aggs"" : {
			        ""tags"" : {
			            ""significant_terms"" : {
			                ""field"" : ""tag"",
			                ""background_filter"": {
			                	""term"" : { ""text"" : ""spain""}
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line570()
		{
			// tag::11a21cd0b9d31da7eda77c9384a29208[]
			var response0 = new SearchResponse<object>();
			// end::11a21cd0b9d31da7eda77c9384a29208[]

			response0.MatchesExample(@"GET /_search
			{
			    ""aggs"" : {
			        ""tags"" : {
			             ""significant_terms"" : {
			                 ""field"" : ""tags"",
			                 ""execution_hint"": ""map"" \<1>
			             }
			         }
			    }
			}");
		}
	}
}