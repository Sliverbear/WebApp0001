using MVCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogic
{
    public class LogicUser
    {
		// search user tables
		public List<ProductSearchUserTable> GetGoodsList(String keyWord)
        {
            // used for search items we needs
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchUserTable.ToList();

            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.UserName.Contains(keyWord)).ToList();
            }

            return data;

        }

		// delete user infomation 

		public bool DelGoods(int ID)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            // Becuase We need id so we using tbale id to find the data and delete it.
            var data = productEntity.ProductSearchUserTable.Where(p => p.Id == ID).FirstOrDefault();


            if (data != null)
            {
                productEntity.ProductSearchUserTable.Remove(data);

                // make sure this act is execute so we saving after delete it 
                productEntity.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }



        }
		// search and get user infomation from table
		public ProductSearchUserTable GetsingleGoods(int ID)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchUserTable.Where(p => p.Id == ID).FirstOrDefault();

            return data;
        }

		// update the new user value 
		public void UpdateSinglesGoods(ProductSearchUserTable good)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            var data = productEntity.ProductSearchUserTable.Where(p => p.Id == good.Id).FirstOrDefault();


            data.Password = good.Password;
            data.UserName = good.UserName;
            data.RealName = good.RealName;
            data.Authorize = good.Authorize;
            data.CreateTime = good.CreateTime;
            data.UpdateTime = good.UpdateTime;


            // Every move need to save the change 
            productEntity.SaveChanges();


        }
        // add user infromation
        public void InsertGood(ProductSearchUserTable good)
        {
            ProductSearchEntity productEntity = new ProductSearchEntity();
            productEntity.ProductSearchUserTable.Add(good);


            // Every move need to save the change 
            productEntity.SaveChanges();
        }

		public ProductSearchUserTable CheckLogin(string username, string password)
		{
            ProductSearchEntity productEntity = new ProductSearchEntity();

            var data = productEntity.ProductSearchUserTable.Where(p=> p.UserName == username && p.Password == password).FirstOrDefault();
            return data;
		}

	}
}
