using MVCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MVCLogic
{
    public class LogicGoods
    {
        // search prodct tables
        public List<ProductSearchProductTable> GetGoodsList(String keyWord)
        {
            // used for search items we needs
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchProductTable.ToList();

            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.GoodName.Contains(keyWord)).ToList();
            }

            return data;

        }
        
        // delete product infomation 

        public bool DelGoods(int ID)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            // Becuase We need id so we using tbale id to find the data and delete it.
            var data = productEntity.ProductSearchProductTable.Where(p => p.ID == ID).FirstOrDefault();


            if (data != null)
            {
                productEntity.ProductSearchProductTable.Remove(data);

                // make sure this act is execute so we saving after delete it 
                productEntity.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }



        }
        // search and get product infomation from table
        public ProductSearchProductTable GetsingleGoods(int ID)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchProductTable.Where(p => p.ID == ID).FirstOrDefault();

            return data;
        }

        // update the new product value 
        public void UpdateSinglesGoods(ProductSearchProductTable good)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchProductTable.Where(p => p.ID == good.ID).FirstOrDefault();

            
            data.GoodName= good.GoodName;
            data.Price = good.Price;
            data.Weight = good.Weight;
            data.Color = good.Color;
            data.Brand = good.Brand;

            // Every move need to save the change 
            productEntity.SaveChanges();


        }
        // add product infromation
        public void InsertGood (ProductSearchProductTable good)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            productEntity.ProductSearchProductTable.Add(good);


            // Every move need to save the change 
            productEntity.SaveChanges();
        }


    }
}


