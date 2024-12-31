using Grpc.Core;
using GrpcService.Protos;

namespace GrpcService.Services
{
    public class PaymentsServices : Payment.PaymentBase
    {
        private readonly ILogger<PaymentsServices> _logger;

        public PaymentsServices(ILogger<PaymentsServices> logger)
        {
            _logger = logger;
        }

        public override Task<PaymentVerificationResponse> GetOrderPayment(OrderPaymentModel request, ServerCallContext context)
        {
            PaymentVerificationResponse response = new PaymentVerificationResponse();

            if (request != null && request?.OrderNumber != null)
            {
                if (request.CreditCardNumber != null)
                {
                    //verify credid card number is 16 digits
                    int lengthCC = request.CreditCardNumber.Length;
                    int lengthCVC = request.CreditCardSecurityCode.Length;
                    response.OrderNumber = request.OrderNumber;

                    if (lengthCC == 16 && lengthCVC == 3 && request?.Amount != null)
                    {
                        response.Success = true;
                        response.Message = "The payment is Successful.";
                        return Task.FromResult(response);
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Invalid Credit Card. Please Try Again";
                        return Task.FromResult(response);
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "No Payment Method specified.";
                    return Task.FromResult(response);
                }
            }

            return Task.FromResult(response);
        }
    }
}
