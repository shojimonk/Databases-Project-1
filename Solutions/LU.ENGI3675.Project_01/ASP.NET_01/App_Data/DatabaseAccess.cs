// <copyright file="DatabaseAccess.cs" company="engi">
// The Database Access class.
// </copyright>
namespace LU.ENGI3675.Databases1
{
    using System.Collections.Generic;
    using System.Data;
    using Npgsql;

    /// <summary>
    /// This is a simple struct to store a row of our table.
    /// </summary>
    public struct Paints
    {
        /// <summary> The amount, in litres, that is remaining.</summary>
        public int Amount;

        /// <summary> The colour of the paint.</summary>
        public string Colour;
    }

    /// <summary>
    /// DataIn class builds a connection string, connects to database "ENGI3675_test1" on the local host, and 
    /// logs in using SSPI/Integrated Security, all through NPGSQL. It uses an NPGSQL data reader to select all 
    /// from the "paints" table, and add each row to a list of struct paints.
    /// </summary>
    public class DataIn
    {
        /// <summary>
        /// Import function builds a connection string, connects to database "ENGI3675_test1" on the local host, and 
        /// logs in using SSPI/Integrated Security, all through NPGSQL. It uses an NPGSQL data reader to select all 
        /// from the "paints" table, and add each row to a list of struct paints.
        /// </summary>
        /// <returns>A List with the Paints struct as a generic.</returns>
        public static List<Paints> Import()
        {
            NpgsqlConnectionStringBuilder myBuilder = new NpgsqlConnectionStringBuilder();
            myBuilder.Host = "127.0.0.1";
            myBuilder.Port = 5432;
            myBuilder.Database = "ENGI3675_test1";
            myBuilder.IntegratedSecurity = true;
            using (NpgsqlConnection conn = new NpgsqlConnection(myBuilder))
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("select * from paints", conn);
                NpgsqlDataReader table = command.ExecuteReader();

                List<Paints> output = new List<Paints>();
                foreach (IDataRecord row in table)
                {
                    Paints currentPaint = new Paints();
                    currentPaint.Amount = (int)row["Amount Remaining"];
                    currentPaint.Colour = (string)row["Paint Color"];
                    output.Add(currentPaint);
                }

                return output;
            }
        }
    }
}
