using System.Collections;
using Unity.Notifications.Android;
using UnityEngine;

public class PushNotificationManager : MonoBehaviour
{
    private static string CHANNEL_ID = "notis01";

    private void Start()
    {
#if UNITY_ANDROID
        string NotiChannels_Created_Key = "NotiChannels_Created";
        if (!PlayerPrefs.HasKey(NotiChannels_Created_Key))
        {
            var group = new AndroidNotificationChannelGroup()
            {
                Id = "Main",
                Name = "Main notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannelGroup(group);
            var channel = new AndroidNotificationChannel()
            {
                Id = CHANNEL_ID,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
                Group = "Main",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            StartCoroutine(RequestPermission());

            PlayerPrefs.SetString(NotiChannels_Created_Key, "y");
            PlayerPrefs.Save();
        }
        else
        {
            ScheduleNotis();
        }

#endif
    }

    private IEnumerator RequestPermission()
    {
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
            yield return null;

        ScheduleNotis();
    }

    private void ScheduleNotis()
    {

        AndroidNotificationCenter.CancelAllScheduledNotifications();


        var notification = new AndroidNotification();
        notification.Title = "Acosta Maximiliano";
        notification.Text = "Miau Miau Miau";
        notification.FireTime = System.DateTime.Now.AddMinutes(5);

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);

    }
}
