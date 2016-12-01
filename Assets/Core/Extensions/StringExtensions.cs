using System;

public static class StringExtensions {

   public static string F(this string format, params object[] args) {
      try {
         return string.Format(format, args);
      }
      catch (Exception ex) {
         return format + " exception: " + ex.Message;
      }
   }
}
