using System;

namespace EventsAndDelegates
{
   
        public class MessageService
        {
            public void OnVideoEncoded(object source, VideoEventArgs e)
            {
                Console.WriteLine("Messenger Service: Sending a message..." + e.Video.Title);
            }
        }
    
}
