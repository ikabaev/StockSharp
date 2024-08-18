﻿namespace StockSharp.Messages;

/// <summary>
/// Available data info request.
/// </summary>
public class AvailableDataRequestMessage : Message, ISecurityIdMessage, ITransactionIdMessage
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AvailableDataRequestMessage"/>.
	/// </summary>
	public AvailableDataRequestMessage()
		: base(MessageTypes.AvailableDataRequest)
	{
	}

	/// <inheritdoc />
	[DataMember]
	public long TransactionId { get; set; }

	/// <inheritdoc />
	[DataMember]
	public SecurityId SecurityId { get; set; }

	/// <summary>
	/// Data type info.
	/// </summary>
	[DataMember]
	public DataType RequestDataType { get; set; }

	/// <summary>
	/// Format.
	/// </summary>
	[DataMember]
	public int? Format { get; set; }

	/// <summary>
	/// Include dates.
	/// </summary>
	[DataMember]
	public bool IncludeDates { get; set; }

        /// <summary>
        /// Create a copy of <see cref="AvailableDataRequestMessage"/>.
        /// </summary>
        /// <returns>Copy.</returns>
        public override Message Clone()
	{
		var clone = new AvailableDataRequestMessage
		{
			TransactionId = TransactionId,
			SecurityId = SecurityId,
			Format = Format,
			RequestDataType = RequestDataType?.TypedClone(),
			IncludeDates = IncludeDates,
		};

		CopyTo(clone);
		return clone;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return base.ToString() + $",TrId={TransactionId},SecId={SecurityId},DT={RequestDataType},Fmt={Format},Dates={IncludeDates}";
	}
}