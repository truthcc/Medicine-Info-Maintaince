using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using BAL;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Name=medcinename.Value;
            med.MedicineCode = medicinecode.Value;
            Vendor ven = new Vendor();
            ven.VendorCode = vendorcode.Value;
            ven.VendorName = productor.Value;

            if (string.IsNullOrEmpty(med.Name)==true)
            {
                Response.Write("<script>alert('药品名称不能为空!')</script>");
                return;
            }
            med.Productor = productor.Value;
            try
            {
                med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            }
            catch (System.FormatException)
            {
                Response.Write("<script>alert('输入的药品有效期格式不正确!')</script>");
                return;
            }
            DataProcess bal = new DataProcess();
            int i=bal.add(med,ven);
            if (i == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else if (i == -1)
            {
                Response.Write("<script>alert('已存在该药品编码!')</script>");
            }

            else Response.Write("<script>alert('添加失败!')</script>");
            search_Click(null, null);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('请先选中结果!')</script>");
                return;
            }

            int a = GridView1.SelectedIndex;
            
            Medicine med = new Medicine();
            med.ID = int.Parse(GridView1.DataKeys[a].Value.ToString());
            DataProcess bal = new DataProcess();
            int i=bal.delete(med);
            if (i == 1)
            {
                Response.Write("<script>alert('删除成功!')</script>");
            }
            else Response.Write("<script>alert('删除失败!未找到该药品信息!')</script>");

            search_Click(null, null);
        }
        protected void update_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            
            if (GridView1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('请选中搜索结果!')</script>");
                return;
            }

            int a = GridView1.SelectedIndex;
            DataProcess bal = new DataProcess();
            
            DataTable dt= bal.getInfo(med);

            med.ID = int.Parse(GridView1.DataKeys[a].Value.ToString());
            med.Name = medcinename.Value;
            med.MedicineCode = medicinecode.Value;
            med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            Vendor ven = new Vendor();
            ven.VendorCode = vendorcode.Value;
            ven.VendorName = productor.Value;

            if (string.IsNullOrEmpty(med.Name) == true)
            {
                Response.Write("<script>alert('药品名称不能为空!')</script>");
                return;
            }
            //med.Productor = productor.Value;
            try
            {
                med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            }
            catch (System.FormatException)
            {
                Response.Write("<script>alert('输入的药品有效期格式不正确!')</script>");
                return;
            }
            DataProcess bal0 = new DataProcess();
            int i = bal0.update(med, ven);
            if (i == 1)
            {
                Response.Write("<script>alert('更新成功!')</script>");
            }
            else if (i == -1)
            {
                Response.Write("<script>alert('已存在该药品编码!')</script>");
            }

            else Response.Write("<script>alert('更新失败!')</script>");

            search_Click(null, null);
        }

        protected void search_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Name = medcinename.Value;
            //med.Productor = productor.Value;
            //med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            DataProcess bal = new DataProcess();
            GridView1.DataSource= bal.get(med);
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            int a = GridView1.SelectedIndex;
            med.ID = int.Parse(GridView1.DataKeys[a].Value.ToString());
            DataProcess bal = new DataProcess();
            DataTable dt = bal.getInfo(med);
            medicinecode.Value = dt.Rows[0][1].ToString();
            medcinename.Value = dt.Rows[0][2].ToString();
            vendorcode.Value = dt.Rows[0][3].ToString();
            productor.Value = dt.Rows[0][4].ToString();
            string b = Convert.ToDateTime(dt.Rows[0][5]).ToString("yyyy-MM-dd");
            ClientScript.RegisterStartupScript(GetType(), "msgbox", $"<script>document.getElementById('expiredate').value ='{b}';</script>");
            //expiredate.Value = Convert.ToDateTime(dt.Rows[0][5]).ToString("yyyy-MM-dd");
            

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            GridView1.SelectedIndex = -1;
            medicinecode.Value = null;
            medcinename.Value = null;
            vendorcode.Value = null;
            productor.Value = null;
            expiredate.Value = null;
            
        }
    }
}