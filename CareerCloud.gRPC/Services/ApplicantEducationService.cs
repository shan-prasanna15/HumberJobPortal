﻿using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantEducation;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationService: ApplicantEducationBase 
    {
        private ApplicantEducationLogic _logic;

        public ApplicantEducationService()
        {
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }

        public override Task<ApplicantEducationReply> GetApplicantEducation(IdRequest request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = _logic.Get(Guid.Parse(request.Id));
            return Task.FromResult<ApplicantEducationReply>( FromPoco(poco)) ;
        }

        public override Task<ApplicantEducations> GetApplicantEducations(Empty request, ServerCallContext context)
        {
            ApplicantEducations collectionAppEdu = new ApplicantEducations();
            List<ApplicantEducationPoco> pocos = _logic.GetAll();
            foreach(ApplicantEducationPoco poco in pocos)
            {
                collectionAppEdu.AppEdus.Add(FromPoco(poco));
            }

            return Task.FromResult<ApplicantEducations>(collectionAppEdu);
        }

        public override Task<Empty> AddApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();
            foreach(ApplicantEducationReply reply in request.AppEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        

        public override Task<Empty> DeleteApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();
            foreach (ApplicantEducationReply reply in request.AppEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();
            foreach (ApplicantEducationReply reply in request.AppEdus)
            {
                pocos.Add(ToPoco(reply));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private ApplicantEducationReply FromPoco(ApplicantEducationPoco poco)
        {
            return new ApplicantEducationReply()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                CertificateDiploma = poco.CertificateDiploma,
                Major = poco.Major,
                StartDate = poco.StartDate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.StartDate, DateTimeKind.Utc)),
                CompletionDate = poco.CompletionDate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.CompletionDate, DateTimeKind.Utc)),
                CompletionPercent = poco.CompletionPercent == null ? 0 : (byte)poco.CompletionPercent,
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp)

            };
        }
        
        private ApplicantEducationPoco ToPoco(ApplicantEducationReply reply)
        {
            return new ApplicantEducationPoco()
            {
                Id = Guid.Parse(reply.Id),
                Applicant = Guid.Parse(reply.Applicant),
                CertificateDiploma = reply.CertificateDiploma,
                Major = reply.Major,
                StartDate = reply.StartDate.ToDateTime(),
                CompletionDate = reply.CompletionDate.ToDateTime(),
                CompletionPercent = (byte?)reply.CompletionPercent,
                TimeStamp = reply.TimeStamp.ToByteArray()
            };
        }
    }
}
