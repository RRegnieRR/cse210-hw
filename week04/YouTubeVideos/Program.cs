using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("10 Desk Setup Upgrades Under $50", "Tech Shelf", 485);
        video1.AddComment(new Comment("Avery", "The cable tray tip cleaned up my whole desk."));
        video1.AddComment(new Comment("Jordan", "I bought the lamp you mentioned and it is excellent."));
        video1.AddComment(new Comment("Sky", "Please make a part two with monitor accessories."));

        Video video2 = new Video("Beginner Meal Prep for Busy Students", "Campus Kitchen", 612);
        video2.AddComment(new Comment("Mia", "Those breakfast burritos would save me every morning."));
        video2.AddComment(new Comment("Leo", "Clear steps and realistic budget. Thanks."));
        video2.AddComment(new Comment("Nina", "I tried the chicken bowls this week and they turned out great."));

        Video video3 = new Video("How to Start Strength Training at Home", "Fit Fundamentals", 734);
        video3.AddComment(new Comment("Chris", "The form reminders were more helpful than most gym videos."));
        video3.AddComment(new Comment("Taylor", "I appreciate that you showed modifications for beginners."));
        video3.AddComment(new Comment("Sam", "Could you do a follow-up for resistance band workouts?"));

        Video video4 = new Video("Top 5 Travel Apps for a Weekend Trip", "Nomad Notes", 403);
        video4.AddComment(new Comment("Harper", "The offline maps feature alone is worth the download."));
        video4.AddComment(new Comment("Riley", "Short, useful, and no filler."));
        video4.AddComment(new Comment("Casey", "I used the packing app recommendation for my last flight."));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
