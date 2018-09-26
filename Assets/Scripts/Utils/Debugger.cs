using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Utils
{
    public static class Debugger
    {
        private static string _prefix = "<b>Abs: </b>";

        public static void Log(string info)
        {
#if ENABLE_DEBUG_LOGGER
            Debug.Log(_prefix + info);
#endif
        }

        public static void LogWarning(string info)
        {
#if ENABLE_DEBUG_LOGGER
            Debug.LogWarning(_prefix + info);
#endif
        }

        public static void LogError(string info)
        {
#if ENABLE_DEBUG_LOGGER
            Debug.LogError(_prefix + info);
#endif
        }

        public static void Exception(string info)
        {
#if ENABLE_DEBUG_LOGGER
            throw new Exception(_prefix + info);
#endif
        }
    }

}
