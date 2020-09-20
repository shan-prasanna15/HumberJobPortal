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
using static CareerCloud.gRPC.Protos.ApplicantProfile;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService: ApplicantProfileBase
    {
        private ApplicantProfileLogic _logic;

        public ApplicantProfileService()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        }

        public override Task<ApplicantProfileReply> GetApplicantProfile(IdAppProfile request, ServerCallContext context)
        {
            ApplicantProfilePoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<ApplicantProfileReply>(FromPoco(poco));
        }

        public override Task<ApplicantProfiles> GetApplicantProfiles(Empty request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = _logic.GetAll();
            ApplicantProfiles collectAppProfiles = new ApplicantProfiles();
            foreach(ApplicantProfilePoco poco in pocos)
            {
                collectAppProfiles.AppProfiles.Add(FromPoco(poco));
            }

            return Task.FromResult<ApplicantProfiles>(collectAppProfiles);
        }

        public override Task<Empty> AddApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach(ApplicantProfileReply reply in request.AppProfiles)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach (ApplicantProfileReply reply in request.AppProfiles)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach (ApplicantProfileReply reply in request.AppProfiles)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private ApplicantProfileReply FromPoco(ApplicantProfilePoco poco)
        {
            return new ApplicantProfileReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Id.ToString(),
                CurrentSalary = (double)poco.CurrentSalary,
                CurrentRate = (double)poco.CurrentSalary,
                Currency = poco.Currency.ToString(),
                Country = poco.Country.ToString(),
                Province = poco.Province.ToString(),
                Street = poco.Street.ToString(),
                City = poco.City.ToString(),
                PostalCode = poco.PostalCode.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp)
            };
        }

        private ApplicantProfilePoco ToPoco(ApplicantProfileReply reply)
        {
            return new ApplicantProfilePoco()
            {
                Id = Guid.Parse(reply.Id),
                Login = Guid.Parse(reply.Login),
                CurrentSalary = (decimal)reply.CurrentSalary,
                CurrentRate = (decimal)reply.CurrentRate,
                Currency = reply.Currency,
                Country = reply.Country,
                Province = reply.Province,
                Street = reply.Province,
                City = reply.City,
                PostalCode = reply.PostalCode,
                TimeStamp = reply.TimeStamp.ToByteArray()
            };
        }
    }
}
