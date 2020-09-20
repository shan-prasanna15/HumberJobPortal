using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.CompanyJobEducation;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationService : CompanyJobEducationBase
    {
        private CompanyJobEducationLogic _logic;

        public CompanyJobEducationService()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }

        public override Task<CompanyJobEducationReply> GetCompanyJobEducation(IdCompJobEducation request, ServerCallContext context)
        {
            CompanyJobEducationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<CompanyJobEducationReply>(FromPoco(poco));
        }

        public override Task<CompanyJobEducations> GetCompanyJobEducations(Empty request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = _logic.GetAll();
            CompanyJobEducations collectCompJobEdu = new CompanyJobEducations();
            foreach(CompanyJobEducationPoco poco in pocos)
            {
                collectCompJobEdu.CompJobEdus.Add(FromPoco(poco));
            }
            return Task.FromResult<CompanyJobEducations>(collectCompJobEdu);            
        }

        public override Task<Empty> AddCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();
            foreach(CompanyJobEducationReply reply in request.CompJobEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();
            foreach (CompanyJobEducationReply reply in request.CompJobEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();
            foreach (CompanyJobEducationReply reply in request.CompJobEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private CompanyJobEducationPoco ToPoco(CompanyJobEducationReply reply)
        {
            return new CompanyJobEducationPoco()
            {
                Id = Guid.Parse(reply.Id),
                Job = Guid.Parse(reply.Job),
                Major = reply.Major,
                Importance = (Int16)reply.Importance,
                TimeStamp = reply.TimeStamp.ToByteArray()
            };
        }

        private CompanyJobEducationReply FromPoco(CompanyJobEducationPoco poco)
        {
            return new CompanyJobEducationReply()
            {
                Id = poco.Id.ToString(),
                Job = poco.Job.ToString(),
                Major = poco.Major.ToString(),
                Importance = (Int16)poco.Importance,
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp)
            };
        }
        
    }
}
