using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.SecurityLogin;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginService: SecurityLoginBase
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginService()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        }

        public override Task<SecurityLoginReply> GetSecurityLogin(IdSecLog request, ServerCallContext context)
        {
            SecurityLoginPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<SecurityLoginReply>(FromPoco(poco));
        }

        public override Task<SecurityLogins> GetSecurityLogins(Empty request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = _logic.GetAll();
            SecurityLogins collectSecLogin = new SecurityLogins();
            foreach(SecurityLoginPoco poco in pocos)
            {
                collectSecLogin.SecLogins.Add(FromPoco(poco));
            }
            return Task.FromResult<SecurityLogins>(collectSecLogin);
        }

        public override Task<Empty> AddSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach(SecurityLoginReply reply in request.SecLogins)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach (SecurityLoginReply reply in request.SecLogins)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach (SecurityLoginReply reply in request.SecLogins)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private SecurityLoginReply FromPoco(SecurityLoginPoco poco)
        {
            return new SecurityLoginReply()
            {
                Id = poco.ToString(),
                Login = poco.Login.ToString(),
                Password = poco.Password.ToString(),
                Created = poco.Created == null? null: Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.Created, DateTimeKind.Utc)),
                PasswordUpdated = poco.PasswordUpdate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.PasswordUpdate, DateTimeKind.Utc)),
                AgreementAccepted = poco.AgreementAccepted == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.AgreementAccepted, DateTimeKind.Utc)),
                IsLocked = poco.IsLocked,
                IsInactive = poco.IsInactive,
                EmailAddress = poco.EmailAddress,
                PhoneNumber = poco.PhoneNumber,
                FullName = poco.FullName,
                ForceChangePassword = poco.ForceChangePassword,
                PrefferedLangage = poco.PrefferredLanguage,
                Timestamp = ByteString.CopyFrom(poco.TimeStamp)
            };
        }

        private SecurityLoginPoco ToPoco(SecurityLoginReply reply)
        {
            return new SecurityLoginPoco()
            {
                Id = Guid.Parse(reply.Id),
                Login = reply.Login,
                Password = reply.Password,
                Created = reply.Created.ToDateTime(),
                PasswordUpdate = reply.PasswordUpdated.ToDateTime(),
                AgreementAccepted = reply.AgreementAccepted.ToDateTime(),
                IsLocked = reply.IsLocked,
                IsInactive = reply.IsInactive,
                EmailAddress = reply.EmailAddress,
                PhoneNumber = reply.PhoneNumber,
                FullName = reply.FullName,
                ForceChangePassword = reply.ForceChangePassword,
                PrefferredLanguage = reply.PrefferedLangage,
                TimeStamp = reply.Timestamp.ToArray()
            };
        }
    }
}
