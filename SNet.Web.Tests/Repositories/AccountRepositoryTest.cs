using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SNet.Interfaces;
using SNet.Repositories;
using SNet.Repositories.DataModel;
using SNet.Web;
using SNet.Web.Controllers;

namespace SNet.Web.Tests.Controllers
{
    [TestClass]
    public class AccountRepositoryTest
    {
        [TestMethod]
        public void Account_Create_New()
        {
            using (var context = new DataModelContainer())
            {
                var rep = new AccountRepository(context);

                var account = rep.Create();
                account.FirstName = "FirstName";
                account.LastName = "LastName";
                account.Email = "Email";
                account.EmailVerified = false;
                account.Username = "Username";
                account.Password = "Password";

                account.BirthDate = SqlDateTime.MaxValue.Value;
                account.CreateDate = SqlDateTime.MaxValue.Value;
                account.LastUpdateDate = SqlDateTime.MaxValue.Value;


                rep.Add(account);

                rep.SaveChanges();

            }
        }

        [TestMethod]
        public void Account_Delete()
        {
            throw new NotImplementedException(); 
        }

        [TestMethod]
        public void Account_Update()
        {
            throw new NotImplementedException();
        }
    }
}
