using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using BAL;

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
            int i=bal.add(med);
            if (i==1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else Response.Write("<script>alert('添加失败!')</script>");
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Name = medcinename.Value;
            //med.Productor = productor.Value;
            //med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            DataProcess bal = new DataProcess();
            int i=bal.delete(med);
            if (i == 1)
            {
                Response.Write("<script>alert('删除成功!')</script>");
            }
            else Response.Write("<script>alert('删除失败!未找到该药品信息!')</script>");
        }
        protected void update_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Name = medcinename.Value;
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
            int i=bal.update(med);
            if (i == 1)
            {
                Response.Write("<script>alert('更新成功!')</script>");
            }
            else Response.Write("<script>alert('更新失败!未找到该药品信息!')</script>");
        }

        protected void search_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Name = medcinename.Value;
            //med.Productor = productor.Value;
            //med.ExpireDate = Convert.ToDateTime(expiredate.Value);
            DataProcess bal = new DataProcess();
            GridView1.DataSource= bal.get(med);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}