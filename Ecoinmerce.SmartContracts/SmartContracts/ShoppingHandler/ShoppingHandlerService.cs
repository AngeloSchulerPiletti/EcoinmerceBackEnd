using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SmartContracts.Contracts.ShoppingHandler.ContractDefinition;

namespace SmartContracts.Contracts.ShoppingHandler
{
    public partial class ShoppingHandlerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ShoppingHandlerDeployment shoppingHandlerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ShoppingHandlerDeployment>().SendRequestAndWaitForReceiptAsync(shoppingHandlerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ShoppingHandlerDeployment shoppingHandlerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ShoppingHandlerDeployment>().SendRequestAsync(shoppingHandlerDeployment);
        }

        public static async Task<ShoppingHandlerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ShoppingHandlerDeployment shoppingHandlerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, shoppingHandlerDeployment, cancellationTokenSource);
            return new ShoppingHandlerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ShoppingHandlerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ChangeTaxDivisorRequestAsync(ChangeTaxDivisorFunction changeTaxDivisorFunction)
        {
             return ContractHandler.SendRequestAsync(changeTaxDivisorFunction);
        }

        public Task<TransactionReceipt> ChangeTaxDivisorRequestAndWaitForReceiptAsync(ChangeTaxDivisorFunction changeTaxDivisorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeTaxDivisorFunction, cancellationToken);
        }

        public Task<string> ChangeTaxDivisorRequestAsync(BigInteger newTaxDivisor)
        {
            var changeTaxDivisorFunction = new ChangeTaxDivisorFunction();
                changeTaxDivisorFunction.NewTaxDivisor = newTaxDivisor;
            
             return ContractHandler.SendRequestAsync(changeTaxDivisorFunction);
        }

        public Task<TransactionReceipt> ChangeTaxDivisorRequestAndWaitForReceiptAsync(BigInteger newTaxDivisor, CancellationTokenSource cancellationToken = null)
        {
            var changeTaxDivisorFunction = new ChangeTaxDivisorFunction();
                changeTaxDivisorFunction.NewTaxDivisor = newTaxDivisor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeTaxDivisorFunction, cancellationToken);
        }

        public Task<string> GetBarterHashWalletQueryAsync(GetBarterHashWalletFunction getBarterHashWalletFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBarterHashWalletFunction, string>(getBarterHashWalletFunction, blockParameter);
        }

        
        public Task<string> GetBarterHashWalletQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBarterHashWalletFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> GetEtherBalanceQueryAsync(GetEtherBalanceFunction getEtherBalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEtherBalanceFunction, BigInteger>(getEtherBalanceFunction, blockParameter);
        }

        
        public Task<BigInteger> GetEtherBalanceQueryAsync(string user, BlockParameter blockParameter = null)
        {
            var getEtherBalanceFunction = new GetEtherBalanceFunction();
                getEtherBalanceFunction.User = user;
            
            return ContractHandler.QueryAsync<GetEtherBalanceFunction, BigInteger>(getEtherBalanceFunction, blockParameter);
        }

        public Task<BigInteger> GetTaxDivisorQueryAsync(GetTaxDivisorFunction getTaxDivisorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTaxDivisorFunction, BigInteger>(getTaxDivisorFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTaxDivisorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTaxDivisorFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> PurchasePaymentRequestAsync(PurchasePaymentFunction purchasePaymentFunction)
        {
             return ContractHandler.SendRequestAsync(purchasePaymentFunction);
        }

        public Task<TransactionReceipt> PurchasePaymentRequestAndWaitForReceiptAsync(PurchasePaymentFunction purchasePaymentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchasePaymentFunction, cancellationToken);
        }

        public Task<string> PurchasePaymentRequestAsync(string ecommerceWallet, string purchaseIdentifier)
        {
            var purchasePaymentFunction = new PurchasePaymentFunction();
                purchasePaymentFunction.EcommerceWallet = ecommerceWallet;
                purchasePaymentFunction.PurchaseIdentifier = purchaseIdentifier;
            
             return ContractHandler.SendRequestAsync(purchasePaymentFunction);
        }

        public Task<TransactionReceipt> PurchasePaymentRequestAndWaitForReceiptAsync(string ecommerceWallet, string purchaseIdentifier, CancellationTokenSource cancellationToken = null)
        {
            var purchasePaymentFunction = new PurchasePaymentFunction();
                purchasePaymentFunction.EcommerceWallet = ecommerceWallet;
                purchasePaymentFunction.PurchaseIdentifier = purchaseIdentifier;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchasePaymentFunction, cancellationToken);
        }
    }
}
