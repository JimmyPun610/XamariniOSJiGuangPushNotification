using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;
using UserNotifications;

namespace JPushiOSLibrary
{
	

    // typedef void (^JPUSHTagsOperationCompletion)(NSInteger, NSSet *, NSInteger);
    delegate void JPUSHTagsOperationCompletion(nint arg0, NSSet arg1, nint arg2);

    // typedef void (^JPUSHTagValidOperationCompletion)(NSInteger, NSSet *, NSInteger, BOOL);
    delegate void JPUSHTagValidOperationCompletion(nint arg0, NSSet arg1, nint arg2, bool arg3);

    // typedef void (^JPUSHAliasOperationCompletion)(NSInteger, NSString *, NSInteger);
    delegate void JPUSHAliasOperationCompletion(nint arg0, string arg1, nint arg2);

    [Static]
    partial interface Constants
    {
        // extern NSString *const kJPFNetworkIsConnectingNotification;
        [Field("kJPFNetworkIsConnectingNotification", "__Internal")]
        NSString kJPFNetworkIsConnectingNotification { get; }

        // extern NSString *const kJPFNetworkDidSetupNotification;
        [Field("kJPFNetworkDidSetupNotification", "__Internal")]
        NSString kJPFNetworkDidSetupNotification { get; }

        // extern NSString *const kJPFNetworkDidCloseNotification;
        [Field("kJPFNetworkDidCloseNotification", "__Internal")]
        NSString kJPFNetworkDidCloseNotification { get; }

        // extern NSString *const kJPFNetworkDidRegisterNotification;
        [Field("kJPFNetworkDidRegisterNotification", "__Internal")]
        NSString kJPFNetworkDidRegisterNotification { get; }

        // extern NSString *const kJPFNetworkFailedRegisterNotification;
        [Field("kJPFNetworkFailedRegisterNotification", "__Internal")]
        NSString kJPFNetworkFailedRegisterNotification { get; }

        // extern NSString *const kJPFNetworkDidLoginNotification;
        [Field("kJPFNetworkDidLoginNotification", "__Internal")]
        NSString kJPFNetworkDidLoginNotification { get; }

        // extern NSString *const kJPFNetworkDidReceiveMessageNotification;
        [Field("kJPFNetworkDidReceiveMessageNotification", "__Internal")]
        NSString kJPFNetworkDidReceiveMessageNotification { get; }

        // extern NSString *const kJPFServiceErrorNotification;
        [Field("kJPFServiceErrorNotification", "__Internal")]
        NSString kJPFServiceErrorNotification { get; }
    }

    // @interface JPUSHRegisterEntity : NSObject
    [BaseType(typeof(NSObject))]
    interface JPUSHRegisterEntity
    {
        // @property (assign, nonatomic) NSInteger types;
        [Export("types")]
        nint Types { get; set; }

        // @property (nonatomic, strong) NSSet * categories;
        [Export("categories", ArgumentSemantic.Strong)]
        NSSet Categories { get; set; }
    }

    // @interface JPushNotificationIdentifier : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationIdentifier : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSArray<NSString *> * identifiers;
        [Export("identifiers", ArgumentSemantic.Copy)]
        string[] Identifiers { get; set; }

        // @property (copy, nonatomic) UILocalNotification * notificationObj __attribute__((availability(ios, introduced=4_0, deprecated=10_0)));
        [Introduced(PlatformName.iOS, 4, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("notificationObj", ArgumentSemantic.Copy)]
        UILocalNotification NotificationObj { get; set; }

        // @property (assign, nonatomic) BOOL delivered __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("delivered")]
        bool Delivered { get; set; }

        // @property (copy, nonatomic) void (^findCompletionHandler)(NSArray *);
        [Export("findCompletionHandler", ArgumentSemantic.Copy)]
        Action<NSArray> FindCompletionHandler { get; set; }
    }

    // @interface JPushNotificationContent : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationContent : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSString * title;
        [Export("title")]
        string Title { get; set; }

        // @property (copy, nonatomic) NSString * subtitle;
        [Export("subtitle")]
        string Subtitle { get; set; }

        // @property (copy, nonatomic) NSString * body;
        [Export("body")]
        string Body { get; set; }

        // @property (copy, nonatomic) NSNumber * badge;
        [Export("badge", ArgumentSemantic.Copy)]
        NSNumber Badge { get; set; }

