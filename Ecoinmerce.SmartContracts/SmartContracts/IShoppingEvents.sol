// SPDX-License-Identifier: UNLICENSED
pragma solidity ^0.8.13;

interface IShoppingEvents {
    event PaymentDone(address indexed ecommerceWallet, uint paymentAmount, string purchaseIdentifier, address indexed customerWallet);
}
