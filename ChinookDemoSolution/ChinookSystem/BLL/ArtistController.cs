using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using ChinookSystem.Entities; // is for the internal entities
using ChinookSystem.DAL; // is for the context class
using ChinookSystem.ViewModels; // is for public data classes for transporting data from the library to the web application
using System.ComponentModel; // is for ODS
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SelectionList> Artists_DDLList()
        {
            using(var context = new ChinookSystemContext())
            {
                IEnumerable<SelectionList> results = from x in context.Artists
                                                     orderby x.Name
                                                     select new SelectionList
                                                     {
                                                         ValueField = x.ArtistId,
                                                         DisplayField = x.Name
                                                     };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist( int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                //Linq to Entity
                IEnumerable<ArtistAlbums>
                    results = from x in context.Albums
                              where x.ArtistId == artistid
                              select new ArtistAlbums
                              {
                                  Title = x.Title,
                                  ReleaseYear = x.ReleaseYear,
                                  ArtistName = x.Artist.Name
                              };
                return results.ToList();
            }
        }
    }
}
