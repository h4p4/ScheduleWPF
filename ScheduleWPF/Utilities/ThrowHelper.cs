using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Utilities
{
    public static class ThrowHelper
    {
        public static void ThrowUnless<TException>(bool condition, string message)
            where TException : Exception
        {
            Exception ex = (Exception)Activator.CreateInstance(typeof(TException), message);
            try
            {
                if (!condition) throw ex;
            }
            catch (TException)
            {
                throw;
            }
        }
        public static void ThrowUnless<TException>(bool condition) 
            where TException : Exception
        {
            Exception ex = (Exception)Activator.CreateInstance(typeof(TException));
            try
            {
                if (!condition) throw ex;
            }
            catch (TException)
            {
                throw;
            }
        }
        public static void ThrowUnless(bool condition, string message)
        {
            try
            {
                if (!condition) throw new Exception(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ThrowUnless(bool condition)
        {
            try
            {
                if (!condition) throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ThrowIf<TException>(bool condition, string message) 
            where TException : Exception
        {
            Exception ex = (Exception)Activator.CreateInstance(typeof(TException), message);
            try
            {
                if (condition) throw ex;
            }
            catch (TException)
            {
                throw;
            }
        }
        public static void ThrowIf<TException>(bool condition) 
            where TException : Exception
        {
            Exception ex = (Exception)Activator.CreateInstance(typeof(TException));
            try
            {
                if (condition) throw ex;
            }
            catch (TException)
            {
                throw;
            }
        }
        public static void ThrowIf(bool condition, string message)
        {
            try
            {
                if (condition) throw new Exception(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ThrowIf(bool condition)
        {
            try
            {
                if (condition) throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
