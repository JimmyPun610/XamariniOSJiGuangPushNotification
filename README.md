# XamariniOSJiGuangPushNotification
This is JiGuang Push notification SDK in Xamarin iOS

Compile file as https://github.com/JimmyPun610/XamariniOSJiGuangPushNotification/blob/master/JPushiOSBindingLibrary/JPushiOSLibrary.dll

Based on JiGuang SDK v3.0.6 https://www.jiguang.cn/push

Guide :

1. Reference the dll to your Xamarin iOS project

2. Create class that inherit JPUSHRegisterDelegate
```C#
namespace MobileApp.iOS.Notification
{
    public class JPushInterface : JPushiOSLibrary.JPUSHRegisterDelegate
    {
        internal static string JPushAppKey = "YOUR_APP_KEY";
        internal static string Channel = "";
        JPushRegisterEntity entity { get; set; }
        public void Register(AppDelegate app, NSDictionary options)
        {
            //Register APNs
            string advertisingId = AdSupport.ASIdentifierManager.SharedManager.AdvertisingIdentifier.AsString();
            this.entity = new JPushRegisterEntity();
            this.entity.Types = 1 | 2 | 3;//entity.Types = (nint)(JPAuthorizationOptions.Alert) | JPAuthorizationOptions.Badge | JPAuthorizationOptions.Sound;
            JPUSHService.RegisterForRemoteNotificationConfig(entity, this);
            JPUSHService.SetupWithOption(options, JPushAppKey, Channel, true, advertisingId);
            JPUSHService.RegistrationIDCompletionHandler(app.GetRegistrationID);
        }

        /// <summary>
        /// When the app in foreground
        /// </summary>
        /// <param name="center"></param>
        /// <param name="notification"></param>
        /// <param name="completionHandler"></param>
        public override void WillPresentNotification(UserNotifications.UNUserNotificationCenter center, UserNotifications.UNNotification notification, Action<nint> completionHandler)
        {
            var content = notification.Request.Content;
            var userInfo = notification.Request.Content.UserInfo;
            if (typeof(UserNotifications.UNPushNotificationTrigger) == notification.Request.Trigger.GetType())
            {
                //remote notification
                JPUSHService.HandleRemoteNotification(userInfo);
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                JPushiOSLibrary.JPUSHService.SetBadge(0);
            }
            else
            {
                //local notification
            }

            if (completionHandler != null)
            {
                completionHandler(2);//UNNotificationPresentationOptions： None = 0,Badge = 1,Sound = 2,Alert = 4,
            }
        }

        /// <summary>
        /// when the app in background and user click into the notification
        /// </summary>
        /// <param name="center"></param>
        /// <param name="response"></param>
        /// <param name="completionHandler"></param>
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
        
            var content = response.Notification.Request.Content;
            var userInfo = response.Notification.Request.Content.UserInfo;
            if (typeof(UserNotifications.UNPushNotificationTrigger) == response.Notification.Request.Trigger.GetType())
            {
                //remote notification
                JPUSHService.HandleRemoteNotification(userInfo);
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                JPushiOSLibrary.JPUSHService.SetBadge(0);
            }
            else
            {
                //local notification
            }

            if (completionHandler != null)
            {
                completionHandler();
            }
        }

       
      
    }
}
```
3. Create another class inherit JPUSHRegisterEntity
```C#
namespace MobileApp.iOS.Notification
{
    public class JPushRegisterEntity : JPushiOSLibrary.JPUSHRegisterEntity
    {
        public override NSSet Categories
        {
            get
            {
                return base.Categories;
            }
            set
            {
                base.Categories = value;
            }
        }

        public override nint Types
        {
            get
            {
                return base.Types;
            }
            set
            {
                base.Types = value;
            }
        }
    }
}
```
4. In AppDelegate.cs
```C#
        JPushInterface jPushRegister { get; set; }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        { 
        global::Xamarin.Forms.Forms.Init();
             LoadApplication(new App());
            requestPermission(app);
              initPushNotification(options);
                   return base.FinishedLaunching(app, options);
        }

        private void requestPermission(UIApplication app)
        {

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Request Permissions
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (granted, error) =>
                {
                    // Do something if needed
                });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                 UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                    );

                app.RegisterUserNotificationSettings(notificationSettings);
            }
        }
        
        private void initPushNotification(NSDictionary options)
        {
            //Register iOS push notification
            if (options == null) options = new NSDictionary();
            jPushRegister = new JPushInterface();
            jPushRegister.Register(this, options);
            this.RegistLogin(options);
        }
        protected void RegistLogin(NSDictionary launchOptions)
        {
            string systemVersion = UIDevice.CurrentDevice.SystemVersion.Split('.')[0];
            Console.WriteLine("System Version: " + UIDevice.CurrentDevice.SystemVersion);

            //iOS10+
            if (float.Parse(systemVersion) >= 10.0)
            {
                UNUserNotificationCenter center = UNUserNotificationCenter.Current;
                center.RequestAuthorization((UNAuthorizationOptions.CarPlay | UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge), (bool arg1, NSError arg2) =>
                {
                    if (arg1)
                        Console.WriteLine("ios 10 request notification success");
                    else
                        Console.WriteLine("IOS 10 request notification failed");
                });
            }
            //iOS8+
            else if (float.Parse(systemVersion) >= 8.0)
            {
                UIUserNotificationSettings notiSettings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Badge | UIUserNotificationType.Sound | UIUserNotificationType.Alert, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(notiSettings);
            }
            //iOS8 or below
            else
            {
                UIRemoteNotificationType myTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Sound | UIRemoteNotificationType.Badge;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(myTypes);
            }
            UIApplication.SharedApplication.RegisterForRemoteNotifications();
            if (launchOptions != null)
            {
                NSDictionary remoteNotification = (NSDictionary)(launchOptions.ObjectForKey(UIApplication.LaunchOptionsRemoteNotificationKey));
                if (remoteNotification != null)
                {
              
                }
            }
        }
        

        public override void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings)
        {
            application.RegisterForRemoteNotifications();
        }

        /// <summary>
        /// Successfully get token
        /// </summary>
        /// <param name="application"></param>
        /// <param name="deviceToken"></param>
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            JPUSHService.RegisterDeviceToken(deviceToken);

            // Get current device token
            var DeviceToken = deviceToken.Description;
            if (!string.IsNullOrWhiteSpace(DeviceToken))
            {
                DeviceToken = DeviceToken.Trim('<').Trim('>');
            }

            // Get previous device token
            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

            // Has the token changed?
            if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
            {
                //TODO: Put your own logic here to notify your server that the device token has changed/been created!
            }
             // Save new device token 
            NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
        }
      
        /// <summary>
        /// Register token fail
        /// </summary>
        /// <param name="application"></param>
        /// <param name="error"></param>
        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            new Renderer.MessageIOS().ShortAlert("Fail to register remote notification");
        }

        public void GetRegistrationID(int resCode, NSString registrationID)
        {
            if (resCode == 0)
            {
                Console.WriteLine("RegistrationID Successed: {0}", registrationID);
            }
            else
                Console.WriteLine("RegistrationID Failed. ResultCode:{0}", resCode);
        }
        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            JPushiOSLibrary.JPUSHService.SetBadge(0);
        }
