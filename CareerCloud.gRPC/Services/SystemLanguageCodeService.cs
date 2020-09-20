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
using static CareerCloud.gRPC.Protos.SystemLanguageCode;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService: SystemLanguageCodeBase
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeService()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
        }

        public override Task<SystemLanguageCodeReply> GetSystemLanguageCode(IdLanguage request, ServerCallContext context)
        {
            SystemLanguageCodePoco poco = _logic.Get(request.Id);
            return Task.FromResult<SystemLanguageCodeReply>(FromPoco(poco));
        }

        public override Task<SystemLanguageCodes> GetSystemLanguageCodes(Empty request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> pocos = _logic.GetAll();
            SystemLanguageCodes collectSysLangCodes = new SystemLanguageCodes();
            foreach(SystemLanguageCodePoco poco in pocos)
            {
                collectSysLangCodes.SystemLangCodes.Add(FromPoco(poco));
            }
            return Task.FromResult<SystemLanguageCodes>(collectSysLangCodes);
        }

        public override Task<Empty> AddSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach(SystemLanguageCodeReply reply in request.SystemLangCodes)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach (SystemLanguageCodeReply reply in request.SystemLangCodes)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach (SystemLanguageCodeReply reply in request.SystemLangCodes)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private SystemLanguageCodeReply FromPoco(SystemLanguageCodePoco poco)
        {
            return new SystemLanguageCodeReply
            {
                LanguageID = poco.LanguageID.ToString(),
                Name = poco.Name.ToString(),
                NativeName = poco.NativeName.ToString()
            };
        }

        private SystemLanguageCodePoco ToPoco (SystemLanguageCodeReply reply)
        {
            return new SystemLanguageCodePoco()
            {
                LanguageID = reply.LanguageID,
                Name = reply.Name,
                NativeName = reply.NativeName
            };
        }
    }
}
