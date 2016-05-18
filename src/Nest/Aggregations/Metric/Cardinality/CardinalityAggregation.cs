﻿using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<CardinalityAggregation>))]
	public interface ICardinalityAggregation : IMetricAggregation
	{
		[JsonProperty("precision_threshold")]
		int? PrecisionThreshold { get; set; }

		[JsonProperty("rehash")]
		bool? Rehash { get; set; }
	}

	public class CardinalityAggregation : MetricAggregationBase, ICardinalityAggregation
	{
		public override string TypeName => "cardinality";

		public int? PrecisionThreshold { get; set; }
		public bool? Rehash { get; set; }

		internal CardinalityAggregation() { }

		public CardinalityAggregation(string name, Field field) : base(name, field) { }

		internal override void WrapInContainer(AggregationContainer c) => c.Cardinality = this;
	}

	public class CardinalityAggregationDescriptor<T>
		: MetricAggregationDescriptorBase<CardinalityAggregationDescriptor<T>, ICardinalityAggregation, T>
			, ICardinalityAggregation
		where T : class
	{
		public override string TypeName => "cardinality";

		int? ICardinalityAggregation.PrecisionThreshold { get; set; }

		bool? ICardinalityAggregation.Rehash { get; set; }

		public CardinalityAggregationDescriptor<T> PrecisionThreshold(int precisionThreshold)
			=> Assign(a => a.PrecisionThreshold = precisionThreshold);

		public CardinalityAggregationDescriptor<T> Rehash(bool rehash = true) => Assign(a => a.Rehash = rehash);

	}
}
