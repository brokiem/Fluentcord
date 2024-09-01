using System;

namespace Fluentcord.Utils;

public class TimeUtils
{
    /// <summary>
    /// Formats the given DateTime into a human-readable string.
    /// </summary>
    /// <param name="dateTime">The DateTime to format.</param>
    /// <returns>A string representing the DateTime in a human-readable format. If the DateTime is today, it returns "Today at {time}". If the DateTime is yesterday, it returns "Yesterday at {time}". Otherwise, it returns the DateTime in the format "dd/MM/yyyy hh:mm tt".</returns>
    public static string FormatTime(DateTimeOffset dateTime) {
        var localDateTime = dateTime.ToLocalTime();

        var now = DateTimeOffset.Now.ToLocalTime();
        var today = now.Date;
        var yesterday = now.AddDays(-1).Date;

        var timestamp = localDateTime.Date == today
            ? $"Today at {localDateTime:hh:mm tt}"
            : localDateTime.Date == yesterday
                ? $"Yesterday at {localDateTime:hh:mm tt}"
                : $"{localDateTime:dd/MM/yyyy hh:mm tt}";

        return timestamp;
    }
}