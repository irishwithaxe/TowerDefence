using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

   //public static class Log {
   //   public static event Action<string> OnInfo = (str) => { };
   //   public static event Action<string> OnError = (str) => { };

   //   [MethodImpl(MethodImplOptions.NoInlining)]
   //   public static string GetMethodName(int frames) {
   //      System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
   //      System.Diagnostics.StackFrame sf = st.GetFrame(frames);
   //      var method = sf.GetMethod();
   //      return method.DeclaringType.Name + "." + method.Name;
   //   }

   //   [MethodImpl(MethodImplOptions.NoInlining)]
   //   public static void Info(string message, params object[] objs) {
   //      OnInfo(GetMethodName(2) + ": " + message.F(objs));
   //   }
   //}
