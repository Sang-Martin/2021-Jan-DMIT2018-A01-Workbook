using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel { get; set; }
        private int _ReleaseYear { get; set; }

        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage ="Album title is required")]
        [StringLength(160, ErrorMessage ="Title is limited to 160 characters")]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        [Required(ErrorMessage ="Release Year is required")]
        public int ReleaseYear 
        {
            get { return _ReleaseYear; }
            set
            {
                if(_ReleaseYear < 1950 || _ReleaseYear > DateTime.Today.Year)          
                {
                    throw new Exception("Album release year is before 1950 or a year in the future");
                }
                else
                {
                    _ReleaseYear = value;
                }
            }
        }

        [StringLength(50, ErrorMessage ="Release Label is limited to 50 characters")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }

        //you can stil use [NotMapped] annotations

        //navigational properties
        //classinstancename.properties.fieldpropertyname

        //many to 1 relationship
        //create the 1 end of the relationship in this entity

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; } 
    }
}
