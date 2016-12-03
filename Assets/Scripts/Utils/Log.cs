using System.Runtime.CompilerServices;
using UnityEngine;

public static class Log {
   private static long row = 0;

   [MethodImpl(MethodImplOptions.NoInlining)]
   public static string GetMethodName(int frames) {
      System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
      System.Diagnostics.StackFrame sf = st.GetFrame(frames);
      var method = sf.GetMethod();
      return method.DeclaringType.Name + "." + method.Name;
   }

   [MethodImpl(MethodImplOptions.NoInlining)]
   public static void Info(string message, params object[] objs) {
      Debug.Log(row++ + ". " + GetMethodName(2) + ": " + message.F(objs));
   }
}