using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Jadwallo.Pages.IndexModel;

namespace Jadwallo.Pages
{
    public class ubahModel : PageModel
    {
        public jadwalinfo jadwalInfo = new jadwalinfo();
        public String errorMessage = "";
        public String succesMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=jadwal;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM daftar WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                jadwalInfo.id = "" + reader.GetInt32(0);
                                jadwalInfo.nama = reader.GetString(1);
                                jadwalInfo.tanggal = reader.GetString(2);
                                jadwalInfo.keterangan = reader.GetString(3);
                                jadwalInfo.tahap = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 

            }
        }
        public void OnPost()
        {
            jadwalInfo.id = Request.Form["id"];
            jadwalInfo.nama = Request.Form["nama"];
            jadwalInfo.tanggal = Request.Form["tanggal"];
            jadwalInfo.keterangan = Request.Form["keterangan"];
            jadwalInfo.tahap = Request.Form["tahap"];

            if (jadwalInfo.nama.Length == 0 || jadwalInfo.tanggal.Length == 0 || jadwalInfo.keterangan.Length == 0)
            {
                errorMessage = "Mohon isi bagian kosong";
                return;
            }

            // save database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=jadwal;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE daftar " +
                                 "SET nama=@nama, tanggal=@tanggal, keterangan=@keterangan " +
                                 "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nama", jadwalInfo.nama);
                        command.Parameters.AddWithValue("@tanggal", jadwalInfo.tanggal);
                        command.Parameters.AddWithValue("@keterangan", jadwalInfo.keterangan);
                        command.Parameters.AddWithValue("@id", jadwalInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/index");

        }
    }
}
