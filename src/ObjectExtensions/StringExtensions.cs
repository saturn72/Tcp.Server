﻿namespace System
{
    public static class StringExtensions
    {
        public static bool HasValue(this string source)
        {
            return !string.IsNullOrEmpty(source) && !string.IsNullOrWhiteSpace(source);
        }
    }
}
