using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.SecurityLoginsLog;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogService : SecurityLoginsLogBase
    {
        private SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogService()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
        }

        public override Task<SecurityLoginsLogReply> GetSecurityLoginsLog(IdSecLoginLog request, ServerCallContext context)
        {
            SecurityLoginsLogPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<SecurityLoginsLogReply>(FromPoco(poco));
        }

        public override Task<SecurityLoginsLogs> GetSecurityLoginsLogs(Empty request, ServerCallContext context)
        {
            List<SecurityLoginsLogPoco> pocos = _logic.GetAll();
            SecurityLoginsLogs collectSecLoginsLogs = new SecurityLoginsLogs();
            foreach(SecurityLoginsLogPoco poco in pocos)
            {
                collectSecLoginsLogs.SecLoginLogs.Add(FromPoco(poco));
            }
            return Task.FromResult<SecurityLoginsLogs>(collectSecLoginsLogs);
        }

        public override Task<Empty> AddSecurityLoginsLog(SecurityLoginsLogs request, ServerCallContext context)
        {
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach(SecurityLoginsLogReply reply in request.SecLoginLogs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLoginsLog(SecurityLoginsLogs request, ServerCallContext context)
        {
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach (SecurityLoginsLogReply reply in request.SecLoginLogs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSecurityLoginsLog(SecurityLoginsLogs request, ServerCallContext context)
        {
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach (SecurityLoginsLogReply reply in request.SecLoginLogs)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }


        private SecurityLoginsLogReply FromPoco(SecurityLoginsLogPoco poco)
        {
            return new SecurityLoginsLogReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                SourceIP = poco.SourceIP,
                LogonDate = Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.LogonDate, DateTimeKind.Utc)),
                IsSuccessful = poco.IsSuccesful
            };
        }
        private SecurityLoginsLogPoco ToPoco(SecurityLoginsLogReply reply)
        {
            return new SecurityLoginsLogPoco()
            {
                Id = Guid.Parse(reply.Id),
                Login = Guid.Parse(reply.Login),
                SourceIP = reply.SourceIP,
                LogonDate = reply.LogonDate.ToDateTime(),
                IsSuccesful = reply.IsSuccessful
            };
        }
    }
}