        // @property (copy, nonatomic) NSString * action __attribute__((availability(ios, introduced=8_0, deprecated=10_0)));
        [Introduced(PlatformName.iOS, 8, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("action")]
        string Action { get; set; }

        // @property (copy, nonatomic) NSString * categoryIdentifier;
        [Export("categoryIdentifier")]
        string CategoryIdentifier { get; set; }

        // @property (copy, nonatomic) NSDictionary * userInfo;
        [Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary UserInfo { get; set; }

        // @property (copy, nonatomic) NSString * sound;
        [Export("sound")]
        string Sound { get; set; }

        // @property (copy, nonatomic) NSArray * attachments __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("attachments", ArgumentSemantic.Copy)]
        NSObject[] Attachments { get; set; }

        // @property (copy, nonatomic) NSString * threadIdentifier __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("threadIdentifier")]
        string ThreadIdentifier { get; set; }

        // @property (copy, nonatomic) NSString * launchImageName __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("launchImageName")]
        string LaunchImageName { get; set; }
    }

    // @interface JPushNotificationTrigger : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationTrigger : INSCopying, INSCoding
    {
        // @property (assign, nonatomic) BOOL repeat;
        [Export("repeat")]
        bool Repeat { get; set; }

        // @property (copy, nonatomic) NSDate * fireDate __attribute__((availability(ios, introduced=2_0, deprecated=10_0)));
        [Introduced(PlatformName.iOS, 2, 0)]
        [Deprecated(PlatformName.iOS, 10, 0)]
        [Export("fireDate", ArgumentSemantic.Copy)]
        NSDate FireDate { get; set; }

        // @property (copy, nonatomic) CLRegion * region __attribute__((availability(ios, introduced=8_0)));
        [iOS(8, 0)]
        [Export("region", ArgumentSemantic.Copy)]
        CLRegion Region { get; set; }

        // @property (copy, nonatomic) NSDateComponents * dateComponents __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("dateComponents", ArgumentSemantic.Copy)]
        NSDateComponents DateComponents { get; set; }

        // @property (assign, nonatomic) NSTimeInterval timeInterval __attribute__((availability(ios, introduced=10_0)));
        [iOS(10, 0)]
        [Export("timeInterval")]
        double TimeInterval { get; set; }
    }

    // @interface JPushNotificationRequest : NSObject <NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface JPushNotificationRequest : INSCopying, INSCoding
    {
        // @property (copy, nonatomic) NSString * requestIdentifier;
        [Export("requestIdentifier")]
        string RequestIdentifier { get; set; }

        // @property (copy, nonatomic) JPushNotificationContent * content;
        [Export("content", ArgumentSemantic.Copy)]
        JPushNotificationContent Content { get; set; }

        // @property (copy, nonatomic) JPushNotificationTrigger * trigger;
        [Export("trigger", ArgumentSemantic.Copy)]
        JPushNotificationTrigger Trigger { get; set; }

        // @property (copy, nonatomic) void (^completionHandler)(id);
        [Export("completionHandler", ArgumentSemantic.Copy)]
        Action<NSObject> CompletionHandler { get; set; }
    }

    // @interface JPUSHService : NSObject
    [BaseType(typeof(NSObject))]
    interface JPUSHService
    {
        // +(void)setupWithOption:(NSDictionary *)launchingOption __attribute__((deprecated("JPush 2.1.0 版本已过期")));
        [Static]
        [Export("setupWithOption:")]
        void SetupWithOption(NSDictionary launchingOption);

        // +(void)setupWithOption:(NSDictionary *)launchingOption appKey:(NSString *)appKey channel:(NSString *)channel apsForProduction:(BOOL)isProduction;
        [Static]
        [Export("setupWithOption:appKey:channel:apsForProduction:")]
        void SetupWithOption(NSDictionary launchingOption, string appKey, string channel, bool isProduction);

        // +(void)setupWithOption:(NSDictionary *)launchingOption appKey:(NSString *)appKey channel:(NSString *)channel apsForProduction:(BOOL)isProduction advertisingIdentifier:(NSString *)advertisingId;
        [Static]
        [Export("setupWithOption:appKey:channel:apsForProduction:advertisingIdentifier:")]
        void SetupWithOption(NSDictionary launchingOption, string appKey, string channel, bool isProduction, string advertisingId);

        // +(void)registerForRemoteNotificationTypes:(NSUInteger)types categories:(NSSet *)categories;
        [Static]
        [Export("registerForRemoteNotificationTypes:categories:")]
        void RegisterForRemoteNotificationTypes(nuint types, NSSet categories);

        // +(void)registerForRemoteNotificationConfig:(JPUSHRegisterEntity *)config delegate:(id<JPUSHRegisterDelegate>)delegate;
        [Static]
        [Export("registerForRemoteNotificationConfig:delegate:")]
        void RegisterForRemoteNotificationConfig(JPUSHRegisterEntity config, JPUSHRegisterDelegate @delegate);

        // +(void)registerDeviceToken:(NSData *)deviceToken;
        [Static]
        [Export("registerDeviceToken:")]
        void RegisterDeviceToken(NSData deviceToken);

        // +(void)handleRemoteNotification:(NSDictionary *)remoteInfo;
        [Static]
        [Export("handleRemoteNotification:")]
        void HandleRemoteNotification(NSDictionary remoteInfo);

        // +(void)addTags:(NSSet<NSString *> *)tags completion:(JPUSHTagsOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("addTags:completion:seq:")]
        void AddTags(NSSet<NSString> tags, JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)setTags:(NSSet<NSString *> *)tags completion:(JPUSHTagsOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("setTags:completion:seq:")]
        void SetTags(NSSet<NSString> tags, JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)deleteTags:(NSSet<NSString *> *)tags completion:(JPUSHTagsOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("deleteTags:completion:seq:")]
        void DeleteTags(NSSet<NSString> tags, JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)cleanTags:(JPUSHTagsOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("cleanTags:seq:")]
        void CleanTags(JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)getAllTags:(JPUSHTagsOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("getAllTags:seq:")]
        void GetAllTags(JPUSHTagsOperationCompletion completion, nint seq);

        // +(void)validTag:(NSString *)tag completion:(JPUSHTagValidOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("validTag:completion:seq:")]
        void ValidTag(string tag, JPUSHTagValidOperationCompletion completion, nint seq);

        // +(void)setAlias:(NSString *)alias completion:(JPUSHAliasOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("setAlias:completion:seq:")]
        void SetAlias(string alias, JPUSHAliasOperationCompletion completion, nint seq);

        // +(void)deleteAlias:(JPUSHAliasOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("deleteAlias:seq:")]
        void DeleteAlias(JPUSHAliasOperationCompletion completion, nint seq);

        // +(void)getAlias:(JPUSHAliasOperationCompletion)completion seq:(NSInteger)seq;
        [Static]
        [Export("getAlias:seq:")]
        void GetAlias(JPUSHAliasOperationCompletion completion, nint seq);

        // +(NSSet *)filterValidTags:(NSSet *)tags;
        [Static]
        [Export("filterValidTags:")]
        NSSet FilterValidTags(NSSet tags);

        // +(void)startLogPageView:(NSString *)pageName;
        [Static]
        [Export("startLogPageView:")]
        void StartLogPageView(string pageName);

        // +(void)stopLogPageView:(NSString *)pageName;
        [Static]
        [Export("stopLogPageView:")]
        void StopLogPageView(string pageName);

        // +(void)beginLogPageView:(NSString *)pageName duration:(int)seconds;
        [Static]
        [Export("beginLogPageView:duration:")]
        void BeginLogPageView(string pageName, int seconds);

        // +(void)crashLogON;
        [Static]
        [Export("crashLogON")]
        void CrashLogON();

        // +(void)setLatitude:(double)latitude longitude:(double)longitude;
        [Static]
        [Export("setLatitude:longitude:")]
        void SetLatitude(double latitude, double longitude);

        // +(void)setLocation:(CLLocation *)location;
        [Static]
        [Export("setLocation:")]
        void SetLocation(CLLocation location);

        // +(void)addNotification:(JPushNotificationRequest *)request;
        [Static]
        [Export("addNotification:")]
        void AddNotification(JPushNotificationRequest request);

        // +(void)removeNotification:(JPushNotificationIdentifier *)identifier;
        [Static]
        [Export("removeNotification:")]
        void RemoveNotification(JPushNotificationIdentifier identifier);

        // +(void)findNotification:(JPushNotificationIdentifier *)identifier;
        [Static]
        [Export("findNotification:")]
        void FindNotification(JPushNotificationIdentifier identifier);

        // +(UILocalNotification *)setLocalNotification:(NSDate *)fireDate alertBody:(NSString *)alertBody badge:(int)badge alertAction:(NSString *)alertAction identifierKey:(NSString *)notificationKey userInfo:(NSDictionary *)userInfo soundName:(NSString *)soundName __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertAction, string notificationKey, NSDictionary userInfo, string soundName);

        // +(UILocalNotification *)setLocalNotification:(NSDate *)fireDate alertBody:(NSString *)alertBody badge:(int)badge alertAction:(NSString *)alertAction identifierKey:(NSString *)notificationKey userInfo:(NSDictionary *)userInfo soundName:(NSString *)soundName region:(CLRegion *)region regionTriggersOnce:(BOOL)regionTriggersOnce category:(NSString *)category __attribute__((deprecated("JPush 2.1.9 版本已过期"))) __attribute__((availability(ios, introduced=8_0)));
        [Static]
        [Export("setLocalNotification:alertBody:badge:alertAction:identifierKey:userInfo:soundName:region:regionTriggersOnce:category:")]
        UILocalNotification SetLocalNotification(NSDate fireDate, string alertBody, int badge, string alertAction, string notificationKey, NSDictionary userInfo, string soundName, CLRegion region, bool regionTriggersOnce, string category);

        // +(void)showLocalNotificationAtFront:(UILocalNotification *)notification identifierKey:(NSString *)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("showLocalNotificationAtFront:identifierKey:")]
        void ShowLocalNotificationAtFront(UILocalNotification notification, string notificationKey);

        // +(void)deleteLocalNotificationWithIdentifierKey:(NSString *)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("deleteLocalNotificationWithIdentifierKey:")]
        void DeleteLocalNotificationWithIdentifierKey(string notificationKey);

        // +(void)deleteLocalNotification:(UILocalNotification *)localNotification __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("deleteLocalNotification:")]
        void DeleteLocalNotification(UILocalNotification localNotification);

        // +(NSArray *)findLocalNotificationWithIdentifier:(NSString *)notificationKey __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("findLocalNotificationWithIdentifier:")]
        NSObject[] FindLocalNotificationWithIdentifier(string notificationKey);

        // +(void)clearAllLocalNotifications __attribute__((deprecated("JPush 2.1.9 版本已过期")));
        [Static]
        [Export("clearAllLocalNotifications")]
        void ClearAllLocalNotifications();

        // +(BOOL)setBadge:(NSInteger)value;
        [Static]
        [Export("setBadge:")]
        bool SetBadge(nint value);

        // +(void)resetBadge;
        [Static]
        [Export("resetBadge")]
        void ResetBadge();

        // +(NSString *)registrationID;
        [Static]
        [Export("registrationID")]
        string RegistrationID { get; }

        // +(void)registrationIDCompletionHandler:(void (^)(int, NSString *))completionHandler;
        [Static]
        [Export("registrationIDCompletionHandler:")]
        void RegistrationIDCompletionHandler(Action<int, NSString> completionHandler);

        // +(void)setDebugMode;
        [Static]
        [Export("setDebugMode")]
        void SetDebugMode();

        // +(void)setLogOFF;
        [Static]
        [Export("setLogOFF")]
        void SetLogOFF();

        // +(void)setTags:(NSSet *)tags alias:(NSString *)alias callbackSelector:(SEL)cbSelector target:(id)theTarget __attribute__((deprecated("JPush 2.1.1 版本已过期")));
        [Static]
        [Export("setTags:alias:callbackSelector:target:")]
        void SetTags(NSSet tags, string alias, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet *)tags alias:(NSString *)alias callbackSelector:(SEL)cbSelector object:(id)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        //[Static]
        //[Export("setTags:alias:callbackSelector:object:")]
        //void SetTags(NSSet tags, string alias, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet *)tags callbackSelector:(SEL)cbSelector object:(id)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:callbackSelector:object:")]
        void SetTags(NSSet tags, Selector cbSelector, NSObject theTarget);

        // +(void)setTags:(NSSet *)tags alias:(NSString *)alias fetchCompletionHandle:(void (^)(int, NSSet *, NSString *))completionHandler __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:alias:fetchCompletionHandle:")]
        void SetTags(NSSet tags, string alias, Action<int, NSSet, NSString> completionHandler);

        // +(void)setTags:(NSSet *)tags aliasInbackground:(NSString *)alias __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setTags:aliasInbackground:")]
        void SetTags(NSSet tags, string alias);

        // +(void)setAlias:(NSString *)alias callbackSelector:(SEL)cbSelector object:(id)theTarget __attribute__((deprecated("JPush 3.0.6 版本已过期")));
        [Static]
        [Export("setAlias:callbackSelector:object:")]
        void SetAlias(string alias, Selector cbSelector, NSObject theTarget);
    }

    // @protocol JPUSHRegisterDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JPUSHRegisterDelegate
    {
        // @required -(void)jpushNotificationCenter:(UNUserNotificationCenter *)center willPresentNotification:(UNNotification *)notification withCompletionHandler:(void (^)(NSInteger))completionHandler;
        [Abstract]
        [Export("jpushNotificationCenter:willPresentNotification:withCompletionHandler:")]
        void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<nint> completionHandler);

        // @required -(void)jpushNotificationCenter:(UNUserNotificationCenter *)center didReceiveNotificationResponse:(UNNotificationResponse *)response withCompletionHandler:(void (^)())completionHandler;
        [Abstract]
        [Export("jpushNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler);
    }

    // @interface JPushLibrary : NSObject
    [BaseType(typeof(NSObject))]
    interface JPushLibrary
    {
    }
}
