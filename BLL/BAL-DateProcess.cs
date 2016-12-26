using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary;
using System.Data;


namespace BAL
{
    
    public class DataProcess
    {
        public int add(Medicine med)
        {
            MedicineDAL meddal = new MedicineDAL();
           return  meddal.CreateMedicine(med);
        }

        public int delete(Medicine med)
        {
            MedicineDAL meddal = new MedicineDAL();
            return meddal.DeleteMedicine(med);
        }

        public int update(Medicine med)
        {
            MedicineDAL meddal = new MedicineDAL();
            return meddal.UpdateMedicine(med);
        }

        public DataTable get(Medicine med)
        {
            MedicineDAL meddal = new MedicineDAL();
            return meddal.GetMedicine(med);
        }

    }
}
