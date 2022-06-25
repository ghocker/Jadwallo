using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Jadwallo.Pages
{
    public class doingModel : PageModel
    {
        public List<jadwalinfo> listjadwal = new List<jadwalinfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=jadwal;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM daftar WHERE tahap = 'doing'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                jadwalinfo jadwalinfo = new jadwalinfo();
                                jadwalinfo.id = "" + reader.GetInt32(0);
                                jadwalinfo.nama = reader.GetString(1);
                                jadwalinfo.tanggal = reader.GetString(2);
                                jadwalinfo.keterangan = reader.GetString(3);
                                jadwalinfo.tahap = reader.GetString(4);

                                listjadwal.Add(jadwalinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
        public class jadwalinfo
        {
            public String id;
            public String nama;
            public String tanggal;
            public String keterangan;
            public String tahap;
        }
    }
}
