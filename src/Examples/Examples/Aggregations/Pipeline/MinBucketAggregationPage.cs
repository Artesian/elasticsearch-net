using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Aggregations.Pipeline
{
	public class MinBucketAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line37()
		{
			// tag::e668549ff72fd0b9568667d1a817fc6e[]
			var response0 = new SearchResponse<object>();
			// end::e668549ff72fd0b9568667d1a817fc6e[]

			response0.MatchesExample(@"POST /sales/_search
			{
			    ""size"": 0,
			    ""aggs"" : {
			        ""sales_per_month"" : {
			            ""date_histogram"" : {
			                ""field"" : ""date"",
			                ""calendar_interval"" : ""month""
			            },
			            ""aggs"": {
			                ""sales"": {
			                    ""sum"": {
			                        ""field"": ""price""
			                    }
			                }
			            }
			        },
			        ""min_monthly_sales"": {
			            ""min_bucket"": {
			                ""buckets_path"": ""sales_per_month>sales"" \<1>
			            }
			        }
			    }
			}");
		}
	}
}