using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("The Power of Focus", "InspireDaily", 300);
        video1.AddComment(new Comment("Alice", "So motivating!"));
        video1.AddComment(new Comment("Bob", "Loved this message."));
        video1.AddComment(new Comment("Charlie", "This helped me a lot."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Funny Cats Compilation", "PetCentral", 210);
        video2.AddComment(new Comment("Debbie", "So cute!"));
        video2.AddComment(new Comment("Erik", "I can’t stop laughing."));
        video2.AddComment(new Comment("Frank", "10/10 would watch again."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Programming Tips", "CodeMaster", 420);
        video3.AddComment(new Comment("George", "Great tips, thanks!"));
        video3.AddComment(new Comment("Hannah", "Tip #5 was gold."));
        video3.AddComment(new Comment("Ian", "Really helpful content."));
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
