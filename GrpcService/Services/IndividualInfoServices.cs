using Shared.Contracts;
using ProtoBuf.Grpc;
using Grpc.Core;
using ProtoBuf.Grpc.Configuration;

namespace GrpcService.Services
{
    public class IndividualInfoServices : IRetrievalService
    {

        public Task<IndividualInfo> Retrieve(string id, CallContext context = default)
        {
            
            if (id != "1") { throw new RpcException(new Status(StatusCode.InvalidArgument, "User not Found.")); };
            
            
              return Task.FromResult(
               new IndividualInfo()
               {
                   Id = id,
                   Name = "John Doe",
                   Email = "johndoe@email.com",
                   PaymentMethod = "1234567890123456"
               });
            
            
        }

        
    }
}
