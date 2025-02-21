﻿using System;

namespace EventsAndDelegates
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();//publisher
            var mailService = new MailService();//subscriber
            var messageService = new MessageService();//subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            
            videoEncoder.Encode(video);
            Console.Read();
        }
    }
}
