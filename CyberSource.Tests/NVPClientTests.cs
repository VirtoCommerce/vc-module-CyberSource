using CyberSource.Clients;
using System;
using System.Collections;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Payment.Model;
using Xunit;

namespace CyberSource.Tests
{
    public class NVPClientTests
    {
        private static string MerchantId = "virtocommerce_test",
                              KeysDirectory = @"D:\projects\vc-other\vc-module-CyberSource\Cyber.Source"
            ;

        [Fact]
        [Trait("Category", "CI")]
        public void ProcessPayment_successfull()
        {
            //arrange
            var request = PrepareProcessPaymentRequest(false);

            //act
            var reply = NVPClient.RunTransaction(TransactionConfiguration, request);


            //assert
            Assert.Equal("ACCEPT", reply["decision"]);
            Assert.Equal("100", reply["reasonCode"]);
        }

        [Fact]
        [Trait("Category", "CI")]
        public void ProcessPayment_failing()
        {
            //arrange
            var request = PrepareProcessPaymentRequest(false);

            //act
            var reply = NVPClient.RunTransaction(request);


            //assert
            Assert.Equal("ACCEPT", reply["decision"]);
            Assert.Equal("100", reply["reasonCode"]);
        }

        public Configuration TransactionConfiguration
        {
            get
            {
                return new Configuration()
                {
                    MerchantID = MerchantId,
                    KeysDirectory = KeysDirectory,
                    SendToProduction = false
                };
            }
        }

        private Hashtable PrepareProcessPaymentRequest(bool IsSeparatePaymentAction)
        {
            Hashtable request = new Hashtable();
            request.Add("merchantID", MerchantId);
            request.Add("merchantReferenceCode", "payment" + Guid.NewGuid().ToString());

            if (IsSeparatePaymentAction)
            {
                request.Add("ccAuthService_run", "true");
            }
            else
            {
                request.Add("ccAuthService_run", "true");
                request.Add("ccCaptureService_run", "true");
            }

            SetBillingAddress(GetBillingAddress(), request);
            SetCreditCardInfo(GetBankCardInfo(), request);

            request.Add("purchaseTotals_currency", "USD");
            request.Add("item_0_unitPrice", "123.45");
            //request.Add("item_0_quantity", "1");

            return request;
        }

        private Address GetBillingAddress()
        {
            return new Address
            {
                AddressType = AddressType.BillingAndShipping,
                Phone = "+68787687",
                PostalCode = "19142",
                CountryCode = "US",
                CountryName = "United states",
                Email = "user@mail.com",
                FirstName = "first name",
                LastName = "last name",
                Line1 = "6025 Greenway Ave",
                City = "Philadelphia",
                RegionId = "PA",
                RegionName = "Pennsylvania",
                Organization = "org1"
            };
        }

        private void SetBillingAddress(Address address, Hashtable request)
        {
            request.Add("billTo_firstName", address.FirstName);
            request.Add("billTo_lastName", address.LastName);
            request.Add("billTo_street1", address.Line1);

            if (!string.IsNullOrEmpty(address.Line2))
                request.Add("billTo_street2", address.Line2);

            request.Add("billTo_city", address.City);
            request.Add("billTo_state", address.RegionName);
            request.Add("billTo_postalCode", address.PostalCode);
            request.Add("billTo_country", address.CountryName);

            if (!string.IsNullOrEmpty(address.Email))
                request.Add("billTo_email", address.Email);

            if (!string.IsNullOrEmpty(address.Phone))
                request.Add("billTo_phone", address.Phone);
        }

        private BankCardInfo GetBankCardInfo()
        {
            return new BankCardInfo
            {
                BankCardNumber = "4711100000000000",
                BankCardMonth = 11,
                BankCardYear = 22
            };
        }

        private void SetCreditCardInfo(BankCardInfo bankCardInfo, Hashtable request)
        {
            request.Add("card_accountNumber", bankCardInfo.BankCardNumber);
            request.Add("card_expirationMonth", bankCardInfo.BankCardMonth);
            request.Add("card_expirationYear", bankCardInfo.BankCardYear);
        }
    }
}
