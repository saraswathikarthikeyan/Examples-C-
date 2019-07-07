using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sample;
using System.IO;
using System.Collections.Generic;

namespace sampleTest
{
    [TestClass]
    public class UnitTest1
    {
        //To test 6 products
        [TestMethod]
        public void TestProduct1()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=3, productValue=6 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=5},
                    new ProdutItems() { productId=3, productName= "P3", productCost=1, productValue=2},
                    new ProdutItems() { productId=4, productName= "P4", productCost=3, productValue=2 },
                    new ProdutItems() { productId=5, productName= "P5", productCost=4, productValue=4},
                    new ProdutItems() { productId=6, productName= "P6", productCost=3, productValue=4 }
                }
            };

            int budget = 5;

            Assert.AreEqual(11, ShoppingProduct.GetMaxValue(budget, products));
        }

        //To test 3 products
        [TestMethod]
        public void TestProduct2()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=3 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=5},
                    new ProdutItems() { productId=3, productName= "P3", productCost=3, productValue=6}
                }
            };

            int budget = 3;

            Assert.AreEqual(8, ShoppingProduct.GetMaxValue(budget, products));
        }

        //to test different combination of value and cost
        [TestMethod]
        public void TestProduct3()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=3 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=5},
                    new ProdutItems() { productId=3, productName= "P3", productCost=3, productValue=6},
                     new ProdutItems() { productId=4, productName= "P4", productCost=4, productValue=16}
                }
            };

            int budget = 5;

            Assert.AreEqual(19, ShoppingProduct.GetMaxValue(budget, products));
        }

        //to test the budget with cost : 0 chf

        [TestMethod]
        public void TestProduct4()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=3 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=5},
                    new ProdutItems() { productId=3, productName= "P3", productCost=3, productValue=6},
                     new ProdutItems() { productId=4, productName= "P4", productCost=4, productValue=16}
                }
            };

            int budget = 0;

            Assert.AreEqual(0, ShoppingProduct.GetMaxValue(budget, products));
        }

        //To test with same cost of product and different values
        [TestMethod]
        public void TestProduct5()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=3 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=1, productValue=5},
                    new ProdutItems() { productId=3, productName= "P3", productCost=1, productValue=6},
                     new ProdutItems() { productId=4, productName= "P4", productCost=1, productValue=16}
                }
            };

            int budget = 1;

            Assert.AreEqual(16, ShoppingProduct.GetMaxValue(budget, products));
        }

        //To test the product with same values
        [TestMethod]
        public void TestProduct6()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=3 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=3},
                    new ProdutItems() { productId=3, productName= "P3", productCost=3, productValue=3},
                     new ProdutItems() { productId=4, productName= "P4", productCost=4, productValue=3}
                }
            };

            int budget = 4;

            Assert.AreEqual(6, ShoppingProduct.GetMaxValue(budget, products));
        }

        //To test without data or product
        [TestMethod]
        public void TestProduct7()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems()
                }
            };


            int budget = 1;

            Assert.AreEqual(0, ShoppingProduct.GetMaxValue(budget, products));

        }

        //to test with same cost and same value for all products
        [TestMethod]
        public void TestProduct8()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=1 },
                    new ProdutItems() { productId=2, productName= "P2", productCost=1, productValue=1},
                    new ProdutItems() { productId=3, productName= "P3", productCost=1, productValue=1},
                     new ProdutItems() { productId=4, productName= "P4", productCost=1, productValue=1}
                }
            };

            int budget = 1;

            Assert.AreEqual(1, ShoppingProduct.GetMaxValue(budget, products));
        }

        //To test with 1 product cost 0 and Value 0
        [TestMethod]
        public void TestProduct9()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=0, productValue=0 }
                }
            };

            int budget = 1;

            Assert.AreEqual(0, ShoppingProduct.GetMaxValue(budget, products));
        }

        //to test product with cost 0chf
        [TestMethod]
        public void TestProduct10()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=0, productValue=110 }
                }
            };

            int budget = 1;

            Assert.AreEqual(110, ShoppingProduct.GetMaxValue(budget, products));
        }

        //to test product with Value 0
        [TestMethod]
        public void TestProduct11()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=110 }
                }
            };

            int budget = 1;

            Assert.AreEqual(110, ShoppingProduct.GetMaxValue(budget, products));
        }

        // Test should fail : Failure test case
        [TestMethod]
        public void TestProduct12()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
                {
                    new ProdutItems() { productId=1, productName= "P1", productCost=0, productValue=110 }
                }
            };

            int budget = 1;

            Assert.AreEqual(0, ShoppingProduct.GetMaxValue(budget, products));
        }
    }
}
