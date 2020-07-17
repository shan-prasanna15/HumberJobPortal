﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        protected SystemCountryCodeRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(SystemCountryCodeRepository<SystemCountryCodePoco> repository)
        {
            _repository = repository;
        }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, "Counrty Code cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, "Country Name Cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Delete(params SystemCountryCodePoco[] items)
        {
            _repository.Remove(items);
        }

        public void Get(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            _repository.GetSingle(where, navigationProperties);
        }
    }
}