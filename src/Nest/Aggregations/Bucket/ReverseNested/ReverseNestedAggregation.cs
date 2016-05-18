﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<ReverseNestedAggregation>))]
	public interface IReverseNestedAggregation : IBucketAggregation
	{
		[JsonProperty("path")]
		Field Path { get; set; }
	}

	public class ReverseNestedAggregation : BucketAggregationBase, IReverseNestedAggregation
	{
		public override string TypeName => "reverse_nested";

		[JsonProperty("path")]
		public Field Path { get; set; }

		internal ReverseNestedAggregation() { }

		public ReverseNestedAggregation(string name) : base(name) { }

		internal override void WrapInContainer(AggregationContainer c) => c.ReverseNested = this;
	}

	public class ReverseNestedAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<ReverseNestedAggregationDescriptor<T>,IReverseNestedAggregation, T>
			, IReverseNestedAggregation
		where T : class
	{
		public override string TypeName => "reverse_nested";

		Field IReverseNestedAggregation.Path { get; set; }

		public ReverseNestedAggregationDescriptor<T> Path(Field path) => Assign(a => a.Path = path);

		public ReverseNestedAggregationDescriptor<T> Path(Expression<Func<T, object>> path) => Assign(a => a.Path = path);
	}
}
