using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class SearchEngine
    {
        internal  dynamic? findItems;
        public bool searchArtist(List<Artist> artists, string _artist)
        {
            foreach (var artist in artists) 
            {
                if (artist.nameArtist.ToLower() == _artist.ToLower())
                {
                    this.findItems = artist;
                    return true;
                }
            }
            return false;
        }

        public bool searchAlbum(List<Album>? albums, string _album)
        {
            foreach (var album in albums)
            {
                if (album.nameAlbum.ToLower() == _album.ToLower())
                {
                    this.findItems = album;
                    return true;
                }

            }
            return false;
        }

        public bool searchTrack(List<Track> tracks, string _track)
        {
            foreach (var track in tracks)
            {
                if (track.nameTrack.ToLower() == _track.ToLower())
                {
                    this.findItems = track;
                    return true;
                }
            }
            return false;
        }

        public bool searchTrackWithGenre(List<Track> tracks, string _genre)
        {
            List<Track> result = new List<Track>();

            foreach (var track in tracks)
            {
                if (track.genre.ToLower() == _genre.ToLower())
                {
                    result.Add(track);
                }
                
            }
            if (result.Count > 0)
            {
                this.findItems = null;
                this.findItems = result;
                return true;
            }
            return false;
        }

        public bool searchCollection(List<Collection> collections, string _collection)
        {
            foreach (var collection in collections)
            {
                if (collection.nameCollection.ToLower() == _collection.ToLower())
                {
                    this.findItems = collection;
                    return true;
                }
            }
            return false;
        }
        
    }
}
