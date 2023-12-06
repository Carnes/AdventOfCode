namespace Day5;

public static class TimeSpanExtensions
{
    public static string GetHumanReadableString(this TimeSpan value) //https://stackoverflow.com/questions/16689468/how-to-produce-human-readable-strings-to-represent-a-timespan
    {
        string duration;

        if (value.TotalSeconds < 1)
            duration = value.Milliseconds + " Milliseconds";
        else if (value.TotalMinutes < 1)
            duration = $"{value.Seconds}.{value.Milliseconds} Seconds";
        else if (value.TotalHours < 1)
            duration = value.Minutes + " Minutes, " + value.Seconds + " Seconds";
        else if (value.TotalDays < 1)
            duration = value.Hours + " Hours, " + value.Minutes + " Minutes";
        else
            duration = value.Days + " Days, " + value.Hours + " Hours";

        if (duration.StartsWith("1 Seconds") || duration.EndsWith(" 1 Seconds"))
            duration = duration.Replace("1 Seconds", "1 Second");

        if (duration.StartsWith("1 Minutes") || duration.EndsWith(" 1 Minutes"))
            duration = duration.Replace("1 Minutes", "1 Minute");

        if (duration.StartsWith("1 Hours") || duration.EndsWith(" 1 Hours"))
            duration = duration.Replace("1 Hours", "1 Hour");

        if (duration.StartsWith("1 Days"))
            duration = duration.Replace("1 Days", "1 Day");

        return duration;
    }
}