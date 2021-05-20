using _02Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02Claims_Test
{
    [TestClass]
    public class ClaimsRepoTests
    {
        [TestMethod]
        public void AddClaimTest_ShouldGetCorrectBoolean()
        {
            Claims claim = new Claims();
            Claims_Repo repo = new Claims_Repo();

            bool addResult = repo.AddClaim(claim);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnCollectionOfClaims()
        {
            Claims claim = new Claims();
            Claims_Repo repo = new Claims_Repo();
            repo.AddClaim(claim);

            List<Claims> listClaims = repo.GetClaims();

            bool listHasClaims = listClaims.Contains(claim);
            Assert.IsTrue(listHasClaims);
        }
    }
}
