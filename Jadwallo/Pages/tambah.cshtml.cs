using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Jadwallo.Pages.IndexModel;

namespace Jadwallo.Pages
{
    public class tambahModel : PageModel
    {
        public jadwalinfo jadwalInfo = new jadwalinfo();
        public String errorMessage = "";
        public String succesMessage = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {
            jadwalInfo.nama = Request.Form["nama"];
            jadwalInfo.tanggal = Request.Form["tanggal"];
            jadwalInfo.keterangan = Request.Form["keterangan"];
            jadwalInfo.tahap = "todo";

            if (jadwalInfo.nama.Length == 0 || jadwalInfo.tanggal.Length == 0 || jadwalInfo.keterangan.Length ==0)
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
                    String sql = "INSERT INTO daftar" +
                                 "(nama, tanggal, keterangan, tahap) VALUES " +
                                 "(@nama, @tanggal, @keterangan, @tahap);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nama", jadwalInfo.nama);
                        command.Parameters.AddWithValue("@tanggal", jadwalInfo.tanggal);
                        command.Parameters.AddWithValue("@keterangan", jadwalInfo.keterangan);
                        command.Parameters.AddWithValue("@tahap", jadwalInfo.tahap);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            jadwalInfo.nama = ""; jadwalInfo.tanggal = ""; jadwalInfo.keterangan = "";
            succesMessage = "Data berhasil ditambah";

            Response.Redirect("/index");
        }
    }
}
