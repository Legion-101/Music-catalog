using Npgsql;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace Lab_1
{
    internal class Database
    {
        private NpgsqlConnection connection;
        private const string CONNECTION_STRING = "Host=localhost:5432;" + "Username=postgres;" + "Password=password;" + "Database=\"music catalog\"";


        internal Database()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            
        }

        ~Database()
        {
            connection.Close();
        }

        internal List<Artist> GetArtists()
        {
            List<Artist> list = new List<Artist>();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"Name Artist\", \"Genre\" FROM \"Artists\"", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Artist artist = new Artist();
                artist.nameArtist = reader.GetString(0);
                artist.genre = reader.GetString(1);

                list.Add(artist);
            }
            reader.Close();
            if (list.Count != 0 ) 
                return list;
            return null;
        }

        internal List<Album> GetAlbumArtist(string artist)
        {
            List<Album> list = new List<Album>();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"Name Artist\", \"Genre\", \"Name album\" FROM \"Albums\" JOIN \"Artists\" ON \"Albums\".\"Id artist\"=\"Artists\".\"Id artist\" WHERE \"Name Artist\"=\'{artist}\'", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Album album = new Album();
                album.nameArtist = reader.GetString(0);
                album.genre = reader.GetString(1);
                album.nameAlbum = reader.GetString(2);
                list.Add(album);
            }
            if (list.Count != 0)
                return list;
            return null;
        }
    }
}
