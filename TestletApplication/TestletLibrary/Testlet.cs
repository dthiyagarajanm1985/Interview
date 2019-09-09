using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestletLibrary
{
    public class Testlet
    {
        public Testlet()
        {
        }
        public string TestletId;
        readonly int preTestCount = 2;
        public List<ItemsItem> Randomize()
        {
            
            List<ItemsItem> Items = null;
            List<ItemsItem> preTestItem = null;
            List<ItemsItem> FinalItem = new List<ItemsItem>();
            DataAccess dataAccess = new DataAccess("TestletItems.xml");
            Items=dataAccess.GetData();            

            if (Items != null)
            {
                preTestItem = Items.FindAll(pretest => pretest.ItemType.ToString() == "Pretest");
                if(preTestItem!=null)
                {
                    preTestItem = IEnumerableExtensions.Randomize(preTestItem).ToList();
                    for (int i = 0; i < preTestCount; i++)
                    {
                        FinalItem.Add(preTestItem[i]);
                    }                        
                   if (FinalItem != null)
                   {
                       foreach (ItemsItem item in FinalItem)
                           Items.Remove(item);
                   }
                }
                Items =IEnumerableExtensions.Randomize(Items).ToList();

                for (int i = 0; i < FinalItem.Count; i++)
                {
                    Items.Insert(i, FinalItem[i]);
                }
            }

            
            //Items private collection has 6 Operational and 4 Pretest Items.

            //The assignment will be reviewed on the basis of – Tests written first, Correct
            return Items;
        }
      
    }

    public static class IEnumerableExtensions
    {
          public static IEnumerable<t> Randomize<t>(this IEnumerable<t> ItemList)
        {
            Random r = new Random();
            return ItemList.OrderBy(x => (r.Next()));
        }  
    }
}
