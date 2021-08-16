using Content.Domain.Enums.Content;
using System;

namespace Content.Domain.Entities.Contents
{
    public class Article : ContentBase
    {
        private Article() { }

        public Article(string name, string text)
            :base(name, Categories.Article)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            ArticleText = text;
        }

        public string ArticleText { get; private set; }
    }
}
