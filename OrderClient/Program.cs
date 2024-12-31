using Grpc.Net.Client;
using GrpcService.Protos;

var channel = GrpcChannel.ForAddress("https://localhost:7065");
var paymentsClient = new Payment.PaymentClient(channel);


var orderPaymentInfo = new OrderPaymentModel { OrderNumber = 1234, CreditCardNumber = "1234567890123456", CreditCardSecurityCode = "123", Amount = 100};
var paymentVerificationResponse = await paymentsClient.GetOrderPaymentAsync(orderPaymentInfo);
PrintOut(paymentVerificationResponse);

Console.ReadLine();

var orderPaymentInfo2 = new OrderPaymentModel { OrderNumber = 1235, CreditCardNumber = "123456789012356", CreditCardSecurityCode = "123", Amount = 100 };
var paymentVerificationResponse2 = await paymentsClient.GetOrderPaymentAsync(orderPaymentInfo2);
PrintOut(paymentVerificationResponse2);

Console.ReadLine();



static void PrintOut(PaymentVerificationResponse paymentVerificationResponse)
{
    if (paymentVerificationResponse.Success == true)
    {
        Console.WriteLine($"Order Number {paymentVerificationResponse.OrderNumber}.{paymentVerificationResponse.Message} ");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"Order Number {paymentVerificationResponse.OrderNumber}.{paymentVerificationResponse.Message}");
        Console.WriteLine();
    }
}
