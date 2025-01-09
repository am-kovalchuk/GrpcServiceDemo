using Grpc.Net.Client;
using GrpcService.Protos;
using ProtoBuf.Grpc.Client;
using Shared.Contracts;

//Set up
var channel = GrpcChannel.ForAddress("https://localhost:7065");
var paymentsClient = new Payment.PaymentClient(channel);

var individualClient = channel.CreateGrpcService<IRetrievalService>();

    // Individual Retrieval service Starts here
//var customer2 = await individualClient.Retrieve("0");
Console.ReadLine();

    //Sample Retrieval with Dummy Data
var customer1 = await individualClient.Retrieve("1");
Console.WriteLine(
    $"Name: {customer1.Name}, Email: {customer1.Email}, Payment Method: {customer1.PaymentMethod}"
    );

Console.ReadLine();


       // Couple of Order processing payment samples
var orderPaymentInfo = new OrderPaymentModel { OrderNumber = 1234, CreditCardNumber = "1234567890123456", CreditCardSecurityCode = "123", Amount = 100};
var paymentVerificationResponse = await paymentsClient.GetOrderPaymentAsync(orderPaymentInfo);
PrintOut(paymentVerificationResponse);

Console.ReadLine();

var orderPaymentInfo2 = new OrderPaymentModel { OrderNumber = 1235, CreditCardNumber = "123456789012356", CreditCardSecurityCode = "123", Amount = 100 };
var paymentVerificationResponse2 = await paymentsClient.GetOrderPaymentAsync(orderPaymentInfo2);
PrintOut(paymentVerificationResponse2);

Console.ReadLine();


//Print Method
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
