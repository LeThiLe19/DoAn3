using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn2.DAL
{
    class DataHelper
    {
        string stcon = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLMT1;Integrated Security=True";
        SqlConnection con;
        public DataHelper(string stcon)
        {
            this.stcon = stcon;
            con = new SqlConnection(stcon);
        }
        public string Open()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlDataReader ExcuteReader(string stselect)
        {
            Open();
            SqlCommand cm = new SqlCommand(stselect, con);//bắt đầu truy vấn dữ liệu
            SqlDataReader dr = cm.ExecuteReader();
            //Close();Không thể đóng kết nối ở đây
            return dr;
            //SqlCommand-->insert, update, delete, vì command không trả ra 1 bảng nào cả,
            //chỉ trả ra dòng đầu tiên hoặc số dòng
            //SqlDataAdapter-->select, trả ra bảng
            //Datatable-->là con của dataset, datatable giống bảng trong sql, gồm các trường row, colum-->lấy ra 1 bảng
            //DataSet-->chửa nhiều datatable,nhiều bảng
        }
        public void ExcuteNonQuery(string stql)
        {
            //thêm vào csdl
            Open();
            SqlCommand cm = new SqlCommand(stql, con);
            cm.ExecuteNonQuery();
            Close();

        }
        public DataTable FillDataTable(string sql)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);//chuyển dữ liệu về
            DataTable dt = new DataTable();//tạo 1 kho ảo để lưu trữ dữ liệu
            //dt.Clear();
            da.Fill(dt);//đổ dữ liệu vào kho(fill là đổ)
            con.Close();
            return dt;
        }

        public DataTable Sort(DataTable dt, string tencot)
        {
            DataView dv = new DataView(dt);
            dv.Sort = tencot;
            return dv.ToTable();
        }
        public DataView FillRows(DataTable dt, string dk)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = dk;
            return dv;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {

            //b1: tạo 1 row có cấu trúc giống bảng
            DataRow dr = dt.NewRow();
            //b2; gán giá trị truyền vào cho các trường
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr[i] = values[i];
            }
            //b3: thêm row vào bảng
            dt.Rows.Add(dr);
        }
        public void UpdateRow(DataTable dt, string dk, params object[] values)
        {
            //b1: Lọc ra các row cần sửa
            DataView dv = FillRows(dt, dk);
            if (dv.Count > 0)
            {
                dv.AllowEdit = true;
                for (int i = 0; i < values.Length; i++)
                {
                    dv[0][i] = values[i];
                }
            }

        }
        public void DeleteRow(DataTable dt, string dk)
        {
            //b1: lọc ra các row cần xoá
            DataView dv = FillRows(dt, dk);
            if (dv.Count > 0)
            {
                dv.AllowEdit = true;
                while (dv.Count > 0)
                {
                    dv[0].Delete();
                }
            }
        }

        public void UpdateDataTableToDataBase(DataTable dt, string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*from" + tableName, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
        }
        public string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
    }
}