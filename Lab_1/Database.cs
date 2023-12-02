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

        internal List<Artist>? GetArtists()
        {
            List<Artist> list = new List<Artist>();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"nameArtist\", \"genre\" FROM \"Artists\"", connection);
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

        internal List<Album>? GetAlbumArtist(string artist)
        {
            List<Album> list = new List<Album>();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"nameArtist\", \"genre\", \"nameAlbum\" FROM \"Albums\" JOIN \"Artists\" ON \"Albums\".\"idArtist\"=\"Artists\".\"idArtist\" WHERE \"nameArtist\"=\'{artist}\'", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Album album = new Album();
                album.nameArtist = reader.GetString(0);
                album.genre = reader.GetString(1);
                album.nameAlbum = reader.GetString(2);
                list.Add(album);
            }
            reader.Close ();
            if (list.Count != 0)
                return list;
            return null;
        }

        internal List<Track>? GetTracksAlbum(string album) 
        {
            album = album.Replace("\'", "\''");
            List<Track> list = new List<Track>();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"nameArtist\", \"genre\", \"nameAlbum\", \"nameTrack\" FROM \"Albums\" " +
                                                    $"JOIN \"Artists\" ON \"Albums\".\"idArtist\"=\"Artists\".\"idArtist\" " +
                                                    $"JOIN \"Tracks\" ON \"Albums\".\"idAlbum\"=\"Tracks\".\"idAlbum\" " +
                                                    $"WHERE \"Albums\".\"nameAlbum\"=\'{album}\'", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Track track= new Track();
                track.nameArtist = reader.GetString(0);
                track.genre = reader.GetString(1);
                track.nameAlbum = reader.GetString(2);
                track.nameTrack = reader.GetString(3);
                list.Add(track);
            }
            reader.Close();
            if (list.Count != 0)
                return list;
            return null;
        }

        internal List<Collection>? GetCollections()
        {
            List<Collection> list = new List<Collection>();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"nameCollection\" FROM \"Collections\"", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Collection collection = new Collection();
                collection.nameCollection = reader.GetString(0);
                list.Add(collection);
            }
            reader.Close();
            if (list.Count != 0)
                return list;
            return null;
        }

        internal List<Track>? GetTracksCollection(string collection)
        {
            collection = collection.Replace("\'", "\''");
            List<Track> list = new List<Track>();
            NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"nameTrack\" FROM \"Collections\" " +
                                                    $"JOIN \"collections_tracks\" ON \"Collections\".\"idCollection\"=\"collections_tracks\".\"idCollection\" " +
                                                    $"JOIN \"Tracks\" ON \"collections_tracks\".\"idTrack\"=\"Tracks\".\"idTrack\" " +
                                                    $"WHERE \"Collections\".\"nameCollection\"=\'{collection}\'", connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Track track = new Track();
                track.nameTrack = reader.GetString(0);
                list.Add(track);
            }
            reader.Close();
            if (list.Count != 0)
                return list;
            return null;
        }
    }
}
