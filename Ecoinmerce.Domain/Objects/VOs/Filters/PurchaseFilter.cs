using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Ecoinmerce.Domain.Objects.VOs.Filters;

public class PurchaseFilter
{
    private string _mainQuery { get; set; }

    public PurchaseFilter(string observationSearch,
                          bool? failed,
                          string blockHash,
                          string transactionHash,
                          string ecommerceWalletAddress,
                          string costumerWalletAddress,
                          DateTime? createdFrom,
                          DateTime? createdTo,
                          DateTime? paidFrom,
                          DateTime? paidTo,
                          decimal? amountPaidInEtherFrom,
                          decimal? amountPaidInEtherTo,
                          string purchaseIdentifier)
    {
        ObservationSearch = observationSearch;
        Failed = failed;
        BlockHash = blockHash;
        TransactionHash = transactionHash;
        EcommerceWalletAddress = ecommerceWalletAddress;
        CostumerWalletAddress = costumerWalletAddress;
        CreatedFrom = createdFrom;
        CreatedTo = createdTo;
        PaidFrom = paidFrom;
        PaidTo = paidTo;
        AmountPaidInEtherFrom = amountPaidInEtherFrom;
        AmountPaidInEtherTo = amountPaidInEtherTo;
        PurchaseIdentifier = purchaseIdentifier;
    }

    public string ObservationSearch { get; set; }
    public bool? Failed { get; set; }
    public string BlockHash { get; set; }
    public string TransactionHash { get; set; }
    [JsonIgnore]
    public int? EcommerceId { get; set; }
    public string EcommerceWalletAddress { get; set; }
    public string CostumerWalletAddress { get; set; }
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
    public DateTime? PaidFrom { get; set; }
    public DateTime? PaidTo { get; set; }
    public decimal? AmountPaidInEtherFrom { get; set; }
    public decimal? AmountPaidInEtherTo { get; set; }
    public string PurchaseIdentifier { get; set; }
    public string GetQuery()
    {
        StringBuilder builder = new();
        builder.Append("Select * ");
        builder.Append("From Purchases ");
        string query = GetBufferedQuery();
        if (query != null)
        {
            builder.Append("Where ");
            builder.Append(query);
        }
        return builder.ToString();
    }

    public string GetQueryId()
    {
        StringBuilder builder = new();
        builder.Append("Select Id ");
        builder.Append("From Purchases ");
        string query = GetBufferedQuery();
        if (query != null)
        {
            builder.Append("Where ");
            builder.Append(query);
        }
        return builder.ToString();
    }

    private string GetBufferedQuery()
    {
        if (_mainQuery == null) BuildQuery();
        return _mainQuery;
    }

    private void BuildQuery()
    {
        List<string> queries = new();

        if (ObservationSearch != null) queries.Add($"Observation LIKE '%{ObservationSearch}%'");

        if (Failed != null)
            queries.Add($"Failed = '{((bool)Failed ? '1' : '0')}'");

        if (BlockHash != null)
            queries.Add($"BlockHash = '{BlockHash}'");

        if (TransactionHash != null)
            queries.Add($"TransactionHash = '{TransactionHash}'");

        if (EcommerceWalletAddress != null)
            queries.Add($"EcommerceWalletAddress = '{EcommerceWalletAddress}'");

        if (CostumerWalletAddress != null)
            queries.Add($"CostumerWalletAddress = '{CostumerWalletAddress}'");

        if (CreatedFrom != null) queries.Add($"CreatedAt >= '{CreatedFrom}'");
        if (CreatedTo != null) queries.Add($"CreatedAt <= '{CreatedTo}'");

        if (PaidFrom != null) queries.Add($"PaidAt >= '{PaidFrom}'");
        if (PaidTo != null) queries.Add($"PaidAt <= '{PaidTo}'");

        if (EcommerceId != null) queries.Add($"EcommerceId = {EcommerceId}");

        if (AmountPaidInEtherFrom != null) queries.Add($"AmountPaidInEther >= {AmountPaidInEtherFrom}");
        if (AmountPaidInEtherTo != null) queries.Add($"AmountPaidInEther <= {AmountPaidInEtherTo}");

        if (PurchaseIdentifier != null) queries.Add($" PurchaseIdentifier = '{PurchaseIdentifier}'");

        _mainQuery = queries.Count > 0 ?
            String.Join(" AND ", queries.ToArray()) :
            null;
    }

}
