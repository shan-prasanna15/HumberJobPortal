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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantJobApplication;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationService : ApplicantJobApplicationBase
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationService()
        {
            _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
        }

        public override Task<ApplicantJobApplicationReply> GetApplicantJobApplication(IdAppJobAppReq request, ServerCallContext context)
        {        
            ApplicantJobApplicationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<ApplicantJobApplicationReply>(FromPoco(poco));
        }


        public override Task<ApplicantJobApplications> GetApplicantJobApplications(Empty request, ServerCallContext context)
        {
            ApplicantJobApplications collectionAppJobApp = new ApplicantJobApplications();
            List<ApplicantJobApplicationPoco> pocos = _logic.GetAll();
            foreach( ApplicantJobApplicationPoco poco in pocos)
            {
                collectionAppJobApp.AppJobApps.Add(FromPoco(poco));
            }

            return Task.FromResult<ApplicantJobApplications>(collectionAppJobApp);
        }

        public override Task<Empty> AddApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();
            foreach (ApplicantJobApplicationReply reply in request.AppJobApps)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();
            foreach (ApplicantJobApplicationReply reply in request.AppJobApps)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();
            foreach (ApplicantJobApplicationReply reply in request.AppJobApps)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private ApplicantJobApplicationReply FromPoco(ApplicantJobApplicationPoco poco)
        {
            return new ApplicantJobApplicationReply()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Job = poco.Job.ToString(),
                ApplicationDate = Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.ApplicationDate, DateTimeKind.Utc)),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp)
            };
        }

        private ApplicantJobApplicationPoco ToPoco(ApplicantJobApplicationReply reply)
        {
            return new ApplicantJobApplicationPoco()
            {
                Id = Guid.Parse(reply.Id),
                Applicant = Guid.Parse(reply.Applicant),
                Job = Guid.Parse(reply.Job),
                ApplicationDate = reply.ApplicationDate.ToDateTime(),
                TimeStamp = reply.TimeStamp.ToByteArray()
            };
        }
    }
}
