using System.DirectoryServices;
using System.Text.Json;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Lab_1
{
    public partial class MusicCatalog : Form
    {
        DataMusicCatalog items = new DataMusicCatalog();

        Database database = new Database();

        internal void catalogTreeViewArtist(Database database, bool save)
        {
            List<Artist>? artists = database.GetArtists();

            foreach (Artist artistItem in artists)
            {
                treeView1.Nodes.Add(artistItem.nameArtist, artistItem.nameArtist);
                List<Album>? albums = database.GetAlbumArtist(artistItem.nameArtist);
                if (save)
                    items.Artists.Add(artistItem);
                foreach (Album albumItem in albums)
                {
                    treeView1.Nodes[artistItem.nameArtist].Nodes.Add(albumItem.nameAlbum, albumItem.nameAlbum);
                    List<Track>? Tracks = database.GetTracksAlbum(albumItem.nameAlbum);
                    if (save)
                        items.Albums.Add(albumItem);
                    foreach (Track track in Tracks)
                    {
                        treeView1.Nodes[artistItem.nameArtist].Nodes[albumItem.nameAlbum].Nodes.Add(track.nameTrack, track.nameTrack);
                        if (save)
                            items.Tracks.Add(track);
                    }
                }
            }
        }

        internal void catalogTreeViewCollections(Database database, bool save)
        {
            List<Collection>? collections = database.GetCollections();
            if (save)
                items.Collections = collections;
            int count = 0;
            foreach (var collection in collections)
            {
                treeViewCollections.Nodes.Add(collection.nameCollection, collection.nameCollection);
                List<Track>? Tracks = database.GetTracksCollection(collection.nameCollection);
                if (save)
                    items.Collections[count].tracks = Tracks;
                count++;
                foreach (var track in Tracks)
                {
                    treeViewCollections.Nodes[collection.nameCollection].Nodes.Add(track.nameTrack, track.nameTrack);
                }
            }
        }

        public MusicCatalog()
        {
            InitializeComponent();
            catalogTreeViewArtist(database, true);
            catalogTreeViewCollections(database, true);
        }
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string value = textBoxSearch.Text;
            SearchEngine searchEngine = new SearchEngine();
            if (textBoxSearch.Text == "")
            {
                treeView1.Nodes.Clear();
                treeViewCollections.Nodes.Clear();
                catalogTreeViewArtist(database, false);
                catalogTreeViewCollections(database, false);
                searchEngine.findItems = null;
                return;
            }

            if (searchEngine.searchArtist(items.Artists, value))
            {
                treeView1.Nodes.Clear();
                treeViewCollections.Nodes.Clear();
                treeView1.Nodes.Add(searchEngine.findItems.nameArtist, searchEngine.findItems.nameArtist);
                return;
            }

            if (searchEngine.searchAlbum(items.Albums, value))
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(searchEngine.findItems.nameArtist, searchEngine.findItems.nameArtist);
                treeView1.Nodes[searchEngine.findItems.nameArtist].Nodes.Add(searchEngine.findItems.nameAlbum, searchEngine.findItems.nameAlbum);
                if (searchEngine.searchTrack(items.Tracks, value))
                {
                    treeView1.Nodes[searchEngine.findItems.nameArtist].Nodes[searchEngine.findItems.nameAlbum].Nodes.Add(searchEngine.findItems.nameTrack);
                }
                treeView1.ExpandAll();
            }
            else if (searchEngine.searchTrack(items.Tracks, value))
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(searchEngine.findItems.nameArtist, searchEngine.findItems.nameArtist);
                treeView1.Nodes[searchEngine.findItems.nameArtist].Nodes.Add(searchEngine.findItems.nameAlbum, searchEngine.findItems.nameAlbum);
                treeView1.Nodes[searchEngine.findItems.nameArtist].Nodes[searchEngine.findItems.nameAlbum].Nodes.Add(searchEngine.findItems.nameTrack);
                treeView1.ExpandAll();
            }
            else if (searchEngine.searchTrackWithGenre(items.Tracks, value))
            {
                treeView1.Nodes.Clear();
                foreach (var item in searchEngine.findItems)
                {
                    treeView1.Nodes.Add(item.nameTrack, item.nameTrack);
                }
                treeView1.ExpandAll();
            }

            if (searchEngine.searchCollection(items.Collections, value))
            {
                treeViewCollections.Nodes.Clear();
                treeViewCollections.Nodes.Add(searchEngine.findItems.nameCollection, searchEngine.findItems.nameCollection);
                foreach (var track in searchEngine.findItems.tracks)
                {
                    treeViewCollections.Nodes[searchEngine.findItems.nameCollection].Nodes.Add(track.nameTrack);
                }
                treeViewCollections.ExpandAll();
            }

            if (searchEngine.findItems == null)
            {
                textBoxSearch.Text = $"Значение {value} не найдено";
                treeView1.Nodes.Clear();
                treeViewCollections.Nodes.Clear();
            }

        }
    }
}