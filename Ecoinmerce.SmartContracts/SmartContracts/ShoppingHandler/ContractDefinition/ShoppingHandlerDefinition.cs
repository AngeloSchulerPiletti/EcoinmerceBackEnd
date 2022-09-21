using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SmartContracts.Contracts.ShoppingHandler.ContractDefinition
{


    public partial class ShoppingHandlerDeployment : ShoppingHandlerDeploymentBase
    {
        public ShoppingHandlerDeployment() : base(BYTECODE) { }
        public ShoppingHandlerDeployment(string byteCode) : base(byteCode) { }
    }

    public class ShoppingHandlerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50600080546001600160a01b03191633179055606460015561058d806100376000396000f3fe60806040526004361061004a5760003560e01c806345b9522a1461004f57806363251ea614610077578063bb53e61914610099578063d086a872146100c1578063dc45d08e146100e0575b600080fd5b61006261005d3660046103c1565b610108565b60405190151581526020015b60405180910390f35b34801561008357600080fd5b50610097610092366004610483565b6102fa565b005b3480156100a557600080fd5b506000546040516001600160a01b03909116815260200161006e565b3480156100cd57600080fd5b506001545b60405190815260200161006e565b3480156100ec57600080fd5b506100d26100fb36600461049c565b6001600160a01b03163190565b600080341161016c5760405162461bcd60e51b815260206004820152602560248201527f5061796d656e742076616c7565206d7573742062652067726561746865722074604482015264068616e20360dc1b60648201526084015b60405180910390fd5b60006001543461017c91906104be565b9050600061018a82346104e0565b6000805460405192935090916001600160a01b039091169084908381818185875af1925050503d80600081146101dc576040519150601f19603f3d011682016040523d82523d6000602084013e6101e1565b606091505b505090506000866001600160a01b03168360405160006040518083038185875af1925050503d8060008114610232576040519150601f19603f3d011682016040523d82523d6000602084013e610237565b606091505b50509050801580610246575081155b1561029e5760405162461bcd60e51b815260206004820152602260248201527f5061796d656e74206661696c65642c20636f6e746163742042617274657248616044820152610e6d60f31b6064820152608401610163565b336001600160a01b0316876001600160a01b03167f6924568a81aaa6aa7ba3ff80013c955a08ebd293096e883cd3b8c3290a2256fd34896040516102e3929190610501565b60405180910390a360019450505050505b92915050565b6000546001600160a01b031633146103445760405162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b6044820152606401610163565b600581111561038a5760405162461bcd60e51b81526020600482015260126024820152714e65772074617820697320746f6f2062696760701b6044820152606401610163565b600155565b80356001600160a01b03811681146103a657600080fd5b919050565b634e487b7160e01b600052604160045260246000fd5b600080604083850312156103d457600080fd5b6103dd8361038f565b9150602083013567ffffffffffffffff808211156103fa57600080fd5b818501915085601f83011261040e57600080fd5b813581811115610420576104206103ab565b604051601f8201601f19908116603f01168101908382118183101715610448576104486103ab565b8160405282815288602084870101111561046157600080fd5b8260208601602083013760006020848301015280955050505050509250929050565b60006020828403121561049557600080fd5b5035919050565b6000602082840312156104ae57600080fd5b6104b78261038f565b9392505050565b6000826104db57634e487b7160e01b600052601260045260246000fd5b500490565b818103818111156102f457634e487b7160e01b600052601160045260246000fd5b82815260006020604081840152835180604085015260005b8181101561053557858101830151858201606001528201610519565b506000606082860101526060601f19601f83011685010192505050939250505056fea2646970667358221220d427524e9a629a61032fb47f86929ff4cd2610fcd4c2b9b1779ba34c5e208c7b64736f6c63430008110033";
        public ShoppingHandlerDeploymentBase() : base(BYTECODE) { }
        public ShoppingHandlerDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ChangeTaxDivisorFunction : ChangeTaxDivisorFunctionBase { }

    [Function("changeTaxDivisor")]
    public class ChangeTaxDivisorFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newTaxDivisor", 1)]
        public virtual BigInteger NewTaxDivisor { get; set; }
    }

    public partial class GetBarterHashWalletFunction : GetBarterHashWalletFunctionBase { }

    [Function("getBarterHashWallet", "address")]
    public class GetBarterHashWalletFunctionBase : FunctionMessage
    {

    }

    public partial class GetEtherBalanceFunction : GetEtherBalanceFunctionBase { }

    [Function("getEtherBalance", "uint256")]
    public class GetEtherBalanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "user", 1)]
        public virtual string User { get; set; }
    }

    public partial class GetTaxDivisorFunction : GetTaxDivisorFunctionBase { }

    [Function("getTaxDivisor", "uint256")]
    public class GetTaxDivisorFunctionBase : FunctionMessage
    {

    }

    public partial class PurchasePaymentFunction : PurchasePaymentFunctionBase { }

    [Function("purchasePayment", "bool")]
    public class PurchasePaymentFunctionBase : FunctionMessage
    {
        [Parameter("address", "ecommerceWallet", 1)]
        public virtual string EcommerceWallet { get; set; }
        [Parameter("string", "purchaseIdentifier", 2)]
        public virtual string PurchaseIdentifier { get; set; }
    }

    public partial class PaymentDoneEventDTO : PaymentDoneEventDTOBase { }

    [Event("PaymentDone")]
    public class PaymentDoneEventDTOBase : IEventDTO
    {
        [Parameter("address", "ecommerceWallet", 1, true )]
        public virtual string EcommerceWallet { get; set; }
        [Parameter("uint256", "paymentAmount", 2, false )]
        public virtual BigInteger PaymentAmount { get; set; }
        [Parameter("string", "purchaseIdentifier", 3, false )]
        public virtual string PurchaseIdentifier { get; set; }
        [Parameter("address", "costumerWallet", 4, true )]
        public virtual string CostumerWallet { get; set; }
    }



    public partial class GetBarterHashWalletOutputDTO : GetBarterHashWalletOutputDTOBase { }

    [FunctionOutput]
    public class GetBarterHashWalletOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetEtherBalanceOutputDTO : GetEtherBalanceOutputDTOBase { }

    [FunctionOutput]
    public class GetEtherBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetTaxDivisorOutputDTO : GetTaxDivisorOutputDTOBase { }

    [FunctionOutput]
    public class GetTaxDivisorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
