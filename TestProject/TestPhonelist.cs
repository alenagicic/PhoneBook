using PhoneBook.Modules;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestPhonelist
    {
        [Fact]
        public void TestIfPhonelist_ActuallyReturnsAnything()
        {
            
            // Arrange
           PhoneList phoneList = new PhoneList();
            List<User> users = new List<User>();

            //Act
           var something = phoneList.GetListSavedUsers();

            //Assert
            Xunit.Assert.Equal(users, something);


        }

    }
}
