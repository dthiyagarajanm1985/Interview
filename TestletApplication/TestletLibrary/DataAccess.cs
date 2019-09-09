using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace TestletLibrary
{
    public class DataAccess
    {
        private string filepath="";
        public DataAccess()
        {
        }
        public DataAccess(string filename) {
            filepath = filename;
        }        
        public List<ItemsItem> GetData()
        {
            Items AllItems=null;
            List<ItemsItem> Items = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Items));
                FileStream fs = new FileStream(filepath, FileMode.Open);
                AllItems = (Items)serializer.Deserialize(fs);
                Items=AllItems.Item.ToList();
                fs.Dispose();
            }
            catch (Exception)
            {
                                
            }
            return Items;
        }       
    }
}
