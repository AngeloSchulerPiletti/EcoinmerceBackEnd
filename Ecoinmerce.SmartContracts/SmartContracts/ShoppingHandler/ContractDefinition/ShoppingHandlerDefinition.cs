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
        public static string BYTECODE = "608060405234801561001057600080fd5b50600080546001600160a01b03191633179055612710600155600a6002556105c58061003d6000396000f3fe60806040526004361061004a5760003560e01c806345b9522a1461004f5780636c6c11e414610077578063bac40cf314610099578063bb53e619146100b8578063dc45d08e146100e0575b600080fd5b61006261005d3660046103da565b610108565b60405190151581526020015b60405180910390f35b34801561008357600080fd5b5061009761009236600461049c565b610307565b005b3480156100a557600080fd5b506002545b60405190815260200161006e565b3480156100c457600080fd5b506000546040516001600160a01b03909116815260200161006e565b3480156100ec57600080fd5b506100aa6100fb3660046104b5565b6001600160a01b03163190565b600080341161016c5760405162461bcd60e51b815260206004820152602560248201527f5061796d656e742076616c7565206d7573742062652067726561746865722074604482015264068616e20360dc1b60648201526084015b60405180910390fd5b60006001543461017c91906104ed565b600254610189919061050f565b905060006101978234610526565b6000805460405192935090916001600160a01b039091169084908381818185875af1925050503d80600081146101e9576040519150601f19603f3d011682016040523d82523d6000602084013e6101ee565b606091505b505090506000866001600160a01b03168360405160006040518083038185875af1925050503d806000811461023f576040519150601f19603f3d011682016040523d82523d6000602084013e610244565b606091505b50509050801580610253575081155b156102ab5760405162461bcd60e51b815260206004820152602260248201527f5061796d656e74206661696c65642c20636f6e746163742042617274657248616044820152610e6d60f31b6064820152608401610163565b336001600160a01b0316876001600160a01b03167f6924568a81aaa6aa7ba3ff80013c955a08ebd293096e883cd3b8c3290a2256fd34896040516102f0929190610539565b60405180910390a360019450505050505b92915050565b6000546001600160a01b031633146103515760405162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b6044820152606401610163565b6103e88111156103a35760405162461bcd60e51b815260206004820152601860248201527f4e65772074617820697320746f6f20657870656e7369766500000000000000006044820152606401610163565b600255565b80356001600160a01b03811681146103bf57600080fd5b919050565b634e487b7160e01b600052604160045260246000fd5b600080604083850312156103ed57600080fd5b6103f6836103a8565b9150602083013567ffffffffffffffff8082111561041357600080fd5b818501915085601f83011261042757600080fd5b813581811115610439576104396103c4565b604051601f8201601f19908116603f01168101908382118183101715610461576104616103c4565b8160405282815288602084870101111561047a57600080fd5b8260208601602083013760006020848301015280955050505050509250929050565b6000602082840312156104ae57600080fd5b5035919050565b6000602082840312156104c757600080fd5b6104d0826103a8565b9392505050565b634e487b7160e01b600052601160045260246000fd5b60008261050a57634e487b7160e01b600052601260045260246000fd5b500490565b8082028115828204841417610301576103016104d7565b81810381811115610301576103016104d7565b82815260006020604081840152835180604085015260005b8181101561056d57858101830151858201606001528201610551565b506000606082860101526060601f19601f83011685010192505050939250505056fea264697066735822122063a74dac5d3169ca2e920b39ce4b06892b92be847a2051b9c3e49e744580e3ee64736f6c63430008110033";
        public ShoppingHandlerDeploymentBase() : base(BYTECODE) { }
        public ShoppingHandlerDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ChangeTaxQuocientFunction : ChangeTaxQuocientFunctionBase { }

    [Function("changeTaxQuocient")]
    public class ChangeTaxQuocientFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newTaxQuocient", 1)]
        public virtual BigInteger NewTaxQuocient { get; set; }
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

    public partial class GetTaxQuocientFunction : GetTaxQuocientFunctionBase { }

    [Function("getTaxQuocient", "uint256")]
    public class GetTaxQuocientFunctionBase : FunctionMessage
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
        [Parameter("address", "customerWallet", 4, true )]
        public virtual string CustomerWallet { get; set; }
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

    public partial class GetTaxQuocientOutputDTO : GetTaxQuocientOutputDTOBase { }

    [FunctionOutput]
    public class GetTaxQuocientOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
