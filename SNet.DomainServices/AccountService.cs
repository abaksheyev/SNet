using SNet.Common;
using SNet.Common.DomainModels;
using SNet.DomainServices.Mapping;
using SNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SNet.Repositories.DataModel;


namespace SNet.DomainServices.Interfaces
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            ServiceMapping.Configure();
        }

        //
        public ResultServiceOperation<AccountDomain> GetAll()
        {
            var rezult = new ResultServiceOperation<AccountDomain>();

            var listAccount = _accountRepository.GetAll().ToList<Account>();

            List<AccountDomain> list = Mapper.Map<List<Account>, List<AccountDomain>>(listAccount);

            rezult.Data = list;

            return rezult;
        }

        /// <summary>
        /// Save OR Create new Entity
        /// </summary>
        /// <returns></returns>
        public ResultServiceOperation<AccountDomain> Save(AccountDomain entity)
        {
            var rezult = new ResultServiceOperation<AccountDomain>();

            try
            {
                Account dbEntity = Mapper.Map<Account>(entity);
                _accountRepository.Update(dbEntity);

                _accountRepository.SaveChanges();
            }
            catch (Exception exc)
            {
                rezult.Errors.Add(string.Empty, exc.Message);
            }

            return rezult;
        }

        /// <summary>
        /// Activate Account
        /// </summary>
        /// <returns></returns>
        public ResultServiceOperation<AccountDomain> Activate(AccountDomain entity)
        {
            var rezult = new ResultServiceOperation<AccountDomain>();
          
            try
            {
                Account dbEntity = Mapper.Map<Account>(entity);
                dbEntity.EmailVerified = true;

                _accountRepository.Update(dbEntity);

                _accountRepository.SaveChanges();
            }
            catch (Exception exc)
            {
                rezult.Errors.Add(string.Empty, exc.Message);
            }

            return rezult;
        }


        /// <summary>
        /// Delete from database specified Account
        /// </summary>
        /// <returns></returns>
        public ResultServiceOperation<AccountDomain> Delete(AccountDomain entity)
        {
            var rezult = new ResultServiceOperation<AccountDomain>();

            try
            {
                Account dbEntity = Mapper.Map<Account>(entity);
                
                _accountRepository.Delete(dbEntity);

                _accountRepository.SaveChanges();
            }
            catch (Exception exc)
            {
                rezult.Errors.Add(string.Empty, exc.Message);
            }

            return rezult;
        }

    }
}
