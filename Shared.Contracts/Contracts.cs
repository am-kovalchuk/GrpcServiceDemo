using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Shared.Contracts;

[DataContract]
public class IndividualInfo
{
    [DataMember(Order = 1)]
    public string Id { get; set; }
    [DataMember(Order = 2)] 
    public string? Name { get; set; }
    [DataMember(Order = 3)] 
    public string? Email { get;set; }
    [DataMember(Order = 4)] 
    public string? PaymentMethod { get; set; }
}

[ServiceContract]
public interface IRetrievalService
{
    [OperationContract]
    Task<IndividualInfo> Retrieve(string id, CallContext context = default);
}