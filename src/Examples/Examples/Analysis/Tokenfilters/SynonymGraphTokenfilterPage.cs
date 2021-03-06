using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class SynonymGraphTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line23()
		{
			// tag::2f071d36aa4aff5a2fafb3dadaa38b82[]
			var response0 = new SearchResponse<object>();
			// end::2f071d36aa4aff5a2fafb3dadaa38b82[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""analyzer"" : {
			                    ""search_synonyms"" : {
			                        ""tokenizer"" : ""whitespace"",
			                        ""filter"" : [""graph_synonyms""]
			                    }
			                },
			                ""filter"" : {
			                    ""graph_synonyms"" : {
			                        ""type"" : ""synonym_graph"",
			                        ""synonyms_path"" : ""analysis/synonym.txt""
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line59()
		{
			// tag::3d253e5a0029bc96cce484302319b772[]
			var response0 = new SearchResponse<object>();
			// end::3d253e5a0029bc96cce484302319b772[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""analyzer"" : {
			                    ""synonym"" : {
			                        ""tokenizer"" : ""standard"",
			                        ""filter"" : [""my_stop"", ""synonym_graph""]
			                    }
			                },
			                ""filter"" : {
			                    ""my_stop"": {
			                        ""type"" : ""stop"",
			                        ""stopwords"": [""bar""]
			                    },
			                    ""synonym_graph"" : {
			                        ""type"" : ""synonym_graph"",
			                        ""lenient"": true,
			                        ""synonyms"" : [""foo, bar => baz""]
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line119()
		{
			// tag::1a14fd905941ecbdbc943b05875afc6f[]
			var response0 = new SearchResponse<object>();
			// end::1a14fd905941ecbdbc943b05875afc6f[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym_graph"",
			                        ""synonyms"" : [
			                            ""lol, laughing out loud"",
			                            ""universe, cosmos""
			                        ]
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line151()
		{
			// tag::f0d7d6d5c878211704d4a5f1b2f6a247[]
			var response0 = new SearchResponse<object>();
			// end::f0d7d6d5c878211704d4a5f1b2f6a247[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym_graph"",
			                        ""format"" : ""wordnet"",
			                        ""synonyms"" : [
			                            ""s(100000001,1,'abstain',v,1,0)."",
			                            ""s(100000001,2,'refrain',v,1,0)."",
			                            ""s(100000001,3,'desist',v,1,0).""
			                        ]
			                    }
			                }
			            }
			        }
			    }
			}");
		}
	}
}