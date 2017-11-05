using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace PagingExtensions.Tests
{
    [TestClass]
    public class PagingExtensionsTest
    {
        private Mock<IQueryable<int>> queryable;

        [TestInitialize]
        public void SetUp()
        {
            queryable = new Mock<IQueryable<int>>();
        }

        [DataTestMethod]
        [DataRow(42, 10, 5)]
        [DataRow(42, 5, 9)]
        [DataRow(42, 40, 2)]
        public async Task TestGetPageCount(int elemCount, int pageSize, int expectedPageCount)
        {
            queryable.Setup(q => q.CountAsync()).Returns(Task.FromResult(elemCount));

            var pagedQueryable = new PagedQueryable<int>(queryable.Object, pageSize);
            var pageCount = await pagedQueryable.GetPageCountAsync();
            pageCount.ShouldBe(expectedPageCount);
        }

        [TestMethod]
        public void TestGetPage()
        {
            var pagedQueryable = new PagedQueryable<Foo>(queryable, 10);
            var page = pagedQueryable.GetPage(2);

            var i = 10;
            foreach (var foo in page)
            {
                foo.Index.ShouldBe(i);
                i++;
            }
        }
    }
}
