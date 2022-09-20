using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customer customer)
        {
            customer.IsDeleted = true;
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerDeleted);          
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.IsDeleted ==false));
        }


        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == id && p.IsDeleted==false));
            
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Add(Customer customer)
        {
            customer.AddedAt = DateTime.Now;
            customer.Status = true;
            customer.IsDeleted = false;
            _customerDal.Add(customer);
           
            return new SuccessResult(Messages.CustomerAdded);
        }
    }

}
