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
        public int CreateMedicine(Medicine medicine)
        {
            Medicine med =  medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //增加行数据
            return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, "insert into medicinemstr  ([Name],[Productor],[ExpireDate]) values('" + med.Name + "','" + med.Productor + "','" + med.ExpireDate + "')");

        }
        public int DeleteMedicine(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //删除行数据
            return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, $"delete from medicinemstr where Name='{med.Name}'");

        }

        public int UpdateMedicine(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //修改行数据
            return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, $"update medicinemstr set Productor='{med.Productor}',ExpireDate='{med.ExpireDate}' where Name='{med.Name}'");


        }

        public DataTable GetMedicine(Medicine medicine)
        {
            Medicine med = medicine;

            //获得数据库连接
            SqlHelper.GetConnection();

            //查询行数据
            return SqlHelper.ExecuteDataset(SqlHelper.GetConnection(), CommandType.Text, $"select MedicineCode,Name,Productor,ExpireDate from medicinemstr where Name='{med.Name}'").Tables[0];

            

        }
    }
}
