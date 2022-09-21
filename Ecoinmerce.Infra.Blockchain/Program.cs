using Ecoinmerce.Infra.Blockchain;
using Nethereum.RPC.Eth.DTOs;
using SmartContracts.Contracts.ShoppingHandler.ContractDefinition;
using Ecoinmerce.Utils.Json;
using System.Reflection;

string fileName = "blockchainSettings.json";

//GAMBIARRA TOTAL
var relativePath = $"..\\..\\..\\..\\{fileName}";
var absolutePath = Path.GetFullPath(relativePath);

JsonModifier<BlockchainSettings> jsonModifier = new(absolutePath);

Console.WriteLine("Você quer fazer o deploy do SmartContract? (S/N)");
var deployAnswer = Console.ReadLine();

if (deployAnswer == "S")
{
    Console.WriteLine("Começando o deploy");

    Deployer deployer = new(jsonModifier.ParsedClass);

    ShoppingHandlerDeployment contractModel = new();
    TransactionReceipt receipt = await deployer.DeploySmartContract(contractModel);

    Console.WriteLine($"Deploy realizado. Agora, atualizando o {fileName}");

    jsonModifier.ParsedClass.SmartContract.Address = receipt.ContractAddress;
    jsonModifier.SaveDeserializedJson();

    Console.WriteLine($"{fileName} atualizado");
}