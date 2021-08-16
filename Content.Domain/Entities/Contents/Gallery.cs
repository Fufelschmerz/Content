using Content.Domain.Enums.Content;
using Content.Domain.ValueObjects.ContentComponets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Domain.Entities.Contents
{
    public class Gallery: ContentBase
    {
        private readonly ICollection<Photo> _photos = new HashSet<Photo>();

        public Gallery(string name, string coverUrl)
            : base(name, Categories.Gallery)
        {
            if (string.IsNullOrWhiteSpace(coverUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(coverUrl));

            CoverUrl = coverUrl;
        }

        public string CoverUrl { get; private set; }

        public IEnumerable<Photo> Photos => _photos.AsQueryable();

        protected internal void AddPhotos(IEnumerable<Photo> photos)
        {
            if (!photos.Any())
                throw new ArgumentException("The image collection is empty", nameof(photos));

            foreach (var photo in photos)
            {
                _photos.Add(photo);
            }
        }
    }
}
