// SPDX-License-Identifier: UNLICENSED
pragma solidity ^0.8.13;

import "./IShoppingEvents.sol";

contract ShoppingHandler is IShoppingEvents{
	address payable barterHashWallet;
	uint taxDivisor;

	constructor(){
		barterHashWallet = payable(msg.sender);
		taxDivisor = 100;
	}

	function getTaxDivisor() public view returns(uint){
		return taxDivisor;
	}

	function getBarterHashWallet() public view returns(address){
		return barterHashWallet;
	}

	function getEtherBalance(address user) public view returns(uint){
		return address(user).balance;
	}

	function changeTaxDivisor(uint newTaxDivisor) public{
		require(msg.sender == barterHashWallet, "Access denied");
		require(newTaxDivisor <= 5, "New tax is too big");
		taxDivisor = newTaxDivisor;
	}

	function purchasePayment(address ecommerceWallet, string memory purchaseIdentifier) public payable returns(bool){
		require(msg.value > 0, "Payment value must be greather than 0");

		uint comission = msg.value/taxDivisor;
		uint payment = msg.value - comission;

		// payable(barterHashWallet).transfer(comission);
		// payable(ecommerceWallet).transfer(payment);
		(bool barterHashSuccess,) = barterHashWallet.call{value: comission}("");
		(bool ecommerceSuccess,) = ecommerceWallet.call{value: payment}("");
		if(!ecommerceSuccess || !barterHashSuccess) revert("Payment failed, contact BarterHash");

		emit PaymentDone(ecommerceWallet, msg.value, purchaseIdentifier, msg.sender);

		return true;
	} 
}
