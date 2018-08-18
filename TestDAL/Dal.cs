using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBizModels;

namespace TestDAL
{
    public class Dal
    {
        /// <summary>
        /// do read update delete create
        /// </summary>

        ///read
        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            using (testDBEntities ctx = new testDBEntities())
            {
                var custs = ctx.GetCustomers();
                list = custs.Select(x => new Customer { Id = x.cust_id, Name = x.cust_name }).ToList();
            }

            return list;
        }

        ///create
        public void AddCustomer(Customer c)
        {
            T_Customers tc = new T_Customers { cust_id = c.Id, cust_name = c.Name }; //check convert
            using (testDBEntities ctx = new testDBEntities())
            {
                ctx.T_Customers.Add(tc);
                ctx.SaveChanges();
            }
        }

        /// update
        public int UpdateCustomer(Customer c)
        {
            T_Customers tc;
            using (testDBEntities ctx = new testDBEntities())
            {
                tc = ctx.T_Customers.Where(x => x.cust_id == c.Id).FirstOrDefault();
                if (tc != null)
                {
                    tc.cust_name = c.Name;
                }

                return ctx.SaveChanges();
            }
        }

        /// update
        public int UpdateCustomerSP(Customer c)
        {
            T_Customers tc;
            using (testDBEntities ctx = new testDBEntities())
            {
                return ctx.UpdateCustomer(c.Id, c.Name);
            }
        }


        //delete
        public int DeleteCustomer(Customer c)
        {
            T_Customers tc;
            using (testDBEntities ctx = new testDBEntities())
            {
                tc = ctx.T_Customers.Where(x => x.cust_id == c.Id).FirstOrDefault();
                if (tc != null)
                {
                    ctx.T_Customers.Remove(tc);
                }

                return ctx.SaveChanges();
            }
        }

    }
}
