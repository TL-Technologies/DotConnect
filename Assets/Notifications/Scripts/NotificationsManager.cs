using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationsManager : MonoBehaviour
{

    void Start()
    {
        initNotifications();
    }

    void initNotifications() 
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = "example_channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic Notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        AndroidNotification notiication = new AndroidNotification();
        notiication.Title = "A Good News for You!";
        notiication.Text = "Your Daily Reward is Ready, Play Now to Collect it!";
        notiication.SmallIcon = "Icon_1";
        notiication.LargeIcon = "Icon_2";
        notiication.ShowTimestamp = true;
        notiication.FireTime = System.DateTime.Now.AddDays(1);

        var identifer = AndroidNotificationCenter.SendNotification(notiication, "example_channel_id");
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifer) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notiication, "example_channel_id");
        }
    }
}
