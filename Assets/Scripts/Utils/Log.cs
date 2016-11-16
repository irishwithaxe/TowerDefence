using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static class Log {
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMethodName(int frames) {
		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
		System.Diagnostics.StackFrame sf = st.GetFrame(frames);
		var method = sf.GetMethod();
		return method.DeclaringType.Name + "." + method.Name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Info(string message, params object[] objs) {
		Debug.Log(GetMethodName(2) + ": " + message.F(objs));
	}
}
