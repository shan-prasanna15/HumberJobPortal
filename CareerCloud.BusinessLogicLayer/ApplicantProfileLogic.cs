﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(SystemCountryCodeRepository<ApplicantProfilePoco> repository) : base(repository)
        { }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(ApplicantProfilePoco poco in pocos)
            {
                if(poco.CurrentSalary < 0)
                {
                    exceptions.Add(new ValidationException(111, "Current Salary cannot be a negative value"));
                }
                if(poco.CurrentRate< 0)
                {
                    exceptions.Add(new ValidationException(112, "Current Rate cannot be a negative value"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
