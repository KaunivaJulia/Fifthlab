using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;


namespace TestProject2
{
    public class ApplicationContextTests
    {
        [Fact]
        public void DbContext_Set_Months_Not_Null()
        {
            
            var mockSet = new Mock<DbSet<Month>>();
            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(c => c.Months).Returns(mockSet.Object);
            var result = mockContext.Object.Months;

           
            Assert.NotNull(result);
        }
    }
}
