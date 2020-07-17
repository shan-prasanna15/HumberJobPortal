﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(SystemCountryCodeRepository<CompanyProfilePoco> repository) : base(repository)
        { }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "The website doesn't have a valid domain name"));
                }
                else if (!validateWebsite(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "The website doesn't have a valid domain name"));
                }


                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is required"));
                }
                else
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                    }
                    else
                    {
                        if (phoneComponents[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                    }
                }
            }
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
            
        }
        private Boolean validateWebsite(string email)
        {
            Boolean returnVal = false;
            List<string> validDomain = new List<string> { "ca", "com", "biz" };
            string[] splitRes = email.Split(".");
            string domain = splitRes[splitRes.Length - 1];
            if (validDomain.Contains(domain)){
                returnVal = true;
            }
            return returnVal;
        }
    }
}
