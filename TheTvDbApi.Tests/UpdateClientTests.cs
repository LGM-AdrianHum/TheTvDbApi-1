<<<<<<< HEAD
﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheTvDbApi.Updates;

namespace TheTvDbApi.Tests
{
    [TestClass]
    public class UpdateClientTests
    {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void UpdateTest()
        {
            var client = new TheTvDbClient(Apikey);
            var res1 = client.UpdateClient.Get(1508481362);
            var res2 = client.UpdateClient.Get(DateTime.Today.AddDays(-3));
            var res3 = client.UpdateClient.Get(DateTime.Today.AddDays(-5), DateTime.Today.AddDays(-1));
            Assert.IsNotNull(res1);
            Assert.IsTrue(res1.Any());
            Assert.IsTrue(res1.Length>0);

            Assert.IsNotNull(res2);
            Assert.IsTrue(res2.Any());
            Assert.IsTrue(res2.Length > 0);

            Assert.IsNotNull(res3);
            Assert.IsTrue(res3.Any());
            Assert.IsTrue(res3.Length > 0);

        }

        [TestMethod]
        public void EpochTimeTest()
        {
            var r = DateTime.Today;
            var res1 = r.ToUnixTime();
            var res2 = res1.FromUnixTime();

            Assert.AreEqual(r, res2);
            Assert.IsTrue(res1 > 0);
        }


    }
}
=======
﻿//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi.Tests/UpdateClientTests.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:44 AM
// Modified : 2017-10-27-7:46 AM

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheTvDbApi.Tests
{
    [TestClass]
    public class UpdateClientTests
    {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void UpdateTest()
        {
            var client = new TheTvDbClient(Apikey);
            var res1 = client.UpdateClient.Get(1508481362);
            var res2 = client.UpdateClient.Get(DateTime.Today.AddDays(-3));
            var res3 = client.UpdateClient.Get(DateTime.Today.AddDays(-5), DateTime.Today.AddDays(-1));
            Assert.IsNotNull(res1);
            Assert.IsTrue(res1.Any());
            Assert.IsTrue(res1.Length > 0);

            Assert.IsNotNull(res2);
            Assert.IsTrue(res2.Any());
            Assert.IsTrue(res2.Length > 0);

            Assert.IsNotNull(res3);
            Assert.IsTrue(res3.Any());
            Assert.IsTrue(res3.Length > 0);
        }

        [TestMethod]
        public void EpochTimeTest()
        {
            var r = DateTime.Today;
            var res1 = r.ToUnixTime();
            var res2 = res1.FromUnixTime();

            Assert.AreEqual(r, res2);
            Assert.IsTrue(res1 > 0);
        }
    }
}
>>>>>>> 460629e6741991f642b92ca3c4200e7a9b1bd8a0
