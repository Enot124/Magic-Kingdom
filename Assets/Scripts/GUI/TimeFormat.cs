using System;

public static class TimeFormat
{
   public static string Format(float seconds)
   {
      TimeSpan time = TimeSpan.FromSeconds(seconds);
      if (time.Seconds < 10)
         return $"0{time.Minutes}:0{time.Seconds}";
      else
         return $"0{time.Minutes}:{time.Seconds}";
   }
}