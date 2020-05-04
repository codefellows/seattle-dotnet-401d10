using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Models.Services
{
    public class PaymentService :IPayment
    {
        private IConfiguration _config;

        public PaymentService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string Run()
        {
            // controllers.Base for authoriseNet
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["AN-ApiLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AN-TransactionKey"]
            };

            // set a credit card. 
            // can be hard coded. or brought in through secrets

            // DO NOT ask the user for their credit number

            var creditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                cardCode = "1021"
            };

            customerAddressType billingAddress = GetAddress("someUserId");

            var paymentType = new paymentType { Item = creditCard };

            // this class takes everything we've defined, and puts it all in one object. 
            var potato = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 122.5m,
                payment = paymentType,
                billTo = billingAddress
            };

            var request = new createTransactionRequest { transactionRequest = potato };

            var controller = new createTransactionController(request);

            // This is going to produce an error!
            // to fix this error........
            // PM> install-package System.Configuration.ConfigurationManager
            controller.Execute();

            var response = controller.GetApiResponse();

            if(response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "success!";
                }
            }

            return "fail";

        }

        public customerAddressType GetAddress(string userName)
        {
            // make a call to the DB to get the billikng address
            // or you bring in what the user typed into the entry (may be saved into the db??)
            customerAddressType address = new customerAddressType
            {
                firstName = "Josie",
                lastName = "Kitty",
                address = "123 Cat Nip Lane",
                city = "Seattle",
                zip = "98004"
            };

            return address;
        }
    }
}

