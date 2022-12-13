using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace Ecoinmerce.Domain.Objects.VOs.Filters;

public class PurchaseFilter
{
    private readonly string _mainQuery;

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

        List<string> queries = new();

        if (ObservationSearch != null) queries.Add($"Observation LIKE '%{ObservationSearch}%'");

        if (Failed != null)
            queries.Add($"Failed = {Failed}");

        if (BlockHash != null)
            queries.Add($"BlockHash = {BlockHash}");

        if (TransactionHash != null)
            queries.Add($"TransactionHash = {TransactionHash}");

        if (EcommerceWalletAddress != null)
            queries.Add($"EcommerceWalletAddress = {EcommerceWalletAddress}");

        if (CostumerWalletAddress != null)
            queries.Add($"CostumerWalletAddress = {CostumerWalletAddress}");

        if (CreatedFrom != null)
        {
            if (CreatedTo == null) queries.Add($"CreatedAt >= {CreatedFrom}");
            else queries.Add($"CreatedAt >= {CreatedFrom} AND CreatedAt <= {CreatedTo}");
        }

        if (PaidFrom != null)
        {
            if (PaidTo == null) queries.Add($"PaidAt >= {PaidFrom}");
            else queries.Add($"PaidAt >= {PaidFrom} AND PaidAt <= {PaidTo}");
        }

        if (AmountPaidInEtherFrom != null)
        {
            if (AmountPaidInEtherTo == null) queries.Add($"AmountPaidInEther >= {AmountPaidInEtherFrom}");
            else queries.Add($"AmountPaidInEther >= {AmountPaidInEtherFrom} AND AmountPaidInEther <= {AmountPaidInEtherTo}");
        }

        if (PurchaseIdentifier != null) queries.Add($" PurchaseIdentifier = {PurchaseIdentifier}");

        _mainQuery = queries.Count > 0 ?
            String.Join(" AND ", queries.ToArray()) :
            null;
    }

    public string ObservationSearch { get; set; }
    public bool? Failed { get; set; }
    public string BlockHash { get; set; }
    public string TransactionHash { get; set; }
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
        if (_mainQuery != null)
        {
            builder.Append("Where ");
            builder.Append(_mainQuery);
        }
        return builder.ToString();
    }

    public string GetQueryId()
    {
        StringBuilder builder = new();
        builder.Append("Select Id ");
        builder.Append("From Purchases ");
        if (_mainQuery != null)
        {
            builder.Append("Where ");
            builder.Append(_mainQuery);
        }
        return builder.ToString();
    }
}
