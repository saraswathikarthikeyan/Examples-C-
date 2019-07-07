using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample
{
    public class Produt
    {
        public List<ProdutItems> prouctItems;
    }

    public class ProdutItems
    {
        public int productId;
        public string productName;
        public int productCost;
        public int productValue;
    }
    public class ShoppingProduct
    {
        public static Produt FetchProducts()
        {
            var products = new Produt
            {
                prouctItems = new List<ProdutItems>()
            {
                new ProdutItems() { productId=1, productName= "P1", productCost=1, productValue=200 },
                new ProdutItems() { productId=2, productName= "P2", productCost=2, productValue=40},
                new ProdutItems() { productId=3, productName= "P3", productCost=3, productValue=60},
                new ProdutItems() { productId=4, productName= "P4", productCost=4, productValue=200 }
            }
            };

            return products;
        }

        /* * Method finds the subsets of Array*/
        public static List<string> GetSubStrings(int[] arrIds)
        {
            List<string> arrSubset = new List<string>();
            try
            {
                for (int i = 0; i < Math.Pow(2, arrIds.Length); i++)
                {
                    string combineIds = "";
                    for (int j = 0; j < arrIds.Length; j++)
                    {
                        if ((i & (1 << (arrIds.Length - j - 1))) != 0)
                        {
                            if (combineIds != "")
                            {
                                combineIds = combineIds + "," + arrIds[j].ToString();
                            }
                            else
                            {
                                combineIds = arrIds[j].ToString();
                            }
                        }
                    }
                    arrSubset.Add(combineIds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return arrSubset;
        }

        public static int GetMaxValue(int budget, Produt objProds)
        {
            int toatlValue = 0;
            int costSpent = 0;
            string productsList = "";
            string productNames = "";

            //var objProds = new Produt();

            int[] arrIds = objProds.prouctItems.Select(item => item.productId).ToArray();

            /* * Calls the method to get the Subsets of an Array*/
            List<string> arrListIds = GetSubStrings(arrIds);


            /* Iterates through the subset Ids in the Dataset and Calcualtes Max Value of Product - Starts */
            Dictionary<string, int> dictProduct = new Dictionary<string, int>();
            foreach (var str in arrListIds)
            {
                int totValue = 0;
                int totCost = 0;
                if (str != "")
                {
                    List<string> lstIds = str.Split(',').ToList();

                    foreach (var prodId in lstIds)
                    {
                        var prodQuery = from Produt in objProds.prouctItems
                                        where Produt.productId == Convert.ToInt32(prodId)
                                        select Produt;

                        foreach (var cols in prodQuery)
                        {
                            if ((totCost + cols.productCost) <= budget)
                            {
                                totValue = totValue + cols.productValue;
                                totCost = totCost + cols.productCost;
                            }
                        }
                    }
                }
                //Stores the Maximum Value for the different combination of ProductIds
                if (!dictProduct.ContainsValue(totValue))
                {
                    dictProduct.Add(str, totValue);
                }
            }
            /* Iterates through the subset Ids in the Dataset and Calcualtes Max Value - Ends */


            //Sort the Dictionary in Descending Order and Fetches the Maximum Value Product Purchase
            var maxValue = dictProduct.OrderByDescending(i => i.Value).First();
            toatlValue = maxValue.Value;
            productsList = maxValue.Key;

            /* Code to Display the Result: Product Name: Value: CostSpent - Starts */
            if (productsList != "")
            {
                List<string> lstMaxValIds = productsList.Split(',').ToList();

                foreach (var Id in lstMaxValIds)
                {
                    var prodResultQuery = from Produt in objProds.prouctItems
                                            where Produt.productId == Convert.ToInt32(Id)
                                            select Produt;

                    foreach (var cols in prodResultQuery)
                    {
                        if (productNames == "")
                        {
                            productNames = cols.productName;
                        }
                        else
                        {
                            productNames = productNames + "," + cols.productName;
                        }
                        costSpent = costSpent + cols.productCost;
                    }
                }
            }
            Console.WriteLine("Maximum Value of product purchased: {0}", toatlValue);
            Console.WriteLine("Product purchased: {0}", productNames);
            Console.WriteLine("Cost Spent: {0}CHF", costSpent);
            /* Code to Display the Result: Product Name: Value: CostSpent - Ends */
            return toatlValue;
        }

        public static void Main(string[] args)
        {
            try
            {
                int ip_budget = 4;

                var ip_products = FetchProducts();

                int totValue = GetMaxValue(ip_budget, ip_products);
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(" {0} - Something went wrong! check your input!", ex.Message);
                Console.ReadLine();
            }
        }


    }
}
