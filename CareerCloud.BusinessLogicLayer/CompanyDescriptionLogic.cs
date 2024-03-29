﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        { }

        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyDescriptionPoco poco in pocos)
            {
                if(string.IsNullOrEmpty( poco.CompanyDescription ))
                {
                    exceptions.Add(new ValidationException(107, "Company Description Cannot be less than 3 characters"));
                }
                else if(poco.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, "Company Description Cannot be less than 3 characters"));
                }
                if(string.IsNullOrEmpty( poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(106, "Company Name cannot be less than 3 charaters"));
                }
                else if(poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(106, "Company Name cannot be less than 3 charaters"));
                }
            }
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
