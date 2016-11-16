using System;

public static class ArrayExtensions {
	public static T GetRandomItem<T>(this T[] array) {
		var rnd = new Random();
		return array[rnd.Next(0, array.Length)];
	}
}
