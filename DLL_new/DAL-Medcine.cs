using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DLL;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class MedicineDAL
    {
        public int CreateMedicine(Medicine medicine,Vendor vendor)
        {
            Medicine med =  medicine;
            Vendor ven = vendor;

            //获得数据库连接
            SqlHelper.GetConnection();

            //增加行数据
            int id;
            try
            {
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, $"insert into vendormstr  ([vendor_code],[vendor_name]) values ('{ven.VendorCode}','{ven.VendorName}');SELECT @@Identity"));
            }
            catch (System.Data.SqlClient.SqlException)
            {
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, $"select vendormstr_id from VENDORMSTR  where vendor_code='{ven.VendorCode}'"));
            }
            try
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, "insert into medicinemstr  ([MedicineCode],[Name],[Vendormstr_id],[ExpireDate]) values('" + med.MedicineCode + "','" + med.Name + "','" + id + "','" + med.ExpireDate + "')");
            }
            catch(System.Data.SqlClient.SqlException)
            {
                return -1;
            }

        }
        public int DeleteMedicine(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //删除行数据
            return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, $"delete from medicinemstr where ID='{med.ID}'");

        }

        public int UpdateMedicine(Medicine medicine,Vendor vendor)
        {
            Medicine med = medicine;
            Vendor ven = vendor;

            //获得数据库连接
            SqlHelper.GetConnection();

            //修改行数据
            int id;
            try
            {
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, $"insert into vendormstr  ([vendor_code],[vendor_name]) values ('{ven.VendorCode}','{ven.VendorName}');SELECT @@Identity"));
            }
            catch (System.Data.SqlClient.SqlException)
            {
                id = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, $"select vendormstr_id from VENDORMSTR  where vendor_code='{ven.VendorCode}'"));
            }
            try
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, $"update medicinemstr set vendormstr_id='{id}',ExpireDate='{med.ExpireDate}',Name='{med.Name}',MedicineCode='{med.MedicineCode}' where id='{med.ID}'");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }


        }

        public DataTable GetMedicine(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //查询行数据
            return SqlHelper.ExecuteDataset(SqlHelper.GetConnection(), CommandType.Text, $"select mm.ID,mm.MedicineCode,mm.Name,vm.vendor_name,mm.ExpireDate from medicinemstr mm,vendormstr vm where vm.vendormstr_id=mm.Vendormstr_id and Name like '%{med.Name}%'").Tables[0];
    
        }

        public DataTable GetMedicineInfo(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //查询行数据
            return SqlHelper.ExecuteDataset(SqlHelper.GetConnection(), CommandType.Text, $"select mm.ID,mm.MedicineCode,mm.Name,vm.vendor_code,vm.vendor_name,mm.ExpireDate from medicinemstr mm,vendormstr vm where vm.vendormstr_id=mm.Vendormstr_id and mm.ID='{med.ID}'").Tables[0];
        }
    }
}
