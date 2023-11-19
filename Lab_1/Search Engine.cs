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
        public Artist searchArtist(List<Artist> artists, string _artist)
        {
            foreach (var artist in artists) 
            {
                if (artist.nameArtist.ToLower() == _artist.ToLower())
                    return artist;
            }
            return null;
        }

        public Album searchAlbum(List<Album> albums, string _album)
        {
            foreach (var album in albums)
            {
                if (album.nameAlbum.ToLower() == _album.ToLower())
                    return album;
            }
            return null;
        }

        public Track searchTrack(List<Track> tracks, string _track)
        {
            foreach (var track in tracks)
            {
                if (track.nameTrack.ToLower() == _track.ToLower())
                    return track;
            }
            return null;
        }

        public List<Track> searchTrackWithGenre(List<Track> tracks, string _genre)
        {
            List<Track> result = new List<Track>();
            foreach (var track in tracks)
            {
                if (track.genre.ToLower() == _genre.ToLower())
                    result.Add(track);
            }
            if (result.Count > 0)
                return result;
            return null;
        }

        public Collection searchCollection(List<Collection> collections, string _collection)
        {
            foreach (var collection in collections)
                if (collection.nameCollection == _collection) 
                    return collection;
            return null;
        }
        
    }
}
