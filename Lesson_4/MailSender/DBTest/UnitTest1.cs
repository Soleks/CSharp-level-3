using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender;
using System.Collections.ObjectModel;

namespace DBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelectTest()
        {
            DbClientTest dbTest = new DbClientTest();
            ObservableCollection<Dto.Email> _email = dbTest.SelectEmails();

            Assert.IsNotNull(_email);
            Assert.AreEqual("test@mail.ru", _email[0].UserEmail);
        }
    }
}
