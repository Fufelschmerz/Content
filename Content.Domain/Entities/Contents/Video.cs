using Content.Domain.Enums.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Domain.Entities.Contents
{
    public class Video : ContentBase
    {
        private Video() { }

        public Video(string name, string videoUrl)
            : base(name, Categories.Video)
        {
            if (string.IsNullOrWhiteSpace(videoUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(videoUrl));

            VideoUrl = videoUrl;
        }

        public string VideoUrl { get; private set; }
    }
}
