using System.DirectoryServices;
using System.Text.Json;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Lab_1
{
    public partial class MusicCatalog : Form
    {
        DataMusicCatalog items = new DataMusicCatalog();

        
        public MusicCatalog()
        {
            Database database = new Database();
            List<Artist> artist = database.GetArtists();
            //List<Album> album = database.GetAlbumArtist(artist[0].nameArtist);
           
            InitializeComponent();
            foreach(Artist artistItem in artist)
            {
                treeView1.Nodes.Add(artistItem.nameArtist);
                List<Album> album = database.GetAlbumArtist(artistItem.nameArtist);
                foreach(Album albumItem in album)
                {
                    treeView1.Nodes[artistItem.nameArtist].Nodes.Add(albumItem.nameAlbum);
                }
            }
            //using (StreamReader r = new StreamReader("../../../data.json"))
            //{
            //    string json = r.ReadToEnd();
            //    items = JsonConvert.DeserializeObject<DataMusicCatalog>(json);
            //}
            //// Print data about Artist
            //for (int i = 0; i < items.Artists.Count; i++)
            //{
            //    for (int j = 0; j < items.Albums.Count; j++)
            //    {
            //        if (treeView1.Nodes[i].Text == items.Albums[j].nameArtist)
            //        {
            //            treeView1.Nodes[i].Nodes.Add(items.Albums[j].nameAlbum);
            //        }
            //        else continue;
            //    }
            //    for (int k = 0; k < treeView1.Nodes[i].Nodes.Count;)
            //    {
            //        foreach (Track track in items.Albums[k].tracks)
            //        {
            //            if (treeView1.Nodes[i].Nodes[k].Text == items.Albums[k].nameAlbum)
            //                treeView1.Nodes[i].Nodes[k].Nodes.Add(track.nameTrack);
            //            else continue;
            //        }
            //    }

            //}
            //// Print data about collections
            //for (int i = 0; i < items.Collections.Count; i++)
            //{
            //    treeViewCollections.Nodes.Add(items.Collections[i].nameCollection);
            //    //treeViewCollections.Nodes[i].Nodes.Add(items.Collections[i].tracks[i].genre);
            //    for (int j = 0; j < items.Collections[i].tracks.Count; j++)
            //    {
            //        treeViewCollections.Nodes[i].Nodes.Add(items.Collections[i].tracks[j].nameTrack);
            //    }
            //}

        }
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string value = textBoxSearch.Text;
            SearchEngine searchEngine = new SearchEngine();
            if (searchEngine.searchArtist(items.Artists, value) != null)
            {
                treeView1.Visible = false;
                treeView1.Nodes.Clear();
            } else if (searchEngine.searchAlbum(items.Albums, value) != null)
            {
                treeView1.Visible = false;
            } else if (searchEngine.searchTrack(items.Tracks, value) != null)
            {
                treeView1.Visible = false;
            } else if (searchEngine.searchCollection(items.Collections, value) != null)
            {
                treeView1.Visible = false;
            } else if (searchEngine.searchTrackWithGenre(items.Tracks, value) != null)
            {
                treeView1.Visible = false;
            }
            else
            {
                textBoxSearch.Text = $"Значение {value} не найдено";
            }

        }



    }
}