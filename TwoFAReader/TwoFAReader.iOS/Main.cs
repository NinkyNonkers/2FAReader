#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace TwoFAReader.iOS
{
    public class Application
    {
        
        public static Reader? ReaderInstance { get; private set; }
        
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
            string ip = NSUserDefaults.StandardUserDefaults.StringForKey("2FAReaderIP");
            //TODO: sort this out no clue loooool
            ip = "192.168.1.250";
            NSUserDefaults.StandardUserDefaults.SetString(ip, "2FAReaderIP");
            ReaderInstance = new Reader(new UdpGenericSender(ip));
        }
    }
}