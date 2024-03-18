using ExamAware1.Model;
using MySql.Data.MySqlClient;
using Mysqlx;
using Org.BouncyCastle.Asn1.Cms;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamAware1.Class
{
    public class MyClass
    {
        private HttpContext _Context;
        private static IConfiguration _configuration;

        public MyClass(HttpContext context, IConfiguration configuration)
        {
            _Context = context;
            _configuration = configuration;

        }


        public static List<ResEmployeeModel> getData()
        {
            string server = "localhost";
            string database = "awartest";
            string username = "root";
            string password = "";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            string query = "select * from employee left join position on employee.EM_position_id = position.Position_id";

            var metadata = new List<ResEmployeeModel>();
            var rdr = new MySqlCommand(query, conn).ExecuteReader();

            using (rdr)
            {
                while (rdr.Read())
                {
                    metadata.Add(new ResEmployeeModel
                    {
                        Em_Name = rdr["EM_name"].ToString(),
                        Em_Nickname = rdr["EM_nickname"].ToString(),
                        Em_Age = Convert.ToInt32(rdr["EM_age"]),
                        Em_Position = rdr["Position_name"].ToString(),
                        Em_Phone = rdr["EM_phone"].ToString(),
                    });
                }
            }

            return metadata;

        }

        public static List<Dictionary<string, object>> checkContext(string value)
        {
            string[] textSplit = value.Split(',');

            var letters = new List<string>();
            var numbers = new List<int>();

            foreach (var item in textSplit)
            {
                if (int.TryParse(item, out int number))
                    numbers.Add(number);
                else
                    letters.Add(item);
            }

            // Sort the alphanumeric items in alphabetical order
            letters.Sort();

            // Combine the sorted alphanumeric items and numeric items
            var sortedItems = letters.Concat(numbers.Select(n => n.ToString()));

            // Join the sorted items back into a string
            string sortedString = string.Join(",", sortedItems);

            Console.WriteLine("Sorted string: " + sortedString);
            string[] itemSort = sortedString.Split(',');

            HashSet<string> distinctNumbers = new();
            HashSet<string> duplicateNumbers = new();
            var list = new List<Dictionary<string, object>>();
            
            int index = 1;
            foreach (var number in itemSort)
            {
                if (!distinctNumbers.Add(number))
                {
                    duplicateNumbers.Add(number);
                }
                
            }
            //var sortVal = duplicateNumbers.OrderBy(x => x).ToList();

            foreach (var number2 in duplicateNumbers)
            {
                
                var dict = new Dictionary<string, object>();
                dict["rank" + index] = number2;
                list.Add(dict);
                index++;
            
            }
            Console.WriteLine(list);

            return list;
        }


    }
}
