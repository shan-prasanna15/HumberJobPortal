using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.CompanyDescription;

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionService: CompanyDescriptionBase
    {
        private CompanyDescriptionLogic _logic;

        public CompanyDescriptionService()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        }

        public override Task<CompanyDescriptionReply> GetCompanyDescription(IdCompDescription request, ServerCallContext context)
        {
            CompanyDescriptionPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<CompanyDescriptionReply>(FromPoco(poco));
        }

        public override Task<CompanyDescriptions> GetCompanyDescriptions(Empty request, ServerCallContext context)
        {
            CompanyDescriptions collectCompDesc = new CompanyDescriptions();
            List < CompanyDescriptionPoco > pocos= _logic.GetAll();

            foreach(CompanyDescriptionPoco poco in pocos)
            {
                collectCompDesc.CompDescs.Add(FromPoco(poco));
            }
            return Task.FromResult<CompanyDescriptions>(collectCompDesc);
        }

        public override Task<Empty> AddCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach(CompanyDescriptionReply reply in request.CompDescs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach (CompanyDescriptionReply reply in request.CompDescs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach (CompanyDescriptionReply reply in request.CompDescs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
    
        private CompanyDescriptionReply FromPoco(CompanyDescriptionPoco poco)
        {
            return new CompanyDescriptionReply()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                LanguageId = poco.LanguageId.ToString(),
                CompanyName = poco.CompanyName.ToString(),
                CompanyDescription = poco.CompanyDescription.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp)
            };
        }

        private CompanyDescriptionPoco ToPoco(CompanyDescriptionReply reply)
        {
            return new CompanyDescriptionPoco()
            {
                Id = Guid.Parse(reply.Id),
                Company = Guid.Parse(reply.Company),
                LanguageId = reply.LanguageId,
                CompanyName = reply.CompanyName,
                CompanyDescription = reply.CompanyDescription,
                TimeStamp = reply.TimeStamp.ToByteArray()
            };
        }
    }
}
