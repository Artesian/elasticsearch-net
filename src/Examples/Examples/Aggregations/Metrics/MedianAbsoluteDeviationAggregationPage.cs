using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Aggregations.Metrics
{
	public class MedianAbsoluteDeviationAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line28()
		{
			// tag::25ed47fcb890fcf8d8518ae067362d18[]
			var response0 = new SearchResponse<object>();
			// end::25ed47fcb890fcf8d8518ae067362d18[]

			response0.MatchesExample(@"GET reviews/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""review_average"": {
			      ""avg"": {
			        ""field"": ""rating""
			      }
			    },
			    ""review_variability"": {
			      ""median_absolute_deviation"": {
			        ""field"": ""rating"" \<1>
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line88()
		{
			// tag::9d662fc9f943c287b7144f5e4e2ae358[]
			var response0 = new SearchResponse<object>();
			// end::9d662fc9f943c287b7144f5e4e2ae358[]

			response0.MatchesExample(@"GET reviews/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""review_variability"": {
			      ""median_absolute_deviation"": {
			        ""field"": ""rating"",
			        ""compression"": 100
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line118()
		{
			// tag::bb964122f7d31b2f17c299d47ab3bdf3[]
			var response0 = new SearchResponse<object>();
			// end::bb964122f7d31b2f17c299d47ab3bdf3[]

			response0.MatchesExample(@"GET reviews/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""review_variability"": {
			      ""median_absolute_deviation"": {
			        ""script"": {
			          ""lang"": ""painless"",
			          ""source"": ""doc['rating'].value * params.scaleFactor"",
			          ""params"": {
			            ""scaleFactor"": 2
			          }
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line143()
		{
			// tag::920362adc347f4268b29751d638b2e87[]
			var response0 = new SearchResponse<object>();
			// end::920362adc347f4268b29751d638b2e87[]

			response0.MatchesExample(@"GET reviews/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""review_variability"": {
			      ""median_absolute_deviation"": {
			        ""script"": {
			          ""id"": ""my_script"",
			          ""params"": {
			            ""field"": ""rating""
			          }
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line174()
		{
			// tag::87f854393d715aabf4d45e90a8eb74ce[]
			var response0 = new SearchResponse<object>();
			// end::87f854393d715aabf4d45e90a8eb74ce[]

			response0.MatchesExample(@"GET reviews/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""review_variability"": {
			      ""median_absolute_deviation"": {
			        ""field"": ""rating"",
			        ""missing"": 5
			      }
			    }
			  }
			}");
		}
	}
}