using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using UserNotifications;

namespace JPushNotificationExtensionLibrary
{
    // @interface JPushNotificationExtensionService : NSObject
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface JPushNotificationExtensionService
    {
        // +(void)jpushSetAppkey:(NSString *)appkey;
        [Static]
        [Export("jpushSetAppkey:")]
        void JpushSetAppkey(string appkey);

        // +(void)jpushReceiveNotificationRequest:(UNNotificationRequest *)request with:(void (^)(void))completion;
        [Static]
        [Export("jpushReceiveNotificationRequest:with:")]
        void JpushReceiveNotificationRequest(UNNotificationRequest request, Action completion);
    }

    // @interface JPushNotificationExtensionServiceLibrary : NSObject
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface JPushNotificationExtensionServiceLibrary
    {
    }
}
