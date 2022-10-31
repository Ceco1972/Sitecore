using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventsAndDelegates
{
   public class VideoEventArgs : EventArgs
    {
        public Video Video  { get; set; }
    }
    
    
    public class VideoEncoder
    {
        //1-Define a delegate
        //2-Define an event based on that delegate
        //3-Raise the event

       //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
       // EventHandler
       // EventHandler<TEventArgs>
        public event EventHandler<VideoEventArgs> VideoEncoded;
        

        //the event
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }
        //Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded!=null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }
    }
}
