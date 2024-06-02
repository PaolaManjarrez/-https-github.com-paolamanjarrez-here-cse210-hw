using System;
using System.Collections.Generic;

namespace YouTubeVideoComments
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } 
        private List<Comment> _comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video("How to Program in C#", "John Doe", 600);
            Video video2 = new Video("Understanding Design Patterns", "Jane Smith", 900);
            Video video3 = new Video("Introduction to Algorithms", "Alice Johnson", 1200);

            video1.AddComment(new Comment("User1", "Great video!"));
            video1.AddComment(new Comment("User2", "Very informative."));
            video1.AddComment(new Comment("User3", "Loved it!"));

            video2.AddComment(new Comment("UserA", "This really helped me understand design patterns."));
            video2.AddComment(new Comment("UserB", "Well explained!"));
            video2.AddComment(new Comment("UserC", "Thank you for this tutorial."));

            video3.AddComment(new Comment("UserX", "Awesome introduction to algorithms."));
            video3.AddComment(new Comment("UserY", "Perfect for beginners."));
            video3.AddComment(new Comment("UserZ", "Can't wait for the next part."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"Comment by {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine(); 
            }
        }
    }
}
