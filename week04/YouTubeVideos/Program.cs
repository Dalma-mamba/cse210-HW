using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# in 20 Minutes", "CodeMaster", 1200);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing."));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Football Goals", "SportsHub", 900);
        video2.AddComment(new Comment("David", "Amazing goals!"));
        video2.AddComment(new Comment("Emma", "My favorite player scored."));
        video2.AddComment(new Comment("Frank", "Awesome compilation."));
        videos.Add(video2);

        Video video3 = new Video("Easy Chicken Biryani Recipe", "CookingWithSarah", 1500);
        video3.AddComment(new Comment("Grace", "Looks delicious."));
        video3.AddComment(new Comment("Henry", "Trying this tonight."));
        video3.AddComment(new Comment("Isabella", "Loved the recipe."));
        videos.Add(video3);

        Video video4 = new Video("Shadow the Hedgehog Gameplay", "GamingZone", 1800);
        video4.AddComment(new Comment("Jack", "Awesome gameplay!"));
        video4.AddComment(new Comment("Kelly", "Brings back memories."));
        video4.AddComment(new Comment("Leo", "Great commentary."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}