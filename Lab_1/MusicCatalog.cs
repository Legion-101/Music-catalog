using System.Text.Json;
using Newtonsoft.Json;

namespace Lab_1
{
    public partial class MusicCatalog : Form
    {
        DataMusicCatalog items = new DataMusicCatalog();
        public MusicCatalog()
        {
            
            using (StreamReader r = new StreamReader("../../../data.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<DataMusicCatalog>(json);
            }
            InitializeComponent();
            // Print data about Artist
            for (int i = 0; i < items.Artists.Count; i++)
            {
                treeView1.Nodes.Add(items.Artists[i].nameArtist);
                for (int j = 0; j < items.Albums.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(items.Albums[j].nameAlbum);
                    for (int k = 0; k < items.Albums[j].tracks.Count; k++)
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes.Add(items.Albums[j].tracks[k].nameTrack);
                    }

                }
            }
            // Print data about collections
            for (int i = 0; i < items.Collections.Count; i++)
            {
                treeViewCollections.Nodes.Add(items.Collections[i].nameCollection);
                treeViewCollections.Nodes[i].Nodes.Add(items.Collections[i].description);
                for (int j = 0; j < items.Collections[i].tracks.Count; j++)
                {
                    treeViewCollections.Nodes[i].Nodes.Add(items.Collections[i].tracks[j].nameTrack);
                    treeViewCollections.Nodes[i].Nodes.Add(items.Collections[i].tracks[j].genre);
                }
            }

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